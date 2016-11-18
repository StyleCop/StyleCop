// <copyright file="FileHeadersValidWithEnumFirst.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>

namespace CSharpAnalyzersTest.TestData.FileHeaders
{
    public enum MyEnum
    {
    }

    public class FileHeadersValidWithEnumFirst
    {
        public MyEnum Example { get; set; }
    }
}
