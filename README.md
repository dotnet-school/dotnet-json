

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



```
  Error Message:
   Test method Tests.JsonAssertions.CustomWithAnyDiff threw exception:
System.ApplicationException:
expected.tokenResponse.access_token : bad-value
actual.tokenResponse.access_token : value-my

  Stack Trace:
      at Tests.JsonAssertions.CompareJson(Object expected, Object actual) in /Users/dawn/projects/dotnet-school/dotnet-json/Test/04JsonAssertions.cs:line 70
   at Tests.JsonAssertions.CustomWithAnyDiff() in /Users/dawn/projects/dotnet-school/dotnet-json/Test/04JsonAssertions.cs:line 49
```





Message with fluent assertions `actual.Should().BeEquivalentTo(expected);`

```
 Error Message:
   Expected member tokenResponse.access_token to be
"value-my" with a length of 8, but
"bad-value" has a length of 9, differs near "bad" (index 0).

With configuration:
- Use declared types and members
- Compare enums by value
- Match member by name (or throw)
- Without automatic conversion.
- Be strict about the order of items in byte arrays

  Stack Trace:
     at FluentAssertions.Execution.LateBoundTestFramework.Throw(String message)
   at FluentAssertions.Execution.TestFrameworkProvider.Throw(String message)
   at FluentAssertions.Execution.CollectingAssertionStrategy.ThrowIfAny(IDictionary`2 context)
   at FluentAssertions.Equivalency.EquivalencyValidator.AssertEquality(EquivalencyValidationContext context)
   at FluentAssertions.Primitives.ObjectAssertions.BeEquivalentTo[TExpectation](TExpectation expectation, Func`2 config, String because, Object[] becauseArgs)
   at FluentAssertions.Primitives.ObjectAssertions.BeEquivalentTo[TExpectation](TExpectation expectation, String because, Object[] becauseArgs)
   at Tests.JsonAssertions.WithFluent() in /Users/dawn/projects/dotnet-school/dotnet-json/Test/04JsonAssertions.cs:line 36
```



Default mst test outpu :

```
  Error Message:
   Assert.AreEqual failed. Expected:<{ time = value, date = good value, tokenResponse = { access_token = value-my } }>. Actual:<{ time = value, date = good value, tokenResponse = { access_token = bad-value } }>.
  Stack Trace:
     at Tests.JsonAssertions.WithMsTest() in /Users/dawn/projects/dotnet-school/dotnet-json/Test/04JsonAssertions.cs:line 42
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