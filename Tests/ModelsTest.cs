using Core.Models;
using Xunit;

namespace Tests
{
	public class ModelsTest
	{
		[Fact]
		public void TestExcerciseView()
		{
			ExcerciseView model = new ExcerciseView { Id = 1, Title = "Tests.CoreTest.Test", Question = "It is a test question", Answer = "It is a test answer" };

			Assert.Equal(1, model.Id);
			Assert.Equal("Tests.CoreTest.Test", model.Title);
			Assert.Equal("It is a test question", model.Question);
			Assert.Equal("It is a test answer", model.Answer);
		}
		[Fact]
		public void TestExcerciseBinding()
		{
			ExcerciseBinding model1 = new ExcerciseBinding { Id = 1, Title = "Tests.CoreTest.Test", Question = "It is a test question", Answrer = "It is a test answer" };
			ExcerciseBinding model2 = new ExcerciseBinding { Id = null, Title = "Tests.CoreTest.Test", Question = "It is a test question", Answrer = "It is a test answer" };

			Assert.Equal(1, model1.Id);
			Assert.Equal("Tests.CoreTest.Test", model1.Title);
			Assert.Equal("It is a test question", model1.Question);
			Assert.Equal("It is a test answer", model1.Answrer);
			Assert.Null(model2.Id);
			Assert.Equal("Tests.CoreTest.Test", model2.Title);
			Assert.Equal("It is a test question", model2.Question);
			Assert.Equal("It is a test answer", model2.Answrer);
		}
	}
}
