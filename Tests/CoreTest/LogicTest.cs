using Core;
using Core.Models;
using FileImplement;
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
    }
}
