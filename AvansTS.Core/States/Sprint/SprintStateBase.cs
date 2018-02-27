using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.SprintBlacklog
{
    public abstract class SprintStateBase
    {
        public void InProgress() { }
        public void IsDone() { }
        public void IsWrong() { }
    }
}
