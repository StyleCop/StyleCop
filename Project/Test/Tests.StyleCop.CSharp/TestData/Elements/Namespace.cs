// Standard namespace.
namespace Namespace1
{
}

// Nested namespace.
namespace Namespace1.Namespace2.Namespace3
{
}

// Namespace over multiple lines.
namespace Namespace3 . Namespace4 .
    Namespace5
{
}

// Namespace with optional semicolon
namespace NamespaceWithSemicolon
{
};

// Namespace with contents
namespace NamespaceWithContents
{
    using System;
}

// Nested namespaces
namespace NestedNamespace1
{
    namespace NestedNamespace2
    {
        namespace NestedNamespace3
        {
            namespace NestedNamespace4
            {
                using System.Globalization;
            }
        }
    }
}