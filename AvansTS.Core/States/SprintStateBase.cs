using AvansTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.Sprint
{
    public abstract class SprintStateBase
    {
        public virtual void UpdateName(String name)
        {
            throw new InvalidOperationException();
        }

        public virtual void UpdateDate(DateTime startDate, DateTime endDate)
        {
            throw new InvalidOperationException();
        }

        public virtual void AddItem(ProductBacklogItem item)
        {
            throw new InvalidOperationException();
        }

        public virtual void StartSprint()
        {
            throw new InvalidOperationException();
        }

        public virtual void EndSprint()
        {
            throw new InvalidOperationException();
        }
    }
}
