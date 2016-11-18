// <copyright file="IFileHeadersValidMultipleTypes.cs" company="...">
// Copyright (c) ...
// </copyright>

namespace CSharpAnalyzersTest.TestData.FileHeaders
{
    using System;
    using System.Diagnostics.Contracts;

    [type: ContractClass(typeof(IFileHeadersValidMultipleTypesContract))]
    public interface IFileHeadersValidMultipleTypes
    {
    }

    [type: ContractClassFor(typeof(IFileHeadersValidMultipleTypes))]
    internal abstract class IFileHeadersValidMultipleTypesContract : IFileHeadersValidMultipleTypes
    {
    }
}