using System.Text.Json.Serialization;

namespace MinimalAPI.WebAPI.Entities
{
    public class Todo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("iscomplete")]
        public bool IsComplete { get; set; }
    }
}