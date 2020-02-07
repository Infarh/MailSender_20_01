using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Services.InMemory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailSender.lib.Tests.Services
{
    [TestClass]
    public class RecipientsStoreInMemoryTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Create_throw_ArgumentNullException_if_items_is_null()
        {
            var store = new RecipientsStoreInMemory();

            store.Create(null);
        }

        [TestMethod]
        public void Create_throw_ArgumentNullException_if_items_is_null2()
        {
            var store = new RecipientsStoreInMemory();

            Assert.ThrowsException<ArgumentNullException>(() => store.Create(null));
        }
    }
}
