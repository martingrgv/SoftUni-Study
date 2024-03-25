using System;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car("Audi", "A3", 6, 55);
	    }

        [Test]
        public void Constructor_ShouldCreateCar()
        {
            Assert.That(car.Make, Is.EqualTo("Audi"));
            Assert.That(car.Model, Is.EqualTo("A3"));
            Assert.That(car.FuelConsumption, Is.EqualTo(6));
            Assert.That(car.FuelCapacity, Is.EqualTo(55));
            Assert.That(car.FuelAmount, Is.EqualTo(0));
	    }

        [Test]
        public void Constructor_EmptyMake_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("", "A3", 6, 55));
	    }

        [Test]
        public void Constructor_EmptyModel_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Audi", "", 6, 55));
	    }

        [Test]
        public void Constructor_FuelConsumptionNegative_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Audi", "A3", -50, 55));
	    }

        [Test]
        public void Constructor_FuelConsumptionZero_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Audi", "A3", 0, 55));
	    }

        [Test]
        public void Constructor_FuelCapacityNegative_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Audi", "A3", 6, -35));
	    }

        [Test]
        public void Constructor_FuelCapacityZero_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Audi", "A3", 6, 0));
	    }

        [Test]
        public void RefuelTankToFull_ShouldFuelToFull()
        {
            car.Refuel(55);
            Assert.AreEqual(55, car.FuelAmount);
	    }

        [Test]
        public void RefuelTankAboveCapacity_ShouldFuelToCapacity()
        {
            car.Refuel(100);
            Assert.AreEqual(55, car.FuelAmount);
	    }

        [Test]
        public void RefuelTankWithNegative_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(-50));
	    }

        [Test]
        public void RefuelTankWithZero_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(0));
	    }

        [Test]
        public void Drive_ShouldDriveDistanceAndLowerFuelAmount()
        {
            car.Refuel(55);
            car.Drive(200);
            Assert.AreEqual(43, car.FuelAmount);
	    }

        [Test]
        public void Drive_NotEnoughFuel_ThrowsError()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
	    }
    }
}