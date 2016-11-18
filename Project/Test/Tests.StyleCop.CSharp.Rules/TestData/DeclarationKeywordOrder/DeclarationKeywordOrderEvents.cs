using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class DeclarationKeywordOrderEvents
    {
        // Valid events
        event EventHandler ValidEvent1;

        public event EventHandler ValidEvent2;

        internal event EventHandler ValidEvent3;

        protected event EventHandler ValidEvent4;

        protected internal event EventHandler ValidEvent5;

        private event EventHandler ValidEvent6;

        new event EventHandler ValidEvent7;

        public new event EventHandler ValidEvent8;

        internal new event EventHandler ValidEvent9;

        protected new event EventHandler ValidEvent10;

        protected internal new event EventHandler ValidEvent11;

        private new event EventHandler ValidEvent12;

        static event EventHandler ValidEvent13;

        public static event EventHandler ValidEvent14;

        internal static event EventHandler ValidEvent15;

        protected static event EventHandler ValidEvent16;

        protected internal static event EventHandler ValidEvent17;

        private static event EventHandler ValidEvent18;

        virtual event EventHandler ValidEvent19;

        public virtual event EventHandler ValidEvent20;

        internal virtual event EventHandler ValidEvent21;

        protected virtual event EventHandler ValidEvent22;

        protected internal virtual event EventHandler ValidEvent23;

        private virtual event EventHandler ValidEvent24;

        sealed event EventHandler ValidEvent25;

        public sealed event EventHandler ValidEvent26;

        internal sealed event EventHandler ValidEvent27;

        protected sealed event EventHandler ValidEvent28;

        protected internal sealed event EventHandler ValidEvent29;

        private sealed event EventHandler ValidEvent30;

        override event EventHandler ValidEvent31;

        public override event EventHandler ValidEvent32;

        internal override event EventHandler ValidEvent33;

        protected override event EventHandler ValidEvent34;

        protected internal override event EventHandler ValidEvent35;

        private override event EventHandler ValidEvent36;

        abstract event EventHandler ValidEvent37;

        public abstract event EventHandler ValidEvent38;

        internal abstract event EventHandler ValidEvent39;

        protected abstract event EventHandler ValidEvent40;

        protected internal abstract event EventHandler ValidEvent41;

        private abstract event EventHandler ValidEvent42;

        extern event EventHandler ValidEvent43;

        public extern event EventHandler ValidEvent44;

        internal extern event EventHandler ValidEvent45;

        protected extern event EventHandler ValidEvent46;

        protected internal extern event EventHandler ValidEvent47;

        private extern event EventHandler ValidEvent48;

        static new virtual override abstract extern event EventHandler ValidEvent49;

        public static new virtual override abstract extern event EventHandler ValidEvent50;

        internal static virtual new override abstract extern event EventHandler ValidEvent51;

        protected static override virtual new abstract extern event EventHandler ValidEvent52;

        protected internal static abstract override virtual new extern event EventHandler ValidEvent53;

        private static extern abstract override virtual new event EventHandler ValidEvent54;

        // Invalid events
        internal protected event EventHandler InvalidEvent1;

        new public event EventHandler InvalidEvent2;

        new internal event EventHandler InvalidEvent3;

        new protected event EventHandler InvalidEvent4;

        new protected internal event EventHandler InvalidEvent5;

        new internal protected event EventHandler InvalidEvent6;

        internal protected new event EventHandler InvalidEvent7;

        protected new internal event EventHandler InvalidEvent8;

        internal new protected event EventHandler InvalidEvent9;
        
        new private event EventHandler InvalidEvent10;

        static public event EventHandler InvalidEvent11;

        static internal event EventHandler InvalidEvent12;

        static protected event EventHandler InvalidEvent13;

        static protected internal event EventHandler InvalidEvent14;

        static internal protected event EventHandler InvalidEvent15;

        internal protected static event EventHandler InvalidEvent16;

        internal static protected event EventHandler InvalidEvent17;

        protected static internal event EventHandler InvalidEvent18;
        
        static private event EventHandler InvalidEvent19;

        virtual public event EventHandler InvalidEvent20;

        virtual internal event EventHandler InvalidEvent21;

        virtual protected event EventHandler InvalidEvent22;

        virtual protected internal event EventHandler InvalidEvent23;

        virtual internal protected event EventHandler InvalidEvent24;

        internal protected virtual event EventHandler InvalidEvent25;

        internal virtual protected event EventHandler InvalidEvent26;

        protected virtual internal event EventHandler InvalidEvent27;
        
        virtual private event EventHandler InvalidEvent28;

        sealed public event EventHandler InvalidEvent29;

        sealed internal event EventHandler InvalidEvent30;

        sealed protected event EventHandler InvalidEvent31;

        sealed protected internal event EventHandler InvalidEvent32;

        sealed internal protected event EventHandler InvalidEvent33;

        internal protected sealed event EventHandler InvalidEvent34;

        internal sealed protected event EventHandler InvalidEvent35;

        protected sealed internal event EventHandler InvalidEvent36;
        
        sealed private event EventHandler InvalidEvent37;

        override public event EventHandler InvalidEvent38;

        override internal event EventHandler InvalidEvent39;

        override protected event EventHandler InvalidEvent40;

        override protected internal event EventHandler InvalidEvent41;

        override internal protected event EventHandler InvalidEvent42;

        internal protected override event EventHandler InvalidEvent43;

        internal override protected event EventHandler InvalidEvent44;

        protected override internal event EventHandler InvalidEvent45;
        
        override private event EventHandler InvalidEvent46;

        abstract public event EventHandler InvalidEvent47;

        abstract internal event EventHandler InvalidEvent48;

        abstract protected event EventHandler InvalidEvent49;

        abstract protected internal event EventHandler InvalidEvent50;

        abstract internal protected event EventHandler InvalidEvent51;

        internal protected abstract event EventHandler InvalidEvent52;

        internal abstract protected event EventHandler InvalidEvent53;

        protected abstract internal event EventHandler InvalidEvent54;
        
        abstract private event EventHandler InvalidEvent55;

        extern public event EventHandler InvalidEvent56;

        extern internal event EventHandler InvalidEvent57;

        extern protected event EventHandler InvalidEvent58;

        extern protected internal event EventHandler InvalidEvent59;

        extern internal protected event EventHandler InvalidEvent60;

        internal protected extern event EventHandler InvalidEvent61;

        internal extern protected event EventHandler InvalidEvent62;

        protected extern internal event EventHandler InvalidEvent63;
        
        extern private event EventHandler InvalidEvent64;

        new virtual static override abstract extern public event EventHandler InvalidEvent65;

        virtual static new override abstract extern internal event EventHandler InvalidEvent66;

        override virtual static new abstract extern protected event EventHandler InvalidEvent67;

        abstract override virtual static new extern protected internal event EventHandler InvalidEvent68;

        abstract override virtual static new extern internal protected event EventHandler InvalidEvent69;

        internal protected abstract override virtual static new extern event EventHandler InvalidEvent70;

        internal virtual static protected abstract override new extern event EventHandler InvalidEvent71;

        protected abstract override virtual internal static new extern event EventHandler InvalidEvent72;

        internal virtual static abstract override new extern protected event EventHandler InvalidEvent73;

        protected abstract override virtual static new extern internal event EventHandler InvalidEvent74;

        extern abstract override virtual static new private event EventHandler InvalidEvent75;
    }
}
