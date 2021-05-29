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
            ILogic logic = new Logic(DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss.fffffff"));

            logic.Create(new ExcerciseBinding { Title = "Tests.CoreTest.LogicTest.TestCreate", Question = "Test question", Answrer = "Test answer" });

            List<ExcerciseView> list = logic.Read(null);

            Assert.Single(list);
            Assert.Equal(1, list[0].Id);
            Assert.Equal("Tests.CoreTest.LogicTest.TestCreate", list[0].Title);
            Assert.Equal("Test question", list[0].Question);
            Assert.Equal("Test answer", list[0].Answrer);
        }
    }
}
