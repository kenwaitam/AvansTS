﻿using AvansTS.Core.DevOps.Command;
using AvansTS.Core.DevOps.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.DevOps.Command
{
	public class BuildCommand : CommandBase
	{
		public override void Execute()
		{
			IDevOpsService build = new BuildService();
			build.Run();
		}
	}
}