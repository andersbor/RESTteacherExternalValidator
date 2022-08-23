using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTteacherExternalValidator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTteacherExternalValidator.Models.Tests
{
    [TestClass()]
    public class TeacherValidatorTests
    {
        [TestMethod()]
        public void ValidateTest()
        {
            Teacher teacher = new Teacher { Id = 1, Name = "Y", Salary = 0 };
            TeacherValidator.Validate(teacher);

            Teacher teacher2 = new Teacher { Id = 1, Name = null, Salary = 0 };
            Assert.ThrowsException<ArgumentNullException>(() => TeacherValidator.Validate(teacher2));

            Teacher teacher3 = new Teacher { Id = 1, Name = "", Salary = 0 };
            Assert.ThrowsException<ArgumentException>(() => TeacherValidator.Validate(teacher3));

            Teacher teacher4 = new Teacher { Id = 1, Name = "Y", Salary = -1 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => TeacherValidator.Validate(teacher4));
        }
    }
}