

### Define json compactly

```csharp
//Defining json compactly: 

var json = new
{
  time = "value",
  date = "good value",
  tokenResponse = new {
    access_token = "value-my"
  }
};

// Using .NET libraries
var jsonString = System.Text.Json.JsonSerializer.Serialize(json);
```



### Read json dynamically

Add newtonsoft 

```
dotnet add Tests/Tests.csproj package Newtonsoft.Json
```



We can use an anonymous object o achive this 

```csharp
// Need newtonsoft for this

var json = new
{
  time = "value",
  date = "good value",
  tokenResponse = new {
    access_token = "value-my"
  }
};

var response = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(jsonString, json);

Assert.Equal(json, response);

// Refer as named field
Assert.Equal("value-my", response.tokenResponse.access_token);
```



### Meaninful Asesertion Failures

Install fluent

```
dotnet add Test/Test.csproj package FluentAssertions
```



Message with fluent assertions `actual.Should().BeEquivalentTo(expected);`

```
Expected member tokenResponse.access_token to be 
"value-my" with a length of 8, but 
"bad-value" has a length of 9, differs near "bad" (index 0).
```



Default mst test outpu :

```
Expected:<{ time = value, date = good value, tokenResponse = { access_token = value-my } }>. Actual:<{ time = value, date = good value, tokenResponse = { access_token = bad-value } }>. 
```



### Todo

- [x] can we deserialize an anonymous object ? (https://www.newtonsoft.com/json/help/html/DeserializeAnonymousType.htm)
- [x] Write json with minimal syntaxes (use anonymouse, awesome)
- [ ] Try json assertions (check failure messages)
- [ ] Compare anonymous objet with json and good assertion failure messages



- [ ] Easily generate ToString(), ToEqual(), Clone()
- [ ] Parse a JSON as object
- [ ] Convert Object to Json
- [ ] Most compact way to define json
- [ ] Covert camelCase json to object
- [ ] Covert object to cameCase json
- [ ] Convert an error/success response from a json input
- [ ] Transform field using a setter with custom logic
- [ ] Newtonsoft vs CSharp lib





Refer: 

- Compact json : https://stackoverflow.com/a/55258532/1065020
- 