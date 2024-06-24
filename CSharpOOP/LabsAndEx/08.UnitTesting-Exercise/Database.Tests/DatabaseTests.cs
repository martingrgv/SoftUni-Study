using System;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void SetUp()
        {
            db = new Database(1, 2, 3, 4, 5);
        }

        [Test]
        public void Set_DataCorrectly()
        {
            Assert.AreEqual(5, db.Count);
        }

        [Test]
        public void SetOutOfRangeDb_ThrowsError()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database outOfRangeDb = new Database(
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
            });
        }

        [Test]
        public void Constructor_NonInt_ThrowsError()
        {
            Assert.Throws<FormatException>(() =>
            {
                Database outOfRangeDb = new Database(int.Parse("abc"));
            });
        }

        [Test]
        public void Fetch_ReturnsIntArr()
        {
            int[] numbers = db.Fetch();

            Assert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void Add_AddsIntToArr()
        {
            db.Add(6);
            int[] numbers = db.Fetch();

            Assert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6 }, numbers);
	    }

        [Test]
        public void AddOnFullArr_ThrowsError()
        {
            Database fullDb = new Database(
		        1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.Throws<InvalidOperationException>(() => fullDb.Add(17));
	    }

        [Test]
        public void AddNonInt_ThrowsError()
        {
            Assert.Throws<FormatException>(() => db.Add(int.Parse("abc")));
	    }

        [Test]
        public void Remove_RemovesLastIntFromArr()
        {
            db.Remove();
            int[] numbers = db.Fetch();

            Assert.AreEqual(4, db.Count);
            Assert.AreEqual(new int[] { 1, 2, 3, 4 }, numbers);
	    }

        [Test]
        public void Remove_ThrowsError()
        {
            Database emptyDb = new Database();
            Assert.Throws<InvalidOperationException>(() => emptyDb.Remove());
		}
    }
}
