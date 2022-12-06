using System.Text.Json;

namespace BeelineTest.Data.Json.Serialization;

public static class DefaultJsonSerialization
{
    public static JsonSerializerOptions? Options { get; } = new(JsonSerializerDefaults.Web);
}