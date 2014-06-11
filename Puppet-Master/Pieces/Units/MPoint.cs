using System;

namespace PuppetMaster
{
	public class MPoint
	{
		private Cairo.PointD a, b;

		public MPoint() : this(new Cairo.PointD(double.NaN, double.NaN), new Cairo.PointD(double.NaN, double.NaN)) {}
		public MPoint(double x, double y) : this(new Cairo.PointD(x, y), new Cairo.PointD(double.NaN, double.NaN)) {}
		public MPoint(double x1, double y1, double x2, double y2) : this(new Cairo.PointD(x1, y1), new Cairo.PointD(x2, y2)) {}
		public MPoint(Cairo.PointD p) : this(p, new Cairo.PointD(double.NaN, double.NaN)) {}
		public MPoint(Cairo.PointD p1, Cairo.PointD p2)
		{
			this.a = p1;
			this.b = p2;
		}

		public Cairo.PointD GetPoint(double t = -1) 
		{
			if(double.IsNaN(b.X) || double.IsNaN(b.Y) || t < 0)
				return a;

			return new Cairo.PointD(
				Util.Interpolation.Lerp(a.X, b.X, t),
				Util.Interpolation.Lerp(a.Y, b.Y, t));
		}
	}
}

