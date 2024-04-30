namespace Fennorad.Models
{
    public class ClaudeMessage
    {
        public bool IsFromClaude { get; set; }
        public string Message { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string Base64Image { get; set; }
        public string MediaType { get; set; }
    }
}
