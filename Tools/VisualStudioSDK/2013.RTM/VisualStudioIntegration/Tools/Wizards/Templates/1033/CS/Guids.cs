// Guids.cs
// MUST match guids.h
using System;

namespace %ProjectNamespace%.%ProjectClass%
{
    static class GuidList
    {
        public const string guid%ProjectClass%PkgString = "%PackageGuid%";
        public const string guid%ProjectClass%CmdSetString = "%CmdSetGuid%";
%ToolWindowItemStart%        public const string guidToolWindowPersistanceString = "%ToolGuid%";
%ToolWindowItemEnd%%EditorStart%        public const string guid%ProjectClass%EditorFactoryString = "%FactoryGuid%";
%EditorEnd%
        public static readonly Guid guid%ProjectClass%CmdSet = new Guid(guid%ProjectClass%CmdSetString);
%EditorStart%        public static readonly Guid guid%ProjectClass%EditorFactory = new Guid(guid%ProjectClass%EditorFactoryString);
%EditorEnd%    };
}