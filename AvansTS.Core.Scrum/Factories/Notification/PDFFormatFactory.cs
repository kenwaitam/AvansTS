using AvansTS.Core.Scrum.Decorators.Report;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Factories.Notification
{
    public class PDFFormatFactory
    {
		public IFormat GeneratePDFFormat()
		{
			return new PDFFormat();
		}
	}
}
