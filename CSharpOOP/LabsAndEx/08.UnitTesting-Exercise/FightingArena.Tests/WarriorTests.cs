using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        private Warrior enemy;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("The Chosen Undead", 40, 100);
            enemy = new Warrior("Black Knight", 60, 300);
	    }

        [Test]
        public void Constructor_ShouldSetDataCorrectly()
        {
            Assert.That(warrior.Name, Is.EqualTo("The Chosen Undead"));
            Assert.That(warrior.Damage, Is.EqualTo(40));
            Assert.That(warrior.HP, Is.EqualTo(100));
	    }

        [Test]
        public void Constructor_EmptyName_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("  ", 20, 100));
	    }

        [Test]
        public void Constructor_ZeroDamage_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("The Chosen Undead", 0, 100));
	    }

        [Test]
        public void Constructor_NegativeDamage_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("The Chosen Undead", -10, 100));
	    }

        [Test]
        public void Constructor_NegativeHP_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("The Chosen Undead", 20, -10));
	    }

        [Test]
        public void AttackTarget_ShouldAttackAndLowerHealth()
        {
            warrior.Attack(enemy);
            
            Assert.AreEqual(40, warrior.HP);
            Assert.AreEqual(260, enemy.HP);
	    }

        [Test]
        public void AttackTarget_ShouldAttackAndKillEnemy()
        {
            enemy = new Warrior("Basilik", 1, 35);
            warrior.Attack(enemy);
            
            Assert.AreEqual(99, warrior.HP);
            Assert.AreEqual(0, enemy.HP);
	    }

        [Test]
        public void AttackWhenWarriorHPIsLowerThanMin_ThrowsError()
        {
            warrior = new Warrior("Catalyst", 100, 10);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
	    }

        [Test]
        public void AttackWhenEnemyHPIsLowerThanMin_ThrowsError()
        {
            enemy = new Warrior("Mouse", 1, 1);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
	    }

        [Test]
        public void AttackStrongerEnemy_ThrowError()
        {
            enemy = new Warrior("Boss of Masks", 300, 5000);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
	    }


    }
}