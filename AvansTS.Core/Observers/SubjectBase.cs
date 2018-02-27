using AvansTS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.Observers
{
    public abstract class SubjectBase
    {
        public List<IObserver> Observers { get; set; }

        public SubjectBase()
        {
            Observers = new List<IObserver>();
        }

        public void Attach(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var obs in Observers)
            {
                obs.Update();
            }
        }
    }
}
