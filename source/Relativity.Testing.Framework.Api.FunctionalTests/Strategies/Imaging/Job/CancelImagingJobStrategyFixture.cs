﻿using System;
using NUnit.Framework;
using Relativity.Testing.Framework.Api.Strategies;
using Relativity.Testing.Framework.Models;
using Relativity.Testing.Framework.Versioning;

namespace Relativity.Testing.Framework.Api.FunctionalTests.Strategies
{
	[VersionRange(">=12.1")]
	[TestOf(typeof(ICancelImagingJobStrategy))]
	internal class CancelImagingJobStrategyFixture : ImagingStrategyAbstractFixture<ICancelImagingJobStrategy>
	{
		[Test]
		public void Cancel_WithOptionalRequest_ShouldNotThrow()
		{
			int imagingSetId = CreateImagingSet().ArtifactID;
			long imagingJobId = Facade.Resolve<IImagingJobRunStrategy>().Run(DefaultWorkspace.ArtifactID, imagingSetId);
			var stopImagingJobRequest = ArrangeImagingJobRequest();

			Assert.DoesNotThrow(() => Sut.Cancel(DefaultWorkspace.ArtifactID, imagingJobId, stopImagingJobRequest));
		}

		[Test]
		public void Cancel_WithoutOptionalRequest_ShouldNotThrow()
		{
			int imagingSetId = CreateImagingSet().ArtifactID;
			long imagingJobId = Facade.Resolve<IImagingJobRunStrategy>().Run(DefaultWorkspace.ArtifactID, imagingSetId);

			Assert.DoesNotThrow(() => Sut.Cancel(DefaultWorkspace.ArtifactID, imagingJobId));
		}

		private ImagingJobRequest ArrangeImagingJobRequest()
		{
			return new ImagingJobRequest
			{
				OriginationID = Guid.NewGuid()
			};
		}
	}
}
