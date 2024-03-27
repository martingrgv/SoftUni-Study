using System;
using _01.FakeAxeAndDummy;
using Moq;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLoosesDurabillityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Mock<ITarget> mockTarget = new Mock<ITarget>();
            ITarget dummy = mockTarget.Object;

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durabilty doesn't change after attack.");
        }

        [Test]
        public void AttackWithBrokenAxe()
        {
            Axe axe = new Axe(10, 0);
            Mock<ITarget> mockTarget = new Mock<ITarget>();
            ITarget dummy = mockTarget.Object;

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
	    }
    }
}