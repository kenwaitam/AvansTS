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
			ReportDecoratorBase reportDecorator = new ReportDecorator(report, "Hallo Ritchie", prj.ProductBacklog.Sprints[0].Name, "Doei Ritchie");
			Assert.Equal("Hallo Ritchie", report.Header);
			Assert.Equal(prj.ProductBacklog.Sprints[0].Name, report.Content);
			Assert.Equal("Doei Ritchie", report.Footer);
		}

		[Fact]
		public void TestFormatReport()
		{
			var report = new Report();
			ReportDecoratorBase reportDecorator = new ReportDecorator(report, "Hallo Ritchie", prj.ProductBacklog.Sprints[0].Name, "Doei Ritchie");
			PDFFormatFactory PdfFactory = new PDFFormatFactory();
			var pdfReport = PdfFactory.GeneratePDFFormat().GenerateFormat(report);
			var pdf = PdfFactory.GeneratePDFFormat();
			Assert.Equal("Hallo Ritchie", pdfReport.Header);
			Assert.Equal(prj.ProductBacklog.Sprints[0].Name, pdfReport.Content);
			Assert.Equal("Doei Ritchie", pdfReport.Footer);
			Assert.IsType<PDFFormat>(pdf);
		}
	}
}
