using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CSharpAnalyzersTest.TestData
{
    public class DoNotPrefixCallsWithBaseUnlessLocalImplementationExists : Control
    {
        // Override a base class method and call two base class methods.
        protected override void OnLoad()
        {
            // Should be allowed to call base.OnLoad here since there is a local implementation.
            base.OnLoad();

            // Should not be allowed to call base.OnLoad here since there is not a local implementation.
            base.OnCreateControl();
        }

        // Create a new method and call two base class methods.
        public void Method()
        {
            // Should be allowed to call base.OnLoad here since there is a local implementation.
            base.OnLoad();

            // Should not be allowed to call base.OnLoad here since there is not a local implementation.
            base.OnCreateControl();
        }
    }
}
