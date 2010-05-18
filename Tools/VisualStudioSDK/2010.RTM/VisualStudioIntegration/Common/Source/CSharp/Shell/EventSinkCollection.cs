//------------------------------------------------------------------------------
// <copyright file="LogicalView.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.Collections;
    using System.Diagnostics;

    /// <include file='doc\EventSinkCollection.uex' path='docs/doc[@for="EventSinkCollection"]/*' />
    /// <summary>
    /// Maps objects to and from integer "cookies".  This helps in the implementation
    /// of VS interfaces that have Advise/Unadvise methods, for example, IVsHierarchy,
    /// IVsCfgProvider2, IVsBuildableProjectCfg and so on.
    /// </summary>
    [CLSCompliant(false)]
    public class EventSinkCollection : IEnumerable {
        ArrayList map;

        /// <include file='doc\EventSinkCollection.uex' path='docs/doc[@for="EventSinkCollection.EventSinkCollection"]/*' />
        public EventSinkCollection() {
        }

        ArrayList GetMap() {
            if (this.map == null) this.map = new ArrayList();
            return this.map;
        }

        /// <include file='doc\EventSinkCollection.uex' path='docs/doc[@for="EventSinkCollection.Count"]/*' />
        /// <devdov>
        /// Returns the total number of sinks in the collection.  Some of these might be null though.
        /// </devdov>
        public int Count {
            get { return (this.map == null) ? 0 : this.map.Count; }
        }

        /// <include file='doc\EventSinkCollection.uex' path='docs/doc[@for="EventSinkCollection.Add"]/*' />
        /// <devdov>
        /// Add an event sink and return it's cookie which can be used in the RemoveAt method.
        /// </devdov>
        public uint Add(Object o) {
            if (o == null)
                throw new ArgumentNullException("o");

            // re-use empty slots so the ArrayList doesn't grow infinitely.
            for (int i = 0, n = this.GetMap().Count; i < n; i++) {
                if (map[i] == null) {
                    map[i] = o;
                    return (uint)i+1; // cookie must be one based else VS doesn't call Unadvise
                }
            }
            this.map.Add(o);
            return (uint)this.map.Count;
        }
        /// <include file='doc\EventSinkCollection.uex' path='docs/doc[@for="EventSinkCollection.Remove"]/*' />
        /// <devdov>
        /// Remove the specified event sink from the collection
        /// </devdov>
        public void Remove(Object obj) {
            if (obj == null)
                throw new ArgumentNullException("obj");

            if (this.map != null)
            {
                for (int i = 0, n = map.Count; i < n; i++)
                {
                    if (this.map[i] == obj)
                    {
                        this.map[i] = null; // these gap will be reused.
                        if (i == n - 1)
                        {
                            // compact the array list whenever possible.
                            while (i > 0 && this.map[i - 1] == null)
                            {
                                i--;
                            }
                            this.map.RemoveRange(i, n - i);
                        }
                        return;
                    }
                }
            }
            throw new ArgumentOutOfRangeException("obj");
        }
        /// <include file='doc\EventSinkCollection.uex' path='docs/doc[@for="EventSinkCollection.RemoveAt"]/*' />
        /// <devdov>
        /// Remove the specified event sink by the cookie integer returned from the Add method.
        /// </devdov>
        public void RemoveAt(uint cookie) {
            if (this.map != null){
                this.map[(int)cookie - 1] = null;  // cookie is 1-based
            }
        }
        /// <include file='doc\EventSinkCollection.uex' path='docs/doc[@for="EventSinkCollection.SetAt"]/*' />
        /// <devdov>
        /// Update the event sink associated with the given cookie.
        /// </devdov>
        public void SetAt(uint cookie, object value) {
            this.GetMap()[(int)cookie - 1] = value;
        }
        
        /// <include file='doc\EventSinkCollection.uex' path='docs/doc[@for="EventSinkCollection.this"]/*' />
        /// <devdov>
        /// Indexor access to the event sink.  Cookie is 1-based.
        /// </devdov>
        public object this[uint cookie] {
            get {
                return (this.map != null && cookie > 0 && cookie <= this.map.Count) ? this.map[(int)cookie-1] : null;
            }
            set {
                this.GetMap()[(int)cookie-1] = value;
            }
        }
        /// <include file='doc\EventSinkCollection.uex' path='docs/doc[@for="EventSinkCollection.Clear"]/*' />
        /// <devdov>
        /// Remove all event sinks.
        /// </devdov>
        public void Clear() {
            if (this.map != null) this.map.Clear();
        }

        /// <include file='doc\EventSinkCollection.uex' path='docs/doc[@for="EventSinkCollection.IEnumerable.GetEnumerator"]/*' />
        /// <internalonly/>
        IEnumerator IEnumerable.GetEnumerator() {
            return new EventSinkEnumerator(map);
        }
        internal class EventSinkEnumerator : IEnumerator {
            ArrayList map;            
            int pos;

            public EventSinkEnumerator(ArrayList map) {
                this.map = map; 
                this.pos = -1;
            }
            object IEnumerator.Current {
                get { return (this.map != null && this.pos >= 0 && this.pos < this.map.Count) ? this.map[this.pos] : null; }
            }
            bool IEnumerator.MoveNext() {
                if (this.map == null) return false;
                int n = this.map.Count;
                if (this.pos < n) {
                    this.pos++;
                    while (this.pos < n && this.map[this.pos] == null) // skip nulls
                        this.pos++;

                    if (this.pos < n) {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            void IEnumerator.Reset() {
                this.pos = -1;
            }
        }
    }

}