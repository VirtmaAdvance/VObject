# VObject

<details>

<summary>About</summary>

### What Is VObject?

`VObject` is a C# class library that utilizes the .NET 6.0 framework. It acts as an enhanced `object` where it provides additional `Type` information and operations.
This class was designed to be inherited from and provides additional extension methods for the `object` class.

### How To Use?

Implementing `VObject` is easy and can be done in different ways.
Below are the different ways you can create a new instance of a `VObject`.
```cs
VObject obj = "Hello World";
VObject obj = 10;
var obj = new VObject(new int[] { 0, 1, 2, 3, 4, 5 });
```

</details>

<details>

 <summary>Features</summary>

 ### Object Extension Methods

|Method Name|Details|Example|
|---|---|---|
|IsNull|Determines whether the object is `null` and returns a boolean value where `true` represents that the value is `null`, and `false` if the value is not `null`.|`obj.IsNull();`|
|NotNull|Determines whether the object is not `null` and returns boolean value where `true` represents that the value is not `null`, and `false` if the value is `null`|`obj.NotNull();`|
|IsComObject|Determines whether the object is a `COMObject` and returns a boolean value where `true` represents that the object is a `COMObject`, and `false` if the object is not a `COMObject`.|`obj.IsComObject();`|

</details>
