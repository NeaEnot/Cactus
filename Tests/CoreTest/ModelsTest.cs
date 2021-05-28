using Core.Models;
using Xunit;

namespace Tests.CoreTest
{
	public class ModelsTest
	{
		[Fact]
		public void TestExcercise()
		{
			ExcerciseView model = new ExcerciseView { Id = 1, Title = "Tests.CoreTest.Test", Question = "It is a test question", Answrer = "It is a test answer" };

			Assert.Equal(1, model.Id);
			Assert.Equal("Tests.CoreTest.Test", model.Title);
			Assert.Equal("It is a test question", model.Question);
			Assert.Equal("It is a test answer", model.Answrer);
		}
	}
}
