using AvansTS.Core.Scrum.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Factories
{
    public interface IFormatFactory
    {
        IFormatService CreateFormatService();
    }
}
