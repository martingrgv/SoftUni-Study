using System;

namespace FightingArena.Tests
{
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
	    }

        [Test]
        public void Constructor_SetData_Correctly()
        {
            Assert.That(arena.Count, Is.EqualTo(0));
	    }

        [Test]
        public void Enroll_ShouldEnrollWarrior()
        {
            Warrior warrior = new Warrior("The Chosen One", 50, 150);
            arena.Enroll(warrior);

            Assert.That(arena.Count, Is.EqualTo(1));
            Assert.IsTrue(arena.Warriors.Any(w => w.Name == "The Chosen One"));
	    }

        [Test]
        public void EnrollSameWarrior_ThrowsError()
        {
            Warrior warrior = new Warrior("The Chosen One", 50, 150);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
	    }

        [Test]
        public void WarriorsShouldFight()
        {
            Warrior attacker = new Warrior("Attacker", 40, 100);
            Warrior defender = new Warrior("Defender", 30, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("Attacker", "Defender");

            Assert.AreEqual(70, attacker.HP);
            Assert.AreEqual(60, defender.HP);
        }

        [Test]
        public void WarriorsFight_MissingAttacker_ThrowsError()
        { 
            Warrior defender = new Warrior("Defender", 30, 100);
            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Ivan", "Defender"));
	    }

        [Test]
        public void WarriorsFight_MissingDefender_ThrowsError()
        { 
            Warrior attacker = new Warrior("Attacker", 30, 100);
            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Attacker", "ThePro"));
	    }
    }
}
