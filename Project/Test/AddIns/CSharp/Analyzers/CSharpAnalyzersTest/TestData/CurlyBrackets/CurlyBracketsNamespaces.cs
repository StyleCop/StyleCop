// Invalid namespaces
namespace InvalidNamespace1 { }
namespace InvalidNamespace2 { using System; } 

namespace InvalidNamespace3 
{
    using System; }

namespace InvalidNamespace4 {
    using System;
}

namespace InvalidNamespace5 {
    using System; }

namespace InvalidNamespace6
{ using System;
}

namespace InvalidNamespace7
{ using System; }

// Valid namespaces
namespace ValidNamespace1
{
}

namespace ValidNamespace2
{
    using System;
}
