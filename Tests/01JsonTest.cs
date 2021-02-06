using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
      private static string PascalCase = "{" +
                                         "\"Date\":\"2019-08-01T00:00:00-07:00\"," +
                                         "\"TemperatureCelsius\":25," +
                                         "\"Summary\":\"Hot\"," +
                                         "\"DatesAvailable\":[\"2019-08-01T00:00:00-07:00\"," +
                                         "\"2019-08-02T00:00:00-07:00\"],\"TemperatureRanges\":{\"Cold\":{\"High\":20,\"Low\":-10},\"Hot\":{\"High\":60,\"Low\":20}},\"SummaryWords\":[\"Cool\",\"Windy\",\"Humid\"]}";

      public class PascalCaseModel
      {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
        public string SummaryField;
        public IList<DateTimeOffset> DatesAvailable { get; set; }
        public Dictionary<string, PascalNestedHighLowTemps> TemperatureRanges { get; set; }
        public string[] SummaryWords { get; set; }
      }
      
      public class PascalNestedHighLowTemps
      {
        public int High { get; set; }
        public int Low { get; set; }
      }
      
      [Fact]
      public void ShouldSerializeRegularJson()
      {
        var result = System.Text.Json.JsonSerializer.Deserialize<PascalCaseModel>(PascalCase);

        int expected = result?.TemperatureRanges?.GetValueOrDefault("Cold")?.High ?? -1 ;
        
        Assert.Equal(expected, 20);
      }
    }
}
