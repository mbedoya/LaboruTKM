using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaboruTKM.Model;
using LaboruTKM.Common;

namespace LaboruTKM.Tests
{
    [TestClass]
    public class CompanyTest
    {
        private const string DefaultCompanyEmail = "intrepidez";

        [TestMethod]
        public void Login_CompanyFound_CompanyIsNotNull()
        {
            Company company = new Company();
            CompanyDTO dto = company.Login(DefaultCompanyEmail, "1234");
            Assert.IsNotNull(dto);
        }

        [TestMethod]
        public void Login_CompanyFound_CompanyHasName()
        {
            Company company = new Company();
            CompanyDTO dto = company.Login(DefaultCompanyEmail, "1234");
            Assert.IsNotNull(!String.IsNullOrEmpty(dto.Name));
        }
    }
}
