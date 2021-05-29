using Core;
using Core.Models;
using FileImplement;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests.CoreTest
{
    public class LogicTest
    {
        [Fact]
        public void TestReadEmpty()
        {
            ILogic logic = new Logic("test");

            List<ExcerciseView> list = logic.Read(null);

            Assert.Empty(list);
        }

        [Fact]
        public void TestCreate()
        {
            ILogic logic = new Logic(DateTime.Now.ToString("test"));

            try
            {
                logic.Create(new ExcerciseBinding { Title = "Tests.CoreTest.LogicTest.TestCreate", Question = "Test question", Answrer = "Test answer" });

                List<ExcerciseView> list = logic.Read(null);

                Assert.Single(list);
                Assert.Equal(1, list[0].Id);
                Assert.Equal("Tests.CoreTest.LogicTest.TestCreate", list[0].Title);
                Assert.Equal("Test question", list[0].Question);
                Assert.Equal("Test answer", list[0].Answrer);
            }
            catch
            {
                logic.Delete(null);
                Assert.True(false);
            }
        }

        [Fact]
        public void TestDeleteAll()
        {
            ILogic logic = new Logic(DateTime.Now.ToString("test"));

            try
            {
                logic.Create(new ExcerciseBinding { Title = "Tests.CoreTest.LogicTest.TestDeleteAll_1", Question = "Test question 1", Answrer = "Test answer 1" });
                logic.Create(new ExcerciseBinding { Title = "Tests.CoreTest.LogicTest.TestDeleteAll_2", Question = "Test question 2", Answrer = "Test answer 2" });
                logic.Delete(null);

                List<ExcerciseView> list = logic.Read(null);

                Assert.Empty(list);
            }
            catch
            {
                logic.Delete(null);
                Assert.True(false);
            }
        }
    }
}
