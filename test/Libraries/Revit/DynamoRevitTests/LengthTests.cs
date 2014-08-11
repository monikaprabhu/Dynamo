﻿using System.IO;
using Dynamo.Utilities;
using NUnit.Framework;
using RTF.Framework;

namespace Dynamo.Tests
{
    [TestFixture]
    class LengthTests:DynamoRevitUnitTestBase
    {
        [Test]
        [TestModel(@".\empty.rfa")]
        public void Length()
        {
            string samplePath = Path.Combine(_testPath, @".\Length\Length.dyn");
            string testPath = Path.GetFullPath(samplePath);

            ViewModel.OpenCommand.Execute(testPath);
            Assert.DoesNotThrow(() => ViewModel.Model.RunExpression());
        }
    }
}
