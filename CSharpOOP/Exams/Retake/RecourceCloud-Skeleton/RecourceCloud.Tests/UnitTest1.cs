using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RecourceCloud.Tests
{
    public class Tests
    {
        private DepartmentCloud _departmentCloud;
        
        [SetUp]
        public void Setup()
        {
            _departmentCloud = new DepartmentCloud();
        }

        [Test]
        public void Resource_Constructor_SetsDataCorrectly()
        {
            Resource resource = new Resource("CSharp", "EZ");
            
            Assert.AreEqual("CSharp", resource.Name);
            Assert.AreEqual("EZ", resource.ResourceType);
        }
        
        [Test]
        public void Task_Constructor_SetsDataCorrectly()
        {
            Task task = new Task(3, "Not hard", "CSharpTests");
            
            Assert.AreEqual(3, task.Priority);
            Assert.AreEqual("Not hard", task.Label);
            Assert.AreEqual("CSharpTests", task.ResourceName);
        }
        
        // Department

        [Test]
        public void Constructor_SetsDataCorrectly()
        {
            Assert.AreEqual(0, _departmentCloud.Resources.Count);
            Assert.AreEqual(0, _departmentCloud.Tasks.Count);
        }

        [Test]
        public void LogTask_Successfully()
        {
            Assert.AreEqual("Task logged successfully.", _departmentCloud.LogTask(new[] {"3", "Not Hard", "CSharp"}));
            Assert.AreEqual(1, _departmentCloud.Tasks.Count);
        }

        [Test]
        public void LogTask_LessArguments_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => _departmentCloud.LogTask(new[] {"123", "ABC"}));
        }

        [Test]
        public void LogTask_NullValue_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => _departmentCloud.LogTask(new[] {"123", "ABC", null}));
        }

        [Test]
        public void LogAlreadyExistingTask_ReturnsString()
        {
            _departmentCloud.LogTask(new[] {"3", "Not Hard", "CSharp"});
            Assert.AreEqual("CSharp is already logged.", _departmentCloud.LogTask(new[] {"3", "Not Hard", "CSharp"}));
        }

        [Test]
        public void CreateResource_ReturnsTrue()
        {
            _departmentCloud.LogTask(new[] {"3", "Not Hard", "CSharp"});
            Assert.IsTrue(_departmentCloud.CreateResource());
            
            Assert.AreEqual(0, _departmentCloud.Tasks.Count);
            Assert.AreEqual(1, _departmentCloud.Resources.Count);
        }

        [Test]
        public void CreateResource_ReturnsFalse_EmptyTasks()
        {
            Assert.IsFalse(_departmentCloud.CreateResource());
        }

        [Test]
        public void TestResource_ReturnsTestedResource()
        {
            _departmentCloud.LogTask(new[] {"3", "Not Hard", "CSharp"});
            _departmentCloud.CreateResource();

            Resource resource = _departmentCloud.Resources.FirstOrDefault();
            
            Assert.AreEqual(resource, _departmentCloud.TestResource("CSharp"));
            Assert.IsTrue(resource.IsTested);
        }

        [Test]
        public void TestNullResource_ReturnsNull()
        {
            Assert.AreEqual(null, _departmentCloud.TestResource("ABC"));
        }
    }
}