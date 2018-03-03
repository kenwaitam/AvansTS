using AvansTS.Core.Scrum.Decorators.Page;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Models.Base
{
    public abstract class PageBase
    {
        public PageBase Prev { get; set; }

        public String LeftText { get; set; }
        public String CenterText { get; set; }
        public String RightText { get; set; }

        public virtual void Apply() { }
    }
}
