[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT) ![Built With C#](https://img.shields.io/badge/Built_with-C%23-green.svg)

# ChilliSource.Mobile.Core #

This project is part of the ChilliSource framework developed by [BlueChilli](https://github.com/BlueChilli).

## Summary ##

ChilliSoure.Mobile.Core is a collection of .NET Standard helpers, extensions, and abstractions that are shared across all .NET based ChilliSource.Mobile frameworks. 

## Main Features ##

### Optionals ###

Optionals provide a way of explicitly distinguishing between a variable's state of being empty or having a value, thereby preventing null reference exceptions.
Optionals can be applied to both value and reference types and provide convenience methods for conversion, comparison, Linq usage, and functional programming.

**Creating optional values**

```csharp
var some = Option<int>.Some(10);

var none = Option<int>.None;
//none is equal to Option.None;

none = 12;
//none is now the equivalent of Option<int>.Some(12)
```

**Null Conversion**

In both of the following examples the variables will be equal to ```Option.None```:

```csharp
Option<string> none = null;
//none is equal to Option.None

var list = new List<string>();
Option<string> first = list.FirstOrDefault();
//first is equal to Option.None
```                        

**Comparison**

Operator overloads allow for direct comparison:

```csharp
var some = Option<int>.Some(10);
if (some == 10)
{
    //do something
}
```

**Accessing and checking for the value directly**

Use the following properties and methods to check for the value and access the value directly:

```csharp
var some = Option<int>.Some(10);

some.Value;
some.Unwrap();
some.HasValue;
some.HasNoValue;
some.IsNone;
some.IsSome;
some.IfSome((value) => { });
some.IfNone(() => { });
```

**Linq support**

You can use the following Linq functions with Optionals:

```
Where, Select, SelectMany, ForEach, SelectAsync, MapAsync, SelectManyAsync, ForeachAsync
```

### Method Results ###

Use the ```OperationResult``` class as the return type of a method to easily handle different outcomes of the method. Typically a method would either execute successfully or result in an error, but these different states are often difficult to manage in an elegant way. The ```ServiceResult``` class can be used in a similar way when working with Http service calls.

Basic usage:

```csharp
public OperationResult MyMethod()
{
    //do useful stuff here
    
    if (everythingWentWell)
    {
        return OperationResult.AsSuccess();
    }
    else
    {
        return OperationResult.AsFailure("Something went wrong");
    }
}
```

Exception handling:

```csharp
public OperationResult MyMethod()
{
    try
    {
        //do useful stuff here
         return OperationResult.AsSuccess();
    }
    catch (Exception ex)
    {
        return OperationResult.AsFailure(ex);
    }    
}
```

Use the generic version of ```OperationResult``` to return a custom result:

```csharp
public OperationResult<CustomData> MyMethod()
{
    try
    {
        //do useful stuff here

         var customData = new CustomData();
         return OperationResult<CustomData>.AsSuccess(customData);
    }
    catch (Exception ex)
    {
        return OperationResult<CustomData>.AsFailure(ex);
    }    
}
```

Calling code example:

```csharp
var result = MyMethod();
if (result.IsSuccessful)
{
    var customData = result.Result;
    //do something with the custom data.
}
else if (result.IsFailure)
{
    Console.WriteLine(result.Exception.Message);
}
```

#### File System Management ####

Use the ```FileSystemManager``` and ```FilePathFactory``` classes to access file system convenience methods, such as:

```csharp
//Returns the path to the platform's default documents folder
FileSystemManager.GetDocumentsPath();

//Creates a subfolder in the platform's default documents folder
FileSystemManager.CreateDocumentsSubfolder(subFolderName);

//Returns the path to the platform's app bundle
FileSystemManager.GetApplicationBundlePath();

//Replaces characters that cannot be used in file names from the specified fileName with the specified replacement
FileSystemManager.ReplaceInvalidFileCharacters(fileName, replacement);

//Reads the contents of a text file stored in the app's bundle based on the specified relativePathToFile
FileSystemManager.GetBundledTextFileContent(relativePathToFile);

//Constructs a file path for the specified fileName relative to the platform's documents folder
FilePathFactory.BuildDocumentPath(fileName);

//Constructs a file path for the specified fileName relative to the platform's temporary folder
FilePathFactory.BuildTempPath(fileName);
```

## Installation ##

The library is available via NuGet [here](https://www.nuget.org/packages/ChilliSource.Mobile.Core).

## Releases ##

See the [releases](https://github.com/BlueChilli/ChilliSource.Mobile.Core/releases).

### Contribution ###

Please see the [Contribution Guide](.github/CONTRIBUTING.md).

### License ###

ChilliSource.Mobile is licensed under the [MIT license](LICENSE).

### Feedback and Contact ###

For questions or feedback, please contact [chillisource@bluechilli.com](mailto:chillisource@bluechilli.com).


