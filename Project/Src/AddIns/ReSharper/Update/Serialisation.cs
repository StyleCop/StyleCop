//-----------------------------------------------------------------------
// <copyright file="Serialisation.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------

namespace StyleCop.ReSharper.Update
{
    #region Directives

    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    #endregion

    /// <summary>
    /// Utility that allows you to retrieve and create mock data from XML files containing serialized type instances
    /// </summary>
    public static class Serialisation
    {
        /// <summary>
        /// Deserializes a Type
        /// </summary>
        /// <typeparam name="T">Type to deserialize</typeparam>
        /// <param name="serializedType">serialized version of the type</param>
        /// <returns>DeSerialized version of the type</returns>
        public static T CreateInstance<T>(string serializedType) where T : new()
        {
            var serializer = new XmlSerializer(typeof(T));
            var stream = new StringReader(serializedType);
            XmlReader xmlReader = new XmlTextReader(stream);

            var customType = (T)serializer.Deserialize(xmlReader);

            return customType;
        }
    }
}