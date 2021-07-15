using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfStudent.Infrastructure.Repository.Implementation.Product;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.Moq;
using WcfStudent.Domain.Entity;
using WcfStudent.Infrastructure.Repository.Contracts;

namespace WcfStudent.Infrastructure.Repository.Implementation.Product.Tests
{
    [TestClass()]
    public class TxtFileProductTests
    {
        [TestMethod()]
        public void AddTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Student student = new Student
                {
                    StudentId = 1,
                    Name = "Marc",
                    Surname = "Biedma",
                    Birthday = DateTime.Parse("1993/03/14"),
                    Age = 28,
                };

                mock.Mock<IStudentProduct>().Setup(txtFileProduct => txtFileProduct.Add(student)).Returns(student);

                var txtFileProductMocked = mock.Create<IStudentProduct>();

                var exceptedStudent = txtFileProductMocked.Add(student);

                mock.Mock<IStudentProduct>().Verify(repository => repository.Add(student));

                Assert.IsTrue(student.Equals(exceptedStudent));

            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Student student = new Student
                {
                    StudentId = 1,
                    Name = "Marc",
                    Surname = "Biedma",
                    Birthday = DateTime.Parse("1993/03/14"),
                    Age = 28,
                };

                mock.Mock<IStudentProduct>().Setup(txtFileProduct => txtFileProduct.Update(student)).Returns(student);

                var txtFileProductMocked = mock.Create<IStudentProduct>();

                var exceptedStudent = txtFileProductMocked.Update(student);

                mock.Mock<IStudentProduct>().Verify(repository => repository.Update(student));

                Assert.IsTrue(student.Equals(exceptedStudent));

            }
        }
    }
}