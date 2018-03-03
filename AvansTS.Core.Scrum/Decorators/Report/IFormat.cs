using AvansTS.Core.Scrum.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Decorators.Report
{
    public interface IFormat
    {
		IReport GenerateFormat(IReport report);

	}
}
