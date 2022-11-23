using Chat.Try.Db.Context;
using Chat.Try.Db.Models;
using Chat.Try.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.Try.Accessors
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
    }

    public class ChatDbAccessor : IChatDbAccessor
    {
        private readonly ChatContext _chatContext;

        public ChatDbAccessor(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }

        public List<Conversations> GetUserConversations(string userId)
        {
            var conversationIds = _chatContext.ConversationUsers.Where(x => x.UserId == userId).Select(x => x.ConversationId);
            return _chatContext.Conversations.Where(x => conversationIds.Contains(x.Id))
                .Include(x => x.ConversationUsers).ThenInclude(x => x.User)
                .Include(x => x.ConversationUsers).ThenInclude(x => x.UserMessages)
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
            var user1Convos = _chatContext.ConversationUsers.Where(x => x.UserId == user1).Select(x => x.ConversationId).ToList();
            var user2Convos = _chatContext.ConversationUsers.Where(x => x.UserId == user2).Select(x => x.ConversationId).ToList();
            return user1Convos.Any(x => user2Convos.Contains(x));
        }

        public bool SaveNewMessage(Conversations conversation, DisplayMessage displayMessage)
        {
            conversation.ConversationUsers.First(x => x.UserId == displayMessage.UserId)
                .UserMessages.Add(new UserMessages { Message = displayMessage.Message, CreatedOn = displayMessage.CreatedOn });
            _chatContext.Update(conversation);
            return _chatContext.SaveChanges() > 0;
        }

        public List<UserMessages> GetUserMessages(int conversationId)
        {
            return _chatContext.Conversations.AsNoTracking()
                .Include(x => x.ConversationUsers).ThenInclude(x => x.User)
                .Include(x => x.ConversationUsers).ThenInclude(x => x.UserMessages)
                .First(x => x.Id == conversationId)
                .ConversationUsers.SelectMany(x => x.UserMessages).ToList();
        }

        public Conversations GetConversation(int id)
        {
            return _chatContext.Conversations
                .Include(x => x.ConversationUsers).ThenInclude(x => x.User)
                .Include(x => x.ConversationUsers).ThenInclude(x => x.UserMessages)
                .First(x => x.Id == id);
        }

        public List<Conversations> RefreshConversations(string userId)
        {
            var conversationIds = _chatContext.ConversationUsers.Where(x => x.UserId == userId).Select(x => x.ConversationId);
            return _chatContext.Conversations.AsNoTracking().Where(x => conversationIds.Contains(x.Id))
                .Include(x => x.ConversationUsers).ThenInclude(x => x.User)
                .Include(x => x.ConversationUsers).ThenInclude(x => x.UserMessages)
                .OrderByDescending(x => x.ConversationUsers.SelectMany(x => x.UserMessages).OrderByDescending(y => y.CreatedOn).FirstOrDefault())
                .ToList();
        }
    }
}
