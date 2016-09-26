using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class DeclarationKeywordOrderProperties
    {
        // Valid properties
        bool ValidProperty1
        {
            get { return true; }
        }

        public bool ValidProperty2
        {
            get { return true; }
        }

        internal bool ValidProperty3
        {
            get { return true; }
        }

        protected bool ValidProperty4
        {
            get { return true; }
        }

        protected internal bool ValidProperty5
        {
            get { return true; }
        }

        private bool ValidProperty6
        {
            get { return true; }
        }

        new bool ValidProperty7
        {
            get { return true; }
        }

        public new bool ValidProperty8
        {
            get { return true; }
        }

        internal new bool ValidProperty9
        {
            get { return true; }
        }

        protected new bool ValidProperty10
        {
            get { return true; }
        }

        protected internal new bool ValidProperty11
        {
            get { return true; }
        }

        private new bool ValidProperty12
        {
            get { return true; }
        }

        static bool ValidProperty13
        {
            get { return true; }
        }

        public static bool ValidProperty14
        {
            get { return true; }
        }

        internal static bool ValidProperty15
        {
            get { return true; }
        }

        protected static bool ValidProperty16
        {
            get { return true; }
        }

        protected internal static bool ValidProperty17
        {
            get { return true; }
        }

        private static bool ValidProperty18
        {
            get { return true; }
        }

        virtual bool ValidProperty19
        {
            get { return true; }
        }

        public virtual bool ValidProperty20
        {
            get { return true; }
        }

        internal virtual bool ValidProperty21
        {
            get { return true; }
        }

        protected virtual bool ValidProperty22
        {
            get { return true; }
        }

        protected internal virtual bool ValidProperty23
        {
            get { return true; }
        }

        private virtual bool ValidProperty24
        {
            get { return true; }
        }

        sealed bool ValidProperty25
        {
            get { return true; }
        }

        public sealed bool ValidProperty26
        {
            get { return true; }
        }

        internal sealed bool ValidProperty27
        {
            get { return true; }
        }

        protected sealed bool ValidProperty38
        {
            get { return true; }
        }

        protected internal sealed bool ValidProperty29
        {
            get { return true; }
        }

        private sealed bool ValidProperty30
        {
            get { return true; }
        }

        override bool ValidProperty31
        {
            get { return true; }
        }

        public override bool ValidProperty32
        {
            get { return true; }
        }

        internal override bool ValidProperty33
        {
            get { return true; }
        }

        protected override bool ValidProperty34
        {
            get { return true; }
        }

        protected internal override bool ValidProperty35
        {
            get { return true; }
        }

        private override bool ValidProperty36
        {
            get { return true; }
        }

        abstract bool ValidProperty37
        {
            get { return true; }
        }

        public abstract bool ValidProperty38
        {
            get { return true; }
        }

        internal abstract bool ValidProperty39
        {
            get { return true; }
        }

        protected abstract bool ValidProperty40
        {
            get { return true; }
        }

        protected internal abstract bool ValidProperty41
        {
            get { return true; }
        }

        private abstract bool ValidProperty42
        {
            get { return true; }
        }

        extern bool ValidProperty43
        {
            get { return true; }
        }

        public extern bool ValidProperty44
        {
            get { return true; }
        }

        internal extern bool ValidProperty45
        {
            get { return true; }
        }

        protected extern bool ValidProperty46
        {
            get { return true; }
        }

        protected internal extern bool ValidProperty47
        {
            get { return true; }
        }

        private extern bool ValidProperty48
        {
            get { return true; }
        }

        unsafe bool ValidProperty49
        {
            get { return true; }
        }

        public unsafe bool ValidProperty50
        {
            get { return true; }
        }

        internal unsafe bool ValidProperty51
        {
            get { return true; }
        }

        protected unsafe bool ValidProperty52
        {
            get { return true; }
        }

        protected internal unsafe bool ValidProperty53
        {
            get { return true; }
        }

        private unsafe bool ValidProperty54
        {
            get { return true; }
        }

        static new unsafe virtual override abstract extern bool ValidProperty55
        {
            get { return true; }
        }

        public static unsafe new virtual override abstract extern bool ValidProperty56
        {
            get { return true; }
        }

        internal static virtual unsafe new override abstract extern bool ValidProperty57
        {
            get { return true; }
        }

        protected static override virtual new unsafe abstract extern bool ValidProperty58
        {
            get { return true; }
        }

        protected internal static abstract override virtual new extern unsafe bool ValidProperty59
        {
            get { return true; }
        }

        private static extern abstract unsafe override virtual new bool ValidProperty60
        {
            get { return true; }
        }

        // Invalid properties
        internal protected bool InvalidProperty1
        {
            get { return true; }
        }

        new public bool InvalidProperty2
        {
            get { return true; }
        }

        new internal bool InvalidProperty3
        {
            get { return true; }
        }

        new protected bool InvalidProperty4
        {
            get { return true; }
        }

        new protected internal bool InvalidProperty5
        {
            get { return true; }
        }

        new internal protected bool InvalidProperty6
        {
            get { return true; }
        }

        internal protected new bool InvalidProperty7
        {
            get { return true; }
        }

        protected new internal bool InvalidProperty8
        {
            get { return true; }
        }

        internal new protected bool InvalidProperty9
        {
            get { return true; }
        }
        
        new private bool InvalidProperty10
        {
            get { return true; }
        }

        static public bool InvalidProperty11
        {
            get { return true; }
        }

        static internal bool InvalidProperty12
        {
            get { return true; }
        }

        static protected bool InvalidProperty13
        {
            get { return true; }
        }

        static protected internal bool InvalidProperty14
        {
            get { return true; }
        }

        static internal protected bool InvalidProperty15
        {
            get { return true; }
        }

        internal protected static bool InvalidProperty16
        {
            get { return true; }
        }

        internal static protected bool InvalidProperty17
        {
            get { return true; }
        }

        protected static internal bool InvalidProperty18
        {
            get { return true; }
        }
        
        static private bool InvalidProperty19
        {
            get { return true; }
        }

        virtual public bool InvalidProperty20
        {
            get { return true; }
        }

        virtual internal bool InvalidProperty21
        {
            get { return true; }
        }

        virtual protected bool InvalidProperty22
        {
            get { return true; }
        }

        virtual protected internal bool InvalidProperty23
        {
            get { return true; }
        }

        virtual internal protected bool InvalidProperty24
        {
            get { return true; }
        }

        internal protected virtual bool InvalidProperty25
        {
            get { return true; }
        }

        internal virtual protected bool InvalidProperty26
        {
            get { return true; }
        }

        protected virtual internal bool InvalidProperty27
        {
            get { return true; }
        }
        
        virtual private bool InvalidProperty28
        {
            get { return true; }
        }

        sealed public bool InvalidProperty29
        {
            get { return true; }
        }

        sealed internal bool InvalidProperty30
        {
            get { return true; }
        }

        sealed protected bool InvalidProperty31
        {
            get { return true; }
        }

        sealed protected internal bool InvalidProperty32
        {
            get { return true; }
        }

        sealed internal protected bool InvalidProperty33
        {
            get { return true; }
        }

        internal protected sealed bool InvalidProperty34
        {
            get { return true; }
        }

        internal sealed protected bool InvalidProperty35
        {
            get { return true; }
        }

        protected sealed internal bool InvalidProperty36
        {
            get { return true; }
        }
        
        sealed private bool InvalidProperty37
        {
            get { return true; }
        }

        override public bool InvalidProperty38
        {
            get { return true; }
        }

        override internal bool InvalidProperty39
        {
            get { return true; }
        }

        override protected bool InvalidProperty40
        {
            get { return true; }
        }

        override protected internal bool InvalidProperty41
        {
            get { return true; }
        }

        override internal protected bool InvalidProperty42
        {
            get { return true; }
        }

        internal protected override bool InvalidProperty43
        {
            get { return true; }
        }

        internal override protected bool InvalidProperty44
        {
            get { return true; }
        }

        protected override internal bool InvalidProperty45
        {
            get { return true; }
        }
        
        override private bool InvalidProperty46
        {
            get { return true; }
        }

        abstract public bool InvalidProperty47
        {
            get { return true; }
        }

        abstract internal bool InvalidProperty48
        {
            get { return true; }
        }

        abstract protected bool InvalidProperty49
        {
            get { return true; }
        }

        abstract protected internal bool InvalidProperty50
        {
            get { return true; }
        }

        abstract internal protected bool InvalidProperty51
        {
            get { return true; }
        }

        internal protected abstract bool InvalidProperty52
        {
            get { return true; }
        }

        internal abstract protected bool InvalidProperty53
        {
            get { return true; }
        }

        protected abstract internal bool InvalidProperty54
        {
            get { return true; }
        }
        
        abstract private bool InvalidProperty55
        {
            get { return true; }
        }

        extern public bool InvalidProperty56
        {
            get { return true; }
        }

        extern internal bool InvalidProperty57
        {
            get { return true; }
        }

        extern protected bool InvalidProperty58
        {
            get { return true; }
        }

        extern protected internal bool InvalidProperty59
        {
            get { return true; }
        }

        extern internal protected bool InvalidProperty60
        {
            get { return true; }
        }

        internal protected extern bool InvalidProperty61
        {
            get { return true; }
        }

        internal extern protected bool InvalidProperty62
        {
            get { return true; }
        }

        protected extern internal bool InvalidProperty63
        {
            get { return true; }
        }
        
        extern private bool InvalidProperty64
        {
            get { return true; }
        }

        unsafe public bool InvalidProperty65
        {
            get { return true; }
        }

        unsafe internal bool InvalidProperty66
        {
            get { return true; }
        }

        unsafe protected bool InvalidProperty67
        {
            get { return true; }
        }

        unsafe protected internal bool InvalidProperty68
        {
            get { return true; }
        }

        unsafe internal protected bool InvalidProperty69
        {
            get { return true; }
        }

        internal protected unsafe bool InvalidProperty70
        {
            get { return true; }
        }

        protected unsafe internal bool InvalidProperty71
        {
            get { return true; }
        }

        internal unsafe protected bool InvalidProperty72
        {
            get { return true; }
        }

        unsafe private bool InvalidProperty73
        {
            get { return true; }
        }

        unsafe new static virtual override abstract extern public bool InvalidProperty74
        {
            get { return true; }
        }

        virtual static new unsafe override abstract extern internal bool InvalidProperty75
        {
            get { return true; }
        }

        override virtual static new abstract unsafe extern protected bool InvalidProperty76
        {
            get { return true; }
        }

        abstract override virtual static unsafe new extern protected internal bool InvalidProperty77
        {
            get { return true; }
        }

        abstract override unsafe virtual static new extern internal protected bool InvalidProperty78
        {
            get { return true; }
        }

        internal protected abstract unsafe override virtual static new extern bool InvalidProperty79
        {
            get { return true; }
        }

        internal virtual static protected abstract override new extern unsafe bool InvalidProperty80
        {
            get { return true; }
        }

        protected abstract unsafe override virtual internal static new extern bool InvalidProperty81
        {
            get { return true; }
        }

        internal unsafe virtual static abstract override new extern protected bool InvalidProperty82
        {
            get { return true; }
        }

        protected abstract override unsafe virtual static new extern internal bool InvalidProperty83
        {
            get { return true; }
        }

        extern abstract override virtual static unsafe new private bool InvalidProperty84
        {
            get { return true; }
        }
    }
}
