namespace Chat.Try.Models
{
    public class DisplayMessage
    { 
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

    }
}
