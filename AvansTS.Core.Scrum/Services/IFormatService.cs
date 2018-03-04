using AvansTS.Core.Scrum.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Services
{
    public interface IFormatService
    {
        String Convert(Report report);
    }
}
