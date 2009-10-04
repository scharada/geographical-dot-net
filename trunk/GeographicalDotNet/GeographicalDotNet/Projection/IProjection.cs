using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Projection
{
    public interface IProjection
    {
        PointF FromCoordinatesToPixel(PointF coordinates);
        PointF FromPixelToCoordinates(PointF pixel);
    }
}