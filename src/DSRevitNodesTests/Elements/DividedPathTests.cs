﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.DesignScript.Geometry;
using DSRevitNodes;
using DSRevitNodes.Elements;
using DSRevitNodes.GeometryObjects;
using DSRevitNodes.References;
using NUnit.Framework;
using ArgumentNullException = Autodesk.Revit.Exceptions.ArgumentNullException;

namespace DSRevitNodesTests
{
    [TestFixture]
    class DividedPathTests 
    {
        [Test]
        public void ByCurveAndEqualDivisions_ValidArgs()
        {
            // create spline
            var pts = new Autodesk.DesignScript.Geometry.Point[]
            {
                Point.ByCoordinates(0,0,0),
                Point.ByCoordinates(1,0,0),
                Point.ByCoordinates(3,0,0),
                Point.ByCoordinates(10,0,0)
            };

            var spline = BSplineCurve.ByControlVertices( pts, 3 );
            Assert.NotNull(spline);

            // build model curve from spline
            var modCurve = DSModelCurve.ByPlanarCurve(spline);
            Assert.NotNull(modCurve);

            // build dividedPath
            var divPath = DSDividedPath.ByCurveAndDivisions(modCurve.CurveReference, 5);
            Assert.NotNull(divPath);

        }

        [Test]
        public void ByCurveAndEqualDivisions_NullArgument()
        {
            // build dividedPath
            Assert.Throws(typeof (ArgumentNullException), () => DSDividedPath.ByCurveAndDivisions(null, 5));
        }

        [Test]
        public void ByCurveAndEqualDivisions_InvalidDivisions()
        {
            // create spline
            var pts = new Autodesk.DesignScript.Geometry.Point[]
            {
                Point.ByCoordinates(0,0,0),
                Point.ByCoordinates(1,0,0),
                Point.ByCoordinates(3,0,0),
                Point.ByCoordinates(10,0,0)
            };

            var spline = BSplineCurve.ByControlVertices(pts, 3);
            Assert.NotNull(spline);

            // build model curve from spline
            var modCurve = DSModelCurve.ByPlanarCurve(spline);
            Assert.NotNull(modCurve);

            // build dividedPath
            Assert.Throws(typeof(Exception), () => DSDividedPath.ByCurveAndDivisions(modCurve.CurveReference, 0));

        }
    }
}
