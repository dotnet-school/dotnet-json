using System;
using System.Linq;
using AnyDiff.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
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
      
              
      [TestMethod]
      public void CustomWithAnyDiff()
      {
        CompareJson(expected, actual);
      }

      private static void CompareJson(object expected, object actual)
      {
        if (expected.Equals(actual))
        {
          return;
        }

        var diff = expected.Diff(actual);

        var message = string.Join(Environment.NewLine, diff.Select(d =>
                {
                  var message = $"{Environment.NewLine}" +
                                $"expected{d.Path} : {d.RightValue}{Environment.NewLine}" +
                                $"actual{d.Path} : {d.LeftValue}{Environment.NewLine}";
                  return message;
                }
        ));
        throw new ApplicationException(message);
      }
    }
}
