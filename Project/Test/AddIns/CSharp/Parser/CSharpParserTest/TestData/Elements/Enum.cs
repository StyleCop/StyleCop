#region Normal Enums
enum Enum1
{
}

enum Enum2
{
    Item1
}

enum Enum3
{
    Item1,Item2
}

enum Enum4
{
    Item1, Item2,
    Item3
}

enum Enum5 : int
{
    Item1, Item2
}

enum Enum6:uint
{
    Item1=4, 
    Item2 = 4 + 2,
    Item3
}

enum Enum7
{ 
    Item1 = "hello",
    Item2 = @"goodbye" + "see you" + 1
}

#endregion

#region Enum with trailing semicolon
enum EnumWithSemicolon
{
    Item1
};
#endregion

#region Enum with extra comma
enum EnumWithExtraComma
{
    Item1,
    Item2,
}
#endregion

#region Nested enum
class ClassWithNestedEnum1
{
    enum NestedEnum1
    {
        Item2 = 2
    }
}
#endregion

#region Enums with access modifiers

public enum EnumWithAccessModifier1
{
    Item1
}

internal enum EnumWithAccessModifier2
{
    Item1
}

protected enum EnumWithAccessModifier3
{
    Item1
}

protected internal enum EnumWithAccessModifier4
{
    Item1
}

internal protected enum EnumWithAccessModifier5
{
    Item1
}

private enum EnumWithAccessModifier6
{
    Item1
}

#endregion

#region Enums with other modifiers

public class ClassWithNestedEnum2
{
    public new enum EnumWithNewModifier
    {
        Item1
    }
}

#endregion 

#region Enums with Attributes

[Attribute1(false), System.Attribute2(true, 2)]
[Attribute3]
public enum EnumWithAttributes
{
}

#endregion

#region Enums with headers

/// <summary>
/// An enum header.
/// </summary>
public enum EnumWithHeader
{
    /// <summary>
    /// ITem 1 header.
    /// </summary>
    Item1,

    /// <summary>
    /// Item2 header.
    /// </summary>
    Item2
}

#endregion

#region Enums with headers and attributes

/// <summary>
/// An enum header.
/// </summary>
[Attribute1(false), System.Attribute2(true, 2)]
[Attribute3]
public enum EnumWithHeaderAndAttributes
{
    /// <summary>
    /// Item header
    /// </summary>
    Item1
}

#endregion

#region Enums with extra tokens

public enum EnumWithExtraTokens
{
    // extra stuff
    /// <summary>
    /// Item header
    /// </summary>
    // extra stuff
    Item1,
    // extra stuff

    item2 /*extra*/ = /*extra*/ 1 ,

    // extra
}

#endregion
