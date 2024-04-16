namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private Device device;
        
        [SetUp]
        public void Setup()
        {
            device = new Device(1000);
        }

        [Test]
        public void Constructor_SetsDataCorrectly()
        {
            Assert.AreEqual(1000, device.MemoryCapacity);
            Assert.AreEqual(1000, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);
        }

        [Test]
        public void TakePhoto_ReturnsTrue()
        {
            Assert.IsTrue(device.TakePhoto(50));
            Assert.AreEqual(1000 - 50, device.AvailableMemory);
            Assert.AreEqual(1, device.Photos);
        }

        [Test]
        public void TakePhoto_LargeSize_ReturnsFalse()
        {
            Assert.IsFalse(device.TakePhoto(5000));
        }

        [Test]
        public void InstallApplication_AddsApp()
        {
            Assert.AreEqual($"Photoshop is installed successfully. Run application?",
                device.InstallApp("Photoshop", 500));
            Assert.AreEqual(1000 - 500, device.AvailableMemory);
            Assert.AreEqual(1, device.Applications.Count);
        }

        [Test]
        public void InstallLargeApp_ThrowsError()
        {
            Assert.Throws<InvalidOperationException>(() => device.InstallApp("GTAVI", 80000));
        }

        [Test]
        public void FormatDevice_FormatsAll()
        {
            device.TakePhoto(20);
            device.InstallApp("VSCode", 100);
            
            device.FormatDevice();
            
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);
            Assert.AreEqual(1000, device.AvailableMemory);
        }

        [Test]
        public void GetDeviceStatus_ReturnsStringCorrectly()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"Memory Capacity: {device.MemoryCapacity} MB, Available Memory: {device.AvailableMemory} MB");
            sb.AppendLine($"Photos Count: {device.Photos}");
            sb.AppendLine($"Applications Installed: {string.Join(", ", device.Applications)}");
            
            Assert.AreEqual(device.GetDeviceStatus(), sb.ToString().TrimEnd());
        }
    }
}