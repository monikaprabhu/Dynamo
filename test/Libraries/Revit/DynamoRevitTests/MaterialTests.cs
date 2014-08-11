﻿using System.IO;
using Dynamo.Utilities;
using NUnit.Framework;
using RTF.Framework;

namespace Dynamo.Tests
{
    [TestFixture]
    class MaterialTests : DynamoRevitUnitTestBase
    {
        [Test]
        [TestModel(@".\Material\GetMaterialByName.rfa")]
        public void GetMaterialByName()
        {
            string samplePath = Path.Combine(_testPath, @".\Material\GetMaterialByName.dyn");
            string testPath = Path.GetFullPath(samplePath);

            ViewModel.OpenCommand.Execute(testPath);
            Assert.DoesNotThrow(() => ViewModel.Model.RunExpression());
        }
    }
}
