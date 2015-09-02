using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class DeclarationKeywordOrderMethods
    {
        // Valid methods
        bool ValidMethod1()
        {
            return true;
        }

        public bool ValidMethod2()
        {
            return true;
        }

        internal bool ValidMethod3()
        {
            return true;
        }

        protected bool ValidMethod4()
        {
            return true;
        }

        protected internal bool ValidMethod5()
        {
            return true;
        }

        private bool ValidMethod6()
        {
            return true;
        }

        new bool ValidMethod7()
        {
            return true;
        }

        public new bool ValidMethod8()
        {
            return true;
        }

        internal new bool ValidMethod9()
        {
            return true;
        }

        protected new bool ValidMethod10()
        {
            return true;
        }

        protected internal new bool ValidMethod11()
        {
            return true;
        }

        private new bool ValidMethod12()
        {
            return true;
        }

        static bool ValidMethod13()
        {
            return true;
        }

        public static bool ValidMethod14()
        {
            return true;
        }

        internal static bool ValidMethod15()
        {
            return true;
        }

        protected static bool ValidMethod16()
        {
            return true;
        }

        protected internal static bool ValidMethod17()
        {
            return true;
        }

        private static bool ValidMethod18()
        {
            return true;
        }

        virtual bool ValidMethod19()
        {
            return true;
        }

        public virtual bool ValidMethod20()
        {
            return true;
        }

        internal virtual bool ValidMethod21()
        {
            return true;
        }

        protected virtual bool ValidMethod22()
        {
            return true;
        }

        protected internal virtual bool ValidMethod23()
        {
            return true;
        }

        private virtual bool ValidMethod24()
        {
            return true;
        }

        sealed bool ValidMethod25()
        {
            return true;
        }

        public sealed bool ValidMethod26()
        {
            return true;
        }

        internal sealed bool ValidMethod27()
        {
            return true;
        }

        protected sealed bool ValidMethod38()
        {
            return true;
        }

        protected internal sealed bool ValidMethod29()
        {
            return true;
        }

        private sealed bool ValidMethod30()
        {
            return true;
        }

        override bool ValidMethod31()
        {
            return true;
        }

        public override bool ValidMethod32()
        {
            return true;
        }

        internal override bool ValidMethod33()
        {
            return true;
        }

        protected override bool ValidMethod34()
        {
            return true;
        }

        protected internal override bool ValidMethod35()
        {
            return true;
        }

        private override bool ValidMethod36()
        {
            return true;
        }

        abstract bool ValidMethod37();

        public abstract bool ValidMethod38();

        internal abstract bool ValidMethod39();

        protected abstract bool ValidMethod40();

        protected internal abstract bool ValidMethod41();

        private abstract bool ValidMethod42();

        extern bool ValidMethod43();



        public extern bool ValidMethod44();



        internal extern bool ValidMethod45();



        protected extern bool ValidMethod46();



        protected internal extern bool ValidMethod47();



        private extern bool ValidMethod48();



        unsafe bool ValidMethod49()
        {
            return true;
        }

        public unsafe bool ValidMethod50()
        {
            return true;
        }

        internal unsafe bool ValidMethod51()
        {
            return true;
        }

        protected unsafe bool ValidMethod52()
        {
            return true;
        }

        protected internal unsafe bool ValidMethod53()
        {
            return true;
        }

        private unsafe bool ValidMethod54()
        {
            return true;
        }

        static new unsafe virtual override abstract extern bool ValidMethod55();

        public static unsafe new virtual override abstract extern bool ValidMethod56();

        internal static virtual unsafe new override abstract extern bool ValidMethod57();

        protected static override virtual new unsafe abstract extern bool ValidMethod58();

        protected internal static abstract override virtual new extern unsafe bool ValidMethod59();

        private static extern abstract unsafe override virtual new bool ValidMethod60();







        // Invalid methods
        internal protected bool InvalidMethod1()
        {
            return true;
        }

        new public bool InvalidMethod2()
        {
            return true;
        }

        new internal bool InvalidMethod3()
        {
            return true;
        }

        new protected bool InvalidMethod4()
        {
            return true;
        }

        new protected internal bool InvalidMethod5()
        {
            return true;
        }

        new internal protected bool InvalidMethod6()
        {
            return true;
        }

        internal protected new bool InvalidMethod7()
        {
            return true;
        }

        protected new internal bool InvalidMethod8()
        {
            return true;
        }

        internal new protected bool InvalidMethod9()
        {
            return true;
        }

        new private bool InvalidMethod10()
        {
            return true;
        }

        static public bool InvalidMethod11()
        {
            return true;
        }

        static internal bool InvalidMethod12()
        {
            return true;
        }

        static protected bool InvalidMethod13()
        {
            return true;
        }

        static protected internal bool InvalidMethod14()
        {
            return true;
        }

        static internal protected bool InvalidMethod15()
        {
            return true;
        }

        internal protected static bool InvalidMethod16()
        {
            return true;
        }

        internal static protected bool InvalidMethod17()
        {
            return true;
        }

        protected static internal bool InvalidMethod18()
        {
            return true;
        }

        static private bool InvalidMethod19()
        {
            return true;
        }

        virtual public bool InvalidMethod20()
        {
            return true;
        }

        virtual internal bool InvalidMethod21()
        {
            return true;
        }

        virtual protected bool InvalidMethod22()
        {
            return true;
        }

        virtual protected internal bool InvalidMethod23()
        {
            return true;
        }

        virtual internal protected bool InvalidMethod24()
        {
            return true;
        }

        internal protected virtual bool InvalidMethod25()
        {
            return true;
        }

        internal virtual protected bool InvalidMethod26()
        {
            return true;
        }

        protected virtual internal bool InvalidMethod27()
        {
            return true;
        }

        virtual private bool InvalidMethod28()
        {
            return true;
        }

        sealed public bool InvalidMethod29()
        {
            return true;
        }

        sealed internal bool InvalidMethod30()
        {
            return true;
        }

        sealed protected bool InvalidMethod31()
        {
            return true;
        }

        sealed protected internal bool InvalidMethod32()
        {
            return true;
        }

        sealed internal protected bool InvalidMethod33()
        {
            return true;
        }

        internal protected sealed bool InvalidMethod34()
        {
            return true;
        }

        internal sealed protected bool InvalidMethod35()
        {
            return true;
        }

        protected sealed internal bool InvalidMethod36()
        {
            return true;
        }

        sealed private bool InvalidMethod37()
        {
            return true;
        }

        override public bool InvalidMethod38()
        {
            return true;
        }

        override internal bool InvalidMethod39()
        {
            return true;
        }

        override protected bool InvalidMethod40()
        {
            return true;
        }

        override protected internal bool InvalidMethod41()
        {
            return true;
        }

        override internal protected bool InvalidMethod42()
        {
            return true;
        }

        internal protected override bool InvalidMethod43()
        {
            return true;
        }

        internal override protected bool InvalidMethod44()
        {
            return true;
        }

        protected override internal bool InvalidMethod45()
        {
            return true;
        }

        override private bool InvalidMethod46()
        {
            return true;
        }

        abstract public bool InvalidMethod47();

        abstract internal bool InvalidMethod48();

        abstract protected bool InvalidMethod49();

        abstract protected internal bool InvalidMethod50();

        abstract internal protected bool InvalidMethod51();

        internal protected abstract bool InvalidMethod52();

        internal abstract protected bool InvalidMethod53();

        protected abstract internal bool InvalidMethod54();

        abstract private bool InvalidMethod55();

        extern public bool InvalidMethod56();



        
        extern internal bool InvalidMethod57();




        extern protected bool InvalidMethod58();



        
        extern protected internal bool InvalidMethod59();



        
        extern internal protected bool InvalidMethod60();



        
        internal protected extern bool InvalidMethod61();



        
        internal extern protected bool InvalidMethod62();



        
        protected extern internal bool InvalidMethod63();



        
        extern private bool InvalidMethod64();



        
        unsafe public bool InvalidMethod65()
        {
            return true;
        }

        unsafe internal bool InvalidMethod66()
        {
            return true;
        }

        unsafe protected bool InvalidMethod67()
        {
            return true;
        }

        unsafe protected internal bool InvalidMethod68()
        {
            return true;
        }

        unsafe internal protected bool InvalidMethod69()
        {
            return true;
        }

        internal protected unsafe bool InvalidMethod70()
        {
            return true;
        }

        protected unsafe internal bool InvalidMethod71()
        {
            return true;
        }

        internal unsafe protected bool InvalidMethod72()
        {
            return true;
        }

        unsafe private bool InvalidMethod73()
        {
            return true;
        }

        unsafe new virtual static override abstract extern public bool InvalidMethod74();

        virtual static new unsafe override abstract extern internal bool InvalidMethod75();

        override virtual static new abstract unsafe extern protected bool InvalidMethod76();

        abstract override virtual static unsafe new extern protected internal bool InvalidMethod77();

        abstract override unsafe virtual static new extern internal protected bool InvalidMethod78();

        internal protected abstract unsafe override virtual static new extern bool InvalidMethod79();

        internal virtual static protected abstract override new extern unsafe bool InvalidMethod80();

        protected abstract unsafe override virtual internal static new extern bool InvalidMethod81();

        internal unsafe virtual static abstract override new extern protected bool InvalidMethod82();

        protected abstract override unsafe virtual static new extern internal bool InvalidMethod83();

        extern abstract override virtual static unsafe new private bool InvalidMethod84();
    }
}
