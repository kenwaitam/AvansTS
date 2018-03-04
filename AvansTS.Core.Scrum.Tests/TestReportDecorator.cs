using AvansTS.Core.Scrum.Decorators.Page;
using AvansTS.Core.Scrum.Models;
using AvansTS.Core.Scrum.Models.Base;
using Xunit;

namespace AvansTS.Core.Tests
{
	public class TestReportDecorator : TestDataFixture
    {
		[Fact]
		public void TestHeader()
		{
			PageBase page = new Page();

			page = new HeaderDecorator(page)
			{
				LeftText = "A company",
				CenterText = "Test",
				RightText = "Test2"
			};
			page.Apply();
			Assert.Equal("A company", page.LeftText);
			Assert.IsType<HeaderDecorator>(page);
		}

		[Fact]
		public void TestFooter()
		{
			PageBase page = new Page();

			page = new FooterDecorator(page)
			{
				LeftText = "A company",
				CenterText = "Test",
				RightText = "Test2"
			};
			page.Apply();
			Assert.Equal("A company", page.LeftText);
			Assert.IsType<FooterDecorator>(page);
		}

		[Fact]
		public void TestReport()
		{
			PageBase page = new Page();

			page = new HeaderDecorator(page)
			{
				LeftText = "Header",
				CenterText = "Test",
				RightText = "Test2"
			};

			page = new SectionDecorator(page)
			{
				LeftText = "Section"
			};

			page = new FooterDecorator(page)
			{
				LeftText = "Footer",
				CenterText = "Test",
				RightText = "Test2"
			};
			page.Apply();

			Assert.Equal("Footer", page.LeftText);
			Assert.Equal("Section", page.Prev.LeftText);
			Assert.Equal("Header", page.Prev.Prev.LeftText);
			Assert.IsType<FooterDecorator>(page);
			Assert.IsType<SectionDecorator>(page.Prev);
			Assert.IsType<HeaderDecorator>(page.Prev.Prev);
		}
	}
}
