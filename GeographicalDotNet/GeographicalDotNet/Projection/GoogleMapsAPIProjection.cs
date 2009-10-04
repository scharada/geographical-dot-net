using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Projection
{
    public class GoogleMapsAPIProjection : IProjection
    {
        private readonly double PixelTileSize = 256d;
        private readonly double DegreesToRadiansFactor = Math.PI / 180d;
        private readonly double RadiansToDegreesFactor = 180d / Math.PI;
        private PointF Fx;
        private double Hx;
        private double Ix;

        public GoogleMapsAPIProjection(double zoomLevel)
        {
            var c = this.PixelTileSize * Math.Pow(2d, zoomLevel);
            var e = Convert.ToSingle(c / 2d);
            this.Hx = c / 360d;
            this.Ix = c / (2d * Math.PI);
            this.Fx = new PointF(e, e);
        }

        #region IProjection Members

        public PointF FromCoordinatesToPixel(PointF coordinates)
        {
            var d = this.Fx;
            var e = Math.Round(d.X + (coordinates.X * this.Hx));
            var f = Math.Min(Math.Max(Math.Sin(coordinates.Y * DegreesToRadiansFactor), -0.9999d), 0.9999d);
            var g = Math.Round(d.Y + .5d * Math.Log((1d + f) / (1d - f)) * -this.Ix);
            return new PointF(Convert.ToSingle(e), Convert.ToSingle(g));
        }

        public PointF FromPixelToCoordinates(PointF pixel)
        {
            var e = this.Fx;
            var f = (pixel.X - e.X) / this.Hx;
            var g = (pixel.Y - e.Y) / -this.Ix;
            var h = (2 * Math.Atan(Math.Exp(g)) - Math.PI / 2) * RadiansToDegreesFactor;
            return new PointF(Convert.ToSingle(h), Convert.ToSingle(f));
        }

        #endregion
    }
}