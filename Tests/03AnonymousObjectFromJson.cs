using System;
using Xunit;

namespace Tests
{
    public class AnonymousObjectFromJson
    {

        [Fact]
        public void ShouldDesrializeElaganly()
        {

          var json = new
          {
              time = "value",
              date = "good value",
              tokenResponse = new {
                  access_token = "value-my"
              }
          };
          var jsonString = System.Text.Json.JsonSerializer.Serialize(json);
          var response = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(jsonString, json);
          
          Assert.Equal(json, response);
          Assert.Equal("value-my", response.tokenResponse.access_token);
        }
    }
}
