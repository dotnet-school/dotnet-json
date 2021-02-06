using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
  [TestClass]
    public class AnonymousObjectFromJson
    {

      [TestMethod]

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
          
          Assert.AreEqual(json, response);
          Assert.AreEqual("value-my", response.tokenResponse.access_token);
        }
    }
}
