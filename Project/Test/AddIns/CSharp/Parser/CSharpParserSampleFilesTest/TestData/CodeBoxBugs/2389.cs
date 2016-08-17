class Class1
{
    public static void SetCustomProperties(object obj, IEnumerable<PropertyInfo> properties, XElement data)
    {
        foreach (var xmlProperty in data.Descendants("CustomProperty"))
        {
            string propertyName = xmlProperty.Attribute("Name").Value;
            PropertyInfo propertyInfo = properties.Where(info => info.Name == propertyName).First();
        }
    }
}
