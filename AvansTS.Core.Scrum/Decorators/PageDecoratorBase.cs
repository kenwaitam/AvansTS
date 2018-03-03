using AvansTS.Core.Scrum.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Scrum.Decorators
{
    public abstract class PageDecoratorBase : PageBase
    {
        public PageBase Page { get; set; }

        public PageDecoratorBase(PageBase page)
        {
            Page = page;
        }

        public override void Apply()
        {
            Page.Apply();
        }
    }
}
