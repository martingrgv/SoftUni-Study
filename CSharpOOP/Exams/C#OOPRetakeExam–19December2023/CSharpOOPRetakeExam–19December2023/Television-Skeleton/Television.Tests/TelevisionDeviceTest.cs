namespace Television.Tests
{
    using System;
    using NUnit.Framework;
    public class Tests
    {
        private TelevisionDevice tv;

        [SetUp]
        public void Setup()
        {
            tv = new TelevisionDevice("Sony", 1200, 60, 45);
        }

        [Test]
        public void Constructor_SetsDataCorrectly()
        {
            Assert.AreEqual("Sony", tv.Brand);
            Assert.AreEqual(1200, tv.Price);
            Assert.AreEqual(60, tv.ScreenWidth);
            Assert.AreEqual(45, tv.ScreenHeigth);

            Assert.AreEqual(0, tv.CurrentChannel);
            Assert.AreEqual(13, tv.Volume);
            Assert.IsFalse(tv.IsMuted);
        }

        [Test]
        public void SwitchOn_SoundOn_ReturnsString()
        {
            Assert.That(tv.SwitchOn(), Is.EqualTo($"Cahnnel {tv.CurrentChannel} - Volume {tv.Volume} - Sound On"));
	    }

        [Test]
        public void SwithOn_SoundOff_ReturnsString()
        {
            tv.MuteDevice();
            Assert.That(tv.SwitchOn(), Is.EqualTo($"Cahnnel {tv.CurrentChannel} - Volume {tv.Volume} - Sound Off"));
	    }

        [Test]
        public void ChangeChannel_ReturnsNewChannel()
        {
            Assert.That(tv.ChangeChannel(3), Is.EqualTo(3));
            Assert.AreEqual(3, tv.CurrentChannel);
	    }

        [Test]
        public void ChangeChannel_ToNegativeNumber_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => tv.ChangeChannel(-11));
	    }

        [Test]
        public void VolumeUp_ReturnsIncreasedVolume()
        {
            Assert.That(tv.VolumeChange("UP", 10), Is.EqualTo($"Volume: 23"));
	    }

        [Test]
        public void VolumeUp_IncreaseMax_ReturnsMax()
        {
            Assert.That(tv.VolumeChange("UP", 120), Is.EqualTo($"Volume: 100"));
	    }

        [Test]
        public void VolumeDown_ReturnsDecreasedVolume()
        {
            Assert.That(tv.VolumeChange("DOWN", 10), Is.EqualTo($"Volume: 3"));
	    }

        [Test]
        public void VolumeDown_DecreaseToNegative_ReturnsZero()
        {
            Assert.That(tv.VolumeChange("DOWN", 200), Is.EqualTo($"Volume: 0"));
	    }

        [Test]
        public void MuteDevice_MutesWithSoundOn()
        {
            bool result = tv.MuteDevice();
            Assert.IsTrue(result);
	    }

        [Test]
        public void MuteDevice_UnmutesWithSoundOff()
        {
            tv.MuteDevice();

            bool result = tv.MuteDevice();
            Assert.IsFalse(result);
	    }

        [Test]
        public void ToStringMethod()
        {
            Assert.That(tv.ToString(), Is.EqualTo($"TV Device: {tv.Brand}, Screen Resolution: {tv.ScreenWidth}x{tv.ScreenHeigth}, Price {tv.Price}$"));
	    }
    }
}