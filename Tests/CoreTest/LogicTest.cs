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
            ILogic logic = new Logic("test");

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
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestReadById()
        {
            ILogic logic = new Logic("test");

            try
            {
                logic.Create(new ExcerciseBinding { Title = "Tests.CoreTest.LogicTest.TestReadById_1", Question = "Test question 1", Answrer = "Test answer 1" });
                logic.Create(new ExcerciseBinding { Title = "Tests.CoreTest.LogicTest.TestReadById_2", Question = "Test question 2", Answrer = "Test answer 2" });
                logic.Create(new ExcerciseBinding { Title = "Tests.CoreTest.LogicTest.TestReadById_3", Question = "Test question 3", Answrer = "Test answer 3" });

                List<ExcerciseView> list = logic.Read(new ExcerciseBinding { Id = 2 });

                Assert.Single(list);
                Assert.Equal(2, list[0].Id);
                Assert.Equal("Tests.CoreTest.LogicTest.TestReadById_2", list[0].Title);
                Assert.Equal("Test question 2", list[0].Question);
                Assert.Equal("Test answer 2", list[0].Answrer);
            }
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestDeleteAll()
        {
            ILogic logic = new Logic("test");

            try
            {
                logic.Create(new ExcerciseBinding { Title = "Tests.CoreTest.LogicTest.TestDeleteAll_1", Question = "Test question 1", Answrer = "Test answer 1" });
                logic.Create(new ExcerciseBinding { Title = "Tests.CoreTest.LogicTest.TestDeleteAll_2", Question = "Test question 2", Answrer = "Test answer 2" });
                
                logic.Delete(null);
                List<ExcerciseView> list = logic.Read(null);

                Assert.Empty(list);
            }
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestDeleteSingle()
        {
            ILogic logic = new Logic("test");

            try
            {
                logic.Create(new ExcerciseBinding { Title = "Tests.CoreTest.LogicTest.TestDeleteSingle_1", Question = "Test question 1", Answrer = "Test answer 1" });
                logic.Create(new ExcerciseBinding { Title = "Tests.CoreTest.LogicTest.TestDeleteSingle_2", Question = "Test question 2", Answrer = "Test answer 2" });
                logic.Create(new ExcerciseBinding { Title = "Tests.CoreTest.LogicTest.TestDeleteSingle_3", Question = "Test question 3", Answrer = "Test answer 3" });

                logic.Delete(new ExcerciseBinding { Id = 2 });
                List<ExcerciseView> list = logic.Read(null);

                Assert.Equal(2, list.Count);
                Assert.Equal(1, list[0].Id);
                Assert.Equal(3, list[1].Id);
            }
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestUpdate()
        {
            ILogic logic = new Logic("test");

            try
            {
                logic.Create(new ExcerciseBinding { Title = "Tests.CoreTest.LogicTest.TestUpdate_1", Question = "Test question 1", Answrer = "Test answer 1" });
                logic.Update(new ExcerciseBinding { Id = 1, Title = "Tests.CoreTest.LogicTest.TestUpdate_2", Question = "Test question 2", Answrer = "Test answer 2" });

                List<ExcerciseView> list = logic.Read(null);

                Assert.Single(list);
                Assert.Equal(1, list[0].Id);
                Assert.Equal("Tests.CoreTest.LogicTest.TestUpdate_2", list[0].Title);
                Assert.Equal("Test question 2", list[0].Question);
                Assert.Equal("Test answer 2", list[0].Answrer);
            }
            finally
            {
                logic.Delete(null);
            }
        }
    }
}
