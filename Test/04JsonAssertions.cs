using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
  [TestClass]
    public class JsonAssertions
    {

      static object expected = new
      {
              time = "value",
              date = "good value",
              tokenResponse = new {
                      access_token = "value-my"
              }
      };
      
      static object actual = new
      {
        time = "value",
        date = "good value",
        tokenResponse = new {
                access_token = "bad-value"
        }
      };
      
      
      [TestMethod]
      public void WithFluent()
        {
          actual.Should().BeEquivalentTo(expected);
        }
        
      [TestMethod]
      public void WithMsTest()
        {
          Assert.AreEqual(expected, actual);
        }
    }
}
