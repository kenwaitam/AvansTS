using AvansTS.Core.Scrum.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Decorators.Report
{
	public abstract class ReportBase : IReport
	{

		public abstract string Header { get; }

		public abstract string Content { get; }

		public abstract string Footer { get; }

		public ReportBase ()
		{
		}
	}
}
