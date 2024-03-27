using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(10, 10);
	    }

        [Test]
        public void DummySetsDataCorrectly()
        {
            Assert.AreEqual(10, dummy.Health);
	    }

        [Test]
        public void DummyLoosesHealthOnAttack()
        {
            dummy.TakeAttack(8);
            Assert.AreEqual(2, dummy.Health);
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            dummy.TakeAttack(10);
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10));
		}

        [Test]
        public void DeadDummyCanGivesExperience()
        {
            dummy.TakeAttack(10);
            Assert.AreEqual(dummy.GiveExperience(), 10);
	    }

        [Test]
        public void AliveDummyThrowsExceptionOnGiveExperience()
        {
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
		}
    }
}