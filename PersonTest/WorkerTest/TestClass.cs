using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonTest;

namespace WorkerTest
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void ToStringTestMethod()
        {
           Person person = new Person("Tom", new DateTime(1998, 07, 28));
           string result = Person.ToString(person);

           string expectedResult = "Tom 1998-07-28 20\n";

           Assert.AreEqual(expectedResult, result);

        }
    }
}
