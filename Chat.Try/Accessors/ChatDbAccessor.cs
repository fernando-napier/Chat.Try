using Chat.Try.Db.Context;
using Chat.Try.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.Try.Accessors
{
    public interface IChatDbAccessor
    {
        List<Conversations> GetUserConversations(string userId);
        bool SaveConversation(Conversations conversation);
        bool ConversationExists(string user1, string user2);
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
                .Include(x => x.ConversationUsers).ToList();
        }

        public bool SaveConversation(Conversations conversation)
        {
            _chatContext.Conversations.Add(conversation);
            return _chatContext.SaveChanges() > 0;
        }

        public bool ConversationExists(string user1, string user2)
        {
            var user1Convos = _chatContext.ConversationUsers.Where(x => x.UserId == user1).Select(x => x.ConversationId).ToList();
            var user2Convos = _chatContext.ConversationUsers.Where(x => x.UserId == user2).Select(x => x.ConversationId).ToList();
            return user1Convos.Any(x => user2Convos.Contains(x));
        }
    }
}
