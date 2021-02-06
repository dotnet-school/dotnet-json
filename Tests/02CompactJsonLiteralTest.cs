using System;
using System.Text.Json;
using Xunit;

namespace Tests
{
    public class JsonDefinition
    {

        [Fact]
        public void ShouldDefineJsonCompactly()
        {

          var json = new
          {
              time = "value",
              date = "good value",
              tokenResponse = new {
                  access_token = "value-my"
              }
          };
          var actualString = System.Text.Json.JsonSerializer.Serialize(json);
          var jsonString = JsonSerializer.Serialize(JsonSerializer.Deserialize<dynamic>(actualString));

          Console.WriteLine(jsonString);
          Assert.Equal(actualString, jsonString);
        }
    }
}
