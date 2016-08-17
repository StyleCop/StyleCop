// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileHeadersValidDingbatItems{TKey,TValue}.cs" company="StyleCop">
// StyleCop
// </copyright>
// <summary>
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleApplication5
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class FileHeadersValidDingbatItems<TKey, TValue> : List<DingbatItem<TKey, TValue>>, IXmlSerializable where TValue : class
    {
    }
}
