using System;
using NUnit.Framework;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
	public class PersonTests
	{
		private Person person;

		[SetUp]
		public void SetUp()
		{
			person = new Person(1, "Ivan");
		}

		[Test]
		public void SetData_Correctly()
		{
			Assert.AreEqual(1, person.Id);
			Assert.AreEqual("Ivan", person.UserName);
		}
	}
}

