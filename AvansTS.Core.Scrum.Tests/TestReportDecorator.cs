using AvansTS.Core.Scrum.Decorator;
using AvansTS.Core.Scrum.Decorators.Report;
using AvansTS.Core.Scrum.Factories.Notification;
using AvansTS.Core.States.Sprint.Implementations;
using Xunit;

namespace AvansTS.Core.Tests
{
	public class TestReportDecorator : TestDataFixture
    {

		[Fact]
		public void TestGenerateReport()
		{
			var report = new Report();
			ReportDecoratorBase reportDecorator = new ReportDecorator(report, prj.ProductBacklog.Sprints[0].Name);
			reportDecorator = new FooterDecorator(reportDecorator, "TestFooter");
			Assert.Equal("TestFooter", reportDecorator.Footer);
		}

		[Fact]
		public void TestFormatReport()
		{
			var report = new Report();
			ReportDecoratorBase reportDecorator = new ReportDecorator(report, prj.ProductBacklog.Sprints[0].Name);
			PDFFormatFactory PdfFactory = new PDFFormatFactory();
			var pdfReport = PdfFactory.GeneratePDFFormat().GenerateFormat(report);
			var pdf = PdfFactory.GeneratePDFFormat();
			Assert.IsType<PDFFormat>(pdf);
		}
	}
}
