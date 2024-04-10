using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private InfluencerRepository repository;
        
        [SetUp]
        public void SetUp()
        {
            repository = new InfluencerRepository();
        }
        
        [Test]
        public void Influencer_Constructor_SetsDataCorrectly()
        {
            Influencer influencer = new Influencer("Ivancho", 20);

            Assert.AreEqual("Ivancho", influencer.Username);
            Assert.AreEqual(20, influencer.Followers);
        }

        [Test]
        public void InfluencerRepository_Constructor_SetsDataCorrectly()
        {
            Assert.IsTrue(repository.Influencers.Count == 0);
        }

        [Test]
        public void InfluencerRepository_RegisterInfluencer_AddsInfluencer_ReturnsString()
        {
            Influencer influencer = new Influencer("Gosho", 12);

            Assert.AreEqual( $"Successfully added influencer {influencer.Username} with {influencer.Followers}", repository.RegisterInfluencer(influencer));
            Assert.IsTrue(repository.Influencers.Count == 1);
        }

        [Test]
        public void InfluencerRepository_RegisterNull_ThrowsError()
        {
            Influencer influencer = null;

            Assert.Throws<ArgumentNullException>(() => repository.RegisterInfluencer(influencer));
        }

        [Test]
        public void InfluencerRepository_RegisterExistingInfluencer_ThrowsError()
        {
            Influencer influencer = new Influencer("Ivancho", 10);

            repository.RegisterInfluencer(influencer);
            Assert.Throws<InvalidOperationException>(() => repository.RegisterInfluencer(influencer));
        }

        [Test]
        public void InfluencerRepository_RemoveInfluencer_RemovesInfluencer_RetursTrue()
        {
            Influencer influencer = new Influencer("Goshko", 10);
            repository.RegisterInfluencer(influencer);
            
            Assert.IsTrue(repository.RemoveInfluencer("Goshko"));
            Assert.IsTrue(repository.Influencers.Count == 0);
        }

        [Test]
        public void InfluencerRepository_RemoveEmptyName_ThrowsError()
        {
            Assert.Throws<ArgumentNullException>(() => repository.RemoveInfluencer(""));
        }
    }
}