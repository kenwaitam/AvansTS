using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Decorator
{
    public interface IReport
    {
		String Header { get; }
		String Content { get; }
		String Footer { get; }
	}
}
