class C
{
    public static int? AsOptionalInt32(this XAttribute attribute)
    {
        return attribute != null ? int.Parse(attribute.Value) as int? : null;
    }
}