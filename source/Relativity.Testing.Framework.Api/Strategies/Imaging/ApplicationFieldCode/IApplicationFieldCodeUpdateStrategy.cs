﻿using Relativity.Testing.Framework.Models;

namespace Relativity.Testing.Framework.Api.Strategies
{
	internal interface IApplicationFieldCodeUpdateStrategy
	{
		ApplicationFieldCode Update(int workspaceId, ApplicationFieldCode applicationFieldCode);
	}
}
