using System;
using NUnit.Framework;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
	[TestFixture]
	public class ExtendedDatabaseTests
	{
		private Database db;

		[SetUp]
		public void SetUp()
		{
			db = new Database(
				new Person(1, "Goshko"),
				new Person(2, "Ivan"),
				new Person(1833, "Petar")
			);
		}

		[Test]
		public void SetData_Correctly()
		{
			Assert.AreEqual(3, db.Count);
		}

		[Test]
		public void SetData_FullPersons_ThrowsError()
		{
			Assert.Throws<ArgumentException>(() =>
			{
				int counter = 0;

				db = new Database(
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter),
					new Person(++counter, "A" + counter)
					);
			});
		}

		[Test]
		public void Add_AddsPerson()
		{
			db.Add(new Person(35, "Mitio"));

			Assert.AreEqual(4, db.Count);
		}

		[Test]
		public void AddWhenFull_ThrowsError()
		{
			db = new Database();

			for (int i = 1; i <= 16; i++)
			{
				db.Add(new Person(i, "Mity" + i));
			}

			Assert.Throws<InvalidOperationException>(() => db.Add(new Person(9999999999, "Vancho")));
		}

		[Test]
		public void AddSameUsername_ThrowsError()
		{
			Assert.Throws<InvalidOperationException>(() => db.Add(new Person(55, "Goshko")));
		}

		[Test]
		public void AddSameId_ThrowsError()
		{
			Assert.Throws<InvalidOperationException>(() => db.Add(new Person(1, "Arthyom")));
		}

		[Test]
		public void Remove_RemovesPerson()
		{
			db.Remove();
			Assert.AreEqual(2, db.Count);
		}

		[Test]
		public void RemoveWhenEmpty_ThrowsError()
		{
			db = new Database();
			Assert.Throws<InvalidOperationException>(() => db.Remove());
		}

		[Test]
		public void FindByUsername_ReturnsPerson()
		{
			Person foundPerson = db.FindByUsername("Ivan");

			Assert.That(foundPerson, Is.Not.Null);
			Assert.That(foundPerson.UserName, Is.EqualTo("Ivan"));
			Assert.That(foundPerson.Id, Is.EqualTo(2));
		}

		[Test]
		public void FindByUsername_NotExistingUser_ThrowsError()
		{
			Assert.Throws<InvalidOperationException>(() => db.FindByUsername("Da vinci"));
		}

		[Test]
		public void FindByUsername_NoUsername_ThrowsError()
		{
			Assert.Throws<ArgumentNullException>(() => db.FindByUsername(""));
		}

		[Test]
		public void FindById_ReturnsPerson()
		{
			Person foundPerson = db.FindById(1);

			Assert.That(foundPerson, Is.Not.Null);
			Assert.That(foundPerson.UserName, Is.EqualTo("Goshko"));
			Assert.That(foundPerson.Id, Is.EqualTo(1));
		}

		[Test]
		public void FindById_NotExistingUser_ThrowsError()
		{
			Assert.Throws<InvalidOperationException>(() => db.FindById(100));
		}

		[Test]
		public void FindById_NegativeId_ThrowsError()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-100));
		}
    }
}