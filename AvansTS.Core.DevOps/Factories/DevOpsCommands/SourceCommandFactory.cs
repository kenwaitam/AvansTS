﻿using System;
using System.Collections.Generic;
using System.Text;
using AvansTS.Core.DevOps.Command;

namespace AvansTS.Core.DevOps.Factories.DevOpsCommands
{
    public class SourceCommandFactory : IDevOpsCommandFactory
    {
        public IDevOpsCommand CreateDevOpsCommand()
        {
            return new SourceCommand();
        }
    }
}
