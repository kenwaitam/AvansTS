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
			ReportBase report = new Report(prj.ProductBacklog.Sprints[0].Name);
			report = new FooterDecorator(report, "Test");
			report = new HeaderDecorator(report, "Test2");
			Assert.Equal("Test", report.Footer);
			Assert.Equal("Test2", report.Header);
			Assert.Equal(prj.ProductBacklog.Sprints[0].Name, report.Content);
		}

		[Fact]
		public void TestFormatReport()
		{
			var report = new Report(prj.ProductBacklog.Sprints[0].Name);
			ReportDecorator reportDecorator = new ReportDecorator(report);
			PDFFormatFactory PdfFactory = new PDFFormatFactory();
			var pdfReport = PdfFactory.GeneratePDFFormat().GenerateFormat(report);
			var pdf = PdfFactory.GeneratePDFFormat();
			Assert.IsType<PDFFormat>(pdf);
		}
	}
}
