﻿using System.IO;
using Dynamo.Utilities;
using NUnit.Framework;
using RTF.Framework;

namespace Dynamo.Tests
{
    [TestFixture]
    class TopographyTests : DynamoRevitUnitTestBase
    {
        [Test]
        [TestModel(@".\empty.rvt")]
        public void TopographyFromPoints()
        {
            string samplePath = Path.Combine(_testPath, @".\Topography\TopographyFromPoints.dyn");
            string testPath = Path.GetFullPath(samplePath);

            ViewModel.OpenCommand.Execute(testPath);
            Assert.DoesNotThrow(() => ViewModel.Model.RunExpression());
        }

        [Test]
        [TestModel(@".\Topography\topography.rvt")]
        public void PointsFromTopography()
        {
            string samplePath = Path.Combine(_testPath, @".\Topography\PointsFromTopography.dyn");
            string testPath = Path.GetFullPath(samplePath);

            ViewModel.OpenCommand.Execute(testPath);
            Assert.DoesNotThrow(() => ViewModel.Model.RunExpression());
        }
    }
}
