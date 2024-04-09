using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fennorad.Models
{
    public class AnthropicMessage
    {
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class AnthropicRequest
    {
        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("messages")]
        public List<AnthropicMessage> Messages { get; set; }

        [JsonProperty("max_tokens")]
        public int MaxTokens { get; set; }
    }


}
