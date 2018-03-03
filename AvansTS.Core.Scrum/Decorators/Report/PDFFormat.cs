using AvansTS.Core.Scrum.Decorator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.Scrum.Decorators.Report
{
    public class PDFFormat : IFormat
    {

		public IReport GenerateFormat(IReport report)
		{
			Debug.WriteLine("HTML: ");
			Debug.WriteLine("Header: " + report.Header);
			Debug.WriteLine("Content: " + report.Content);
			Debug.WriteLine("Footer: " + report.Footer);

			return report;
		}
	}
}
