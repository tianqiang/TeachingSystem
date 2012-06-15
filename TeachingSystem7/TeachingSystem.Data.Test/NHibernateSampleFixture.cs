using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeachingSystem.Domain.Entities;

namespace TeachingSystem.Data.Test
{
    class NHibernateSampleFixture
    {

        private studentData sample = new studentData(new NHibernateHelper().GetSession());


        [TestMethod()]
        public void GetCustomerByIdTest()
        {
            var tempCutomer = new Customer { FirstName = "李", LastName = "永京" };
            _sample.CreateCustomer(tempCutomer);
            Customer customer = _sample.GetCustomerById(1);
            int customerId = customer.StudentNum;
            Assert.AreEqual(1, customerId);
        }
    }
}
