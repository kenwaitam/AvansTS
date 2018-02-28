using AvansTS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Observers
{
    public class TaskSubjectBase : WorkItemBase
    {
        public IObserver Observer { get; set; }

        public void Attach(IObserver observer)
        {
            Observer = observer;
        }

        public void Notify()
        {
            Observer.Update();
        }
    }
}
