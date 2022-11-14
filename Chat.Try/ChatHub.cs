using Microsoft.AspNetCore.SignalR;

namespace BlazorChat
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string username, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }

        /// <summary>
        /// This method is used when trying to send a message to a specific user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendUserMessage(string userId, string message, int conversationId)
        {
            await Clients.User(userId).SendAsync("ReceiveUserMessage", userId, message, conversationId);
        }
    }
}