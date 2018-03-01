using AvansTS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Composite
{
    public abstract class WorkItemComponentBase : WorkItemBase
    {
        public abstract void Add(WorkItemComponentBase component);
        public abstract void Remove(WorkItemComponentBase component);
    }
}
