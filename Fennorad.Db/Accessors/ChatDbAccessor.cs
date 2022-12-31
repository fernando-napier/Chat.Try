using Fennorad.Db.Context;
using Fennorad.Db.Models;
using Fennorad.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fennorad.Db.Accessors
{
    public interface IChatDbAccessor
    {
        List<Conversations> GetUserConversations(string userId);
        bool SaveConversation(Conversations conversation);
        bool ConversationExists(string user1, string user2);
        bool SaveNewMessage(Conversations conversation, DisplayMessage displayMessage);
        List<UserMessages> GetUserMessages(int conversationId);
        Conversations GetConversation(int conversationId);
        List<Conversations> RefreshConversations(string userId);
        Counter? GetCounter(string userId);
        bool SaveCounter(Counter counter);
        bool UpdateCounter(Counter counter);
        List<Counter> GetLeaderboard();

        void SetConversationRead(int conversationId, int conversationUserId);
    }

    public class ChatDbAccessor : IChatDbAccessor
    {
        private readonly ChatContext _chatContext;
        private readonly IServiceScopeFactory _serviceScope;

        public ChatDbAccessor(ChatContext chatContext, IServiceScopeFactory serviceScope)
        {
            _chatContext = chatContext;
            _serviceScope = serviceScope;
        }

        public List<Conversations> GetUserConversations(string userId)
        {
            var conversationIds = _chatContext.ConversationUsers.AsNoTracking().Where(x => x.UserId == userId).Select(x => x.ConversationId);
            return _chatContext.Conversations.AsNoTracking().Where(x => conversationIds.Contains(x.Id))
                .Include(x => x.ConversationUsers).ThenInclude(x => x.User)
                .Include(x => x.ConversationUsers).ThenInclude(x => x.UserMessages).ThenInclude(x => x.ReadReceipts)
                .OrderByDescending(x => x.ConversationUsers.SelectMany(x => x.UserMessages).OrderByDescending(y => y.CreatedOn).FirstOrDefault())
                .ToList();
        }

        public bool SaveConversation(Conversations conversation)
        {
            _chatContext.Conversations.Add(conversation);
            _chatContext.ConversationUsers.AddRange(conversation.ConversationUsers);
            return _chatContext.SaveChanges() > 0;
        }

        public bool ConversationExists(string user1, string user2)
        {
            var user1Convos = _chatContext.ConversationUsers.AsNoTracking().Where(x => x.UserId == user1).Select(x => x.ConversationId).ToList();
            var user2Convos = _chatContext.ConversationUsers.AsNoTracking().Where(x => x.UserId == user2).Select(x => x.ConversationId).ToList();
            return user1Convos.Any(x => user2Convos.Contains(x));
        }

        public bool SaveNewMessage(Conversations conversation, DisplayMessage displayMessage)
        {
            using var scope = _serviceScope.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ChatContext>();
            var conversationUser = context.ConversationUsers.First(x => x.UserId == displayMessage.UserId && x.ConversationId == conversation.Id);
            conversationUser.UserMessages.Add(new UserMessages { Message = displayMessage.Message, CreatedOn = displayMessage.CreatedOn });
            context.Update(conversationUser);
            var successFlag = context.SaveChanges() > 0;

            conversation = GetConversation(conversation.Id);
            return successFlag;
        }

        public List<UserMessages> GetUserMessages(int conversationId)
        {
            return _chatContext.Conversations.AsNoTracking()
                .Include(x => x.ConversationUsers).ThenInclude(x => x.User)
                .Include(x => x.ConversationUsers).ThenInclude(x => x.UserMessages).ThenInclude(x => x.ReadReceipts)
                .First(x => x.Id == conversationId)
                .ConversationUsers.SelectMany(x => x.UserMessages).OrderByDescending(x => x.CreatedOn).ToList();
        }

        public Conversations GetConversation(int id)
        {
            return _chatContext.Conversations.AsNoTracking()
                .Include(x => x.ConversationUsers).ThenInclude(x => x.User)
                .Include(x => x.ConversationUsers).ThenInclude(x => x.UserMessages).ThenInclude(x => x.ReadReceipts)
                .First(x => x.Id == id);
        }

        public List<Conversations> RefreshConversations(string userId)
        {
            var conversationIds = _chatContext.ConversationUsers.AsNoTracking().Where(x => x.UserId == userId).Select(x => x.ConversationId);
            return _chatContext.Conversations.AsNoTracking().Where(x => conversationIds.Contains(x.Id))
                .Include(x => x.ConversationUsers).ThenInclude(x => x.User)
                .Include(x => x.ConversationUsers).ThenInclude(x => x.UserMessages).ThenInclude(x => x.ReadReceipts)
                .OrderByDescending(x => x.ConversationUsers.SelectMany(x => x.UserMessages).OrderByDescending(y => y.CreatedOn).FirstOrDefault())
                .ToList();
        }

        public Counter? GetCounter(string userId)
        {
            return _chatContext.Counter.FirstOrDefault(x => x.UserId == userId);
        }

        public bool SaveCounter(Counter counter)
        {
            _chatContext.Counter.Add(counter);
            return _chatContext.SaveChanges() > 0;
        }

        public List<Counter> GetLeaderboard()
        {
            return _chatContext.Counter.AsNoTracking()
                .Include(x => x.User)
                .OrderByDescending(x => x.Count).Take(10).ToList();
        }

        public bool UpdateCounter(Counter counter)
        {
            _chatContext.Counter.Update(counter);
            return _chatContext.SaveChanges() > 0;
        }

        public void SetConversationRead(int conversationId, int conversationUserId)
        {
            using var scope = _serviceScope.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ChatContext>();

            var conversation = context.Conversations
                .Include(x => x.ConversationUsers)
                .ThenInclude(x => x.UserMessages)
                .ThenInclude(x => x.ReadReceipts)
                .First(x => x.Id == conversationId);
            var unreadMessages = conversation.ConversationUsers.First(x => x.Id != conversationUserId)
                .UserMessages.Where(x => !x.ReadReceipts.Any()).ToList();

            var readReceipts = unreadMessages.Select(x => 
                new ReadReceipts
                {
                    UserMessageId = x.Id,
                    ConversationUserId = x.ConversationUser.Id,
                    CreatedOn = DateTimeOffset.Now,
                });

            context.AddRange(readReceipts);
            context.SaveChanges();


        }
    }
}
