# jktoiuhito.Utility
[![Build status](https://ci.appveyor.com/api/projects/status/y8hmn87hrh9mt1kc?svg=true)](https://ci.appveyor.com/project/jktoiuhito/jktoiuhito-utility)
[![Nuget](https://img.shields.io/nuget/v/jktoiuhito.Utility)](https://www.nuget.org/packages/jktoiuhito.Utility/)

This is a collection of helper classes and methods I've found to be useful in other projects. The project is developed on the principle of zero external dependencies, so that it could be used on maximal amount of other projects.

## Requirements

Main package: .NET Standard 2.0

Tests: .NET Core 3.0

Support for .NET Standard 2.1 will be added when Azure starts supporting .NET Core 3.0

## Installation

Via package-manager console

`Install-Package jktoiuhito.Utility`

## Usage

Here are usage instructions for every method and class per package.

### jtkoiuhito.Utility.Extensions

#### Json

JSON-related extensions using System.Runtime.Serialization.Json.DataContractJsonSerializer.

```csharp
//Serialize an object to JSON formatted string.
string jsonString = obj.ToJson();

//Deserialize an object from JSON formatted string.
MyDataObject obj = str.FromJson<MyDataObject>();

//Deserialize an object from JSON contained in a Stream.
MyDataObject obj = stream.FromJson<MyDataObject>();
```

#### String

String-extensions related to emptiness and whitespace checks and related exceptions.

```csharp
//Check that a string is not null, empty or whitespace, and throw a fitting exception if it is.
//Return the input string if it passes the checks.

string checkedString = inputString.NotNullEmptyWhitespace();
```

### jktoiuhito.Utility.Hateoas

Classes for making HATEOAS-links easy to operate on.

```csharp
//Create a new HATEOAS-link with a href from a string and rel of "example"
HateoasLink link = new HateoasLink("https://www.example.com", "example");

//Create a new HATEOAS-link with href from a Uri and rel of "example"
HateoasLink link = new HateoasLink(new Uri("https://www.example.com"), "example");

//Create a new HATEOAS-link with href from a string and rel of "self"
HateoasLink link = HateoasLink.Self("https://www.example.com");

//Create a new HATEOAS-link with href from a Uri and rel of "self"
HateoasLink link = HateoasLink.Self(new Uri("https://www.example.com"));
```

The `HateoasResponse`-class can be used as a base-class for all responses containing HATEOAS-links, or used on its own if the response should only contain HATEOAS-links.

```csharp
class DataObject : HateoasResponse
{
    //This class contains a collection of HateoasLinks, and one own value.
    
    public readonly string Value;
    
    public DataObject (string value, IEnumerable<HateoasLink> links) : base(links)
    {
        Value = value;
    }
}

IEnumerable<HateoasLink> links = new[]
{
    new HateoasLink("https://www.example.com/", "example")
};

//Create a response which only contains HATEOAS-links
HateoasResponse response = new HateoasResponse(links);

//Create a DataObject which contains HateoasLinks and an own value
DataObject = new DataObject("hello world!", links)
```

The responses above would be serialized as following:

```json
{
  "links":
  [
    { "href":"https://www.example.com/", "rel":"example" }
  ]
}

{
  "Value":"hello world!"
  "links":
  [
    { "href":"https://www.example.com/", "rel":"example" }
  ]
}
``` 

The `HateoasLinkWrapper` is a generic class which contains HateoasLinks and an object. It can be used, for example, to neatly serialize HATEOAS-links common to all elements of a collection by wrapping the collection in the `HateoasLinkWrapper`.

```csharp
var content = new List<DataObject>
{
    //Each individual DataObject is created and given its own HateoasLinks
};

var commonLinks = new List<HateoasLink>
{
    //HateoasLinks common to all the elements in the collection are created here
};

//The elements and the common links are brought together.
var response = new HateoasLinkWrapper<SerializableObject>(content, commonLinks);
```

The response above would be serialized as following:

```json
TODO!
```
