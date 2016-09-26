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

            // Should not be allowed to call base.OnCreateControl here since there is not a local implementation.
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

    public class DoNotPrefixCallsWithBaseUnlessLocalImplementationExists2Base
    {
        public void A1<T>(T value)
        {
        }
    }
    
    public class B : DoNotPrefixCallsWithBaseUnlessLocalImplementationExists2Base
    {        
        public new void A1<T>(T value)
        {
            base.A1(value); // This should have base 
            //// base.A1<T>(value); //// This works
        }
    }
}
