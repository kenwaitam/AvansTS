using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Decorator
{
	public abstract class ReportDecoratorBase : IReport
	{
		public IReport Report { get; set; }

		public ReportDecoratorBase(IReport report)
		{
			Report = report;
		}

		public virtual string Header { get; set; }

		public virtual string Content { get; set; }

		public virtual string Footer { get; set; }
	}
}
