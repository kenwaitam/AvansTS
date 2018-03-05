using AvansTS.Core.DevOps.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.DevOps.Factories
{
    public interface IDevOpsCommandFactory
    {
        IDevOpsCommand CreateDevOpsCommand();
    }
}
