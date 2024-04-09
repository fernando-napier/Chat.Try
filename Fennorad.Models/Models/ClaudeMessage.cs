namespace Fennorad.Models
{
    public class ClaudeMessage
    {
        public bool IsFromClaude { get; set; }
        public string Message { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
