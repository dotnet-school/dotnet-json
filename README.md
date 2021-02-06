

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



### Read json 

```
// Need newtonsoft for this


```



### Todo

- [ ] can we deserialize an anonymous object ? (https://www.newtonsoft.com/json/help/html/DeserializeAnonymousType.htm)
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