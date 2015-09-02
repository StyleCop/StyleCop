using System;
using System.Text;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Test.Client.Tools;

namespace ToolsUTests
{

    /// <summary>
    /// Unit tests for class SafeReference.
    /// </summary>
    [TestClass]
    public class SafeReferenceTest
    {
        private MySafeReference safeRef;

        private class MyObject
        {
            internal String Field;
        }

        private class MySafeReference : SafeReference<MyObject>
        {
            internal MyObject GetReference()
            {
                return base.Get();
            }
        }

        [TestInitialize]
        public void Setup()
        {
            this.safeRef = new MySafeReference();
        }

        [TestMethod, Owner("altarase")]
        public void TestSyncNotNullNotCalledForNull()
        {
            this.CallAccessLockedNotNull();
            Assert.IsNull(safeRef.GetReference());
        }

        [TestMethod, Owner("altarase")]
        public void TestSyncNotNullIsCalledForNotNull()
        {
            this.CallSetLocked();
            this.AssertFieldEquals("SyncSet");

            this.CallAccessLockedNotNull();
            this.AssertFieldEquals("SyncNotNull");
        }

        [TestMethod, Owner("altarase")]
        public void TestAsyncIsCalled()
        {
            var state = "initial";
            this.safeRef.Access(o =>
            {
                state = "async";
            });
            Assert.AreEqual(state, "async");

            this.CallSetLocked();
            this.AssertFieldEquals("SyncSet");

            this.CallAccess();
            this.AssertFieldEquals("Async");
        }


        [TestMethod, Owner("altarase")]
        public void TestConcurrentAccess()
        {
            this.CallSetLocked();
            this.AssertFieldEquals("SyncSet");

            var anotherThread = new Thread(() =>
            {
                this.CallAccessLockedNotNull();
            });

            // access reference managered my safeRef from two threads: this and some another
            // start another thread and wait until it is locked
            // check that another thread was not able to access the reference
            this.safeRef.AccessLockedNotNull(o =>
            {
                o.Field = "Another thread cannot access the reference";

                anotherThread.Start();

                while (anotherThread.ThreadState == ThreadState.Running)
                    Thread.Sleep(0);

                Assert.AreEqual(ThreadState.WaitSleepJoin, anotherThread.ThreadState);
                this.AssertFieldEquals("Another thread cannot access the reference");
            });

            // check that another thread finally managed to access the reference
            anotherThread.Join();
            this.AssertFieldEquals("SyncNotNull");
        }

        private void CallSetLocked()
        {
            this.safeRef.SetLocked(() => new MyObject { Field = "SyncSet" });
        }

        private void CallAccessLockedNotNull()
        {
            this.safeRef.AccessLockedNotNull(o =>
            {
                o.Field = "SyncNotNull";
            });
        }

        private void CallAccess()
        {
            this.safeRef.Access(o =>
            {
                o.Field = "Async";
            });
        }

        private void AssertFieldEquals(string value)
        {
            Assert.AreEqual(value, safeRef.GetReference().Field);
        }

    }
}
