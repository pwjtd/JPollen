namespace Example1;

public static class ConstantJsons
{
  public static string TestJson = @"
{
  ""string"": ""Some text"",
  ""number"": 123.45,
  ""boolean"": true,
  ""nullValue"": null,
  ""array"": [
    ""Text in array"",
    42,
    false,
    null,
    {
      ""nestedKey"": ""nested object"",
      ""nestedArray"": [1, 2, 3, ""test""]
    }
  ],
  ""object"": {
    ""keyString"": ""Text in object"",
    ""keyNumber"": 1001,
    ""keyBoolean"": false,
    ""keyNull"": null,
    ""nestedObject"": {
      ""deepKey"": ""deeper object"",
      ""deepArray"": [true, false, 3.14]
    }
  },
  ""emptyArray"": [],
  ""emptyObject"": {},
  ""specialCharacters"": ""!@#$%^&*()_+-=[]{}|;':\\\"",.<>?/`~"",
  ""unicode"": ""🌍 你好 мир"",
  ""escapedCharacters"": ""C:\\\\Users\\\\Example\\\\Path"",
  ""date"": ""2025-01-26T15:30:00Z"",
  ""bigInt"": 123456789012345678901234567890,
  ""mapLikeObject"": {
    ""1"": ""one"",
    ""2"": ""two"",
    ""3"": ""three""
  },
  ""setLikeArray"": [
    ""element1"",
    ""element2"",
    ""element3""
  ],
  ""deepNesting"": {
    ""level1"": {
      ""level2"": {
        ""level3"": {
          ""level4"": {
            ""value"": ""really deep data""
          }
        }
      }
    }
  },
  ""arrayWithObjects"": [
    {""id"": 1, ""name"": ""object1""},
    {""id"": 2, ""name"": ""object2""},
    {""id"": 3, ""name"": ""object3""}
  ]
}";
}