using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clever;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ServerWorking
    {
        [TestMethod]
        public void AddToCount()
        {
            var tasks = new List<Task>();
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tasks.Add(
                        Task.Factory.StartNew((() => Server.GetCount())));
                }
                tasks.Add(
                    Task.Factory.StartNew(() => Server.AddToCount(1)));
            }

            Task.WaitAll(tasks.ToArray());

            Assert.AreEqual(1000, Server.GetCount());
        }
    }
}
