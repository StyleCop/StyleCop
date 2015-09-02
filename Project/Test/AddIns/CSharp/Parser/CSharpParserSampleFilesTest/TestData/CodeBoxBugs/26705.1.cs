//-----------------------------------------------------------------------
// <copyright file="ArrowHeadGenerator.cs" company="Microsoft">
//   (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Microsoft.VisualStudio.Diagrams.Layout;
using Microsoft.VisualStudio.Graph.View.TextOnPath;
using Microsoft.VisualStudio.Graph.ViewModel;

namespace Microsoft.VisualStudio.Graph.View
{
    public static class EdgeDecoratorGenerator
    {
        /// <summary>
        /// Converts an edge geometry into a truncated and scaled geometry plus a power-scaled arrowhead.
        /// </summary>
        public static readonly IMultiValueConverter GeneratePathGeometry = new MultiValueConverter((values, type, parameter, culture) =>
        {
            var geometry = values[0] as Geometry;
            var scale = 1.0;
            if (values.Count() > 1 && values[1] is double)
            {
                scale = (double)values[1];
            }
            IEnumerable<IEdgeLabel> labels = null;
            if (values.Count() > 2)
            {
                labels = values[2] as IEnumerable<IEdgeLabel>;
            }
            var scaling = true;
            if (values.Count() > 3 && values[3] is bool)
            {
                scaling = (bool)values[3];
            }
            var thickness = 1.0;
            if (values.Count() > 4)
            {
                var t = values[4];
                if (t is double)
                {
                    thickness = (double)t;
                }
                if (t is string)
                {
                    thickness = double.Parse((string)t);
                }
            }
            var size = Convert.ToDouble(parameter, culture);
            var path = new PathGeometry();
            if (geometry != null)
            {
                if (labels != null)
                {
                    foreach (var l in labels)
                    {
                        if (l.PointsUpToDate)
                        {
                            var label = l as EdgeLabelModelElement;
                            path.AddGeometry(label.PathGeometry);
                        }
                    }
                }
                path.AddGeometry(geometry);
                var length = path.GetFlattenedPathLength();
                if (length > 0)
                {
                    path.Transform = new ScaleTransform(scale, scale);
                    var s = Math.Pow(scale, 0.3);
                    // Todo: Change this to a circular clip instead of a path-length truncation.
                    var fraction = 1 - size / s / length;

                    Point endPoint;
                    Point basePoint;
                    Point tangentPoint;
                    path.GetPointAtFractionLength(1, out endPoint, out tangentPoint);
                    path.GetPointAtFractionLength(fraction, out basePoint, out tangentPoint);
                    var vector = endPoint - basePoint;

                    return new
                    {
                        Path = path,
                        Progress = fraction,
                        Thickness = scaling ? scale * thickness : thickness,
                        ArrowPath = new PathGeometry
                        {
                            Figures =
                            {
                                new PathFigure
                                {
                                    StartPoint = endPoint,
                                    Segments =
                                    {
                                        new LineSegment
                                        {
                                            Point = endPoint - vector + vector.RotatedBy(90) / 2,
                                        },
                                        new LineSegment
                                        {
                                            Point = endPoint - vector - vector.RotatedBy(90) / 2,
                                        },
                                    },
                                    IsClosed = true,
                                },
                            },
                        },
                    };
                }
            }

            return DependencyProperty.UnsetValue;

        });
    }
}

