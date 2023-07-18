using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestHealthChecks
{
    public class StatusConverter : JsonConverter<HealthStatus>
    {
        public override HealthStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return (HealthStatus)JsonSerializer.Deserialize<int>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, HealthStatus value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }

}
