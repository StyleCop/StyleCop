using System.Windows;
using System;
using Microsoft.Win32;
using SomeNamespace.SubNamespace;
using X = System.Windows.Forms;

namespace SomeNamespace
{
    using System;
    using Microsoft.Win32;
    using System.Windows;
    using SomeNamespace.SubNamespace;
    using X = System.Windows.Forms;

    namespace SubNamespace
    {
        using System;
        using System.Windows;
        using Microsoft.Win32;
        using X = System.Windows.Forms.Form;
        using Y = System.Text.StringBuilder;
    }
}

namespace OtherNamespace
{
    using System;
    using System.Windows;
    using Microsoft.Win32;
    using SomeNamespace.SubNamespace;
    using Y = System.Text.StringBuilder;
    using X = System.Windows.Forms;
}

namespace OtherNamespace
{
    using System;
    using System.Windows;
    using X = System.Windows.Forms;
    using Microsoft.Win32;
    using SomeNamespace.SubNamespace;
}

namespace OtherNamespace
{
    using System;
    using System.Windows;
    using SomeNamespace.SubNamespace;
    using Microsoft.Win32;
    using X = System.Windows.Forms;
}

namespace Underscores
{
    using ProductMgmt_BusinessObjects;
    using ProductMgmtWeb;
}

namespace UnderscoresInvalid
{
    using ProductMgmtWeb;
    using ProductMgmt_BusinessObjects;
}

namespace CapitalVsLowerValid
{
    using SdTrace = System.Diagnostics.Trace;
    using SZ = System.Diagnostics;
}

namespace CapitalVsLowerInvalid
{
    using SZ = System.Diagnostics;
    using SdTrace = System.Diagnostics.Trace;
}

namespace NamespacesDifferingOnlyByCaseInvalid
{
    // Invalid because Ax should come before AX.
    using Microsoft.Dynamics.AX.Something;
    using Microsoft.Dynamics.Ax.Something;
}

namespace NamespacesDifferingOnlyByCaseValid
{
    // Valid because Ax should come before AX.
    using Microsoft.Dynamics.Ax.Something;
    using Microsoft.Dynamics.AX.Something;
}

namespace NamespacesDifferingByCaseAndSubsequentlyOrderedProperly_Invalid
{
    // Invalid because Ax should come before AX, even though A comes before B.
    using Microsoft.Dynamics.AX.A;
    using Microsoft.Dynamics.Ax.B;
}

namespace NamespacesDifferingByCaseAndSubsequentlyOrderedImproperly_Valid
{
    // Valid because Ax should come before AX, even though A comes before B.
    using Microsoft.Dynamics.Ax.B;
    using Microsoft.Dynamics.AX.A;
}

namespace NamespacesWithGlobalInThem_Valid
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Security;
    using System.Threading;

    using Neovolve.Toolkit.Threading;

    using global::NetSuite.ServiceContracts;

    using VeryGoodCustomer.NetSuite.Service.DataContracts;
}
