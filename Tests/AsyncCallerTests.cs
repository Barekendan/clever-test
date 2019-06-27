using System;
using System.Threading;
using Clever;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AsyncCallerTests
    {
        [TestMethod]
        public void AsyncCallerWorks()
        {
            var handler = new EventHandler((sender, args) => Thread.Sleep(300));
            var caller = new AsyncCaller(handler);

            var ok = caller.Invoke(400, null, EventArgs.Empty);

            Assert.IsTrue(ok);

            Assert.IsFalse(caller.Invoke(200, null, EventArgs.Empty));
        }
    }
}