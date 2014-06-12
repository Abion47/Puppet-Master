using System;

using Colls = System.Collections.Generic;

namespace PuppetMaster
{
	public class MPath
	{
		public Colls.List<MPoint> Points { get; private set; }
		public double T { get; set; }
		public bool Closed { get; set; }

		private PathType _pathType;
		public PathType PathType 
		{ 
			get
			{
				return this._pathType;
			}
			set
			{
				this._pathType = value;
				switch(_pathType) 
				{
					case PathType.None:
						Paint = null;
						break;
					case PathType.Line:
						Paint = PaintLine;
						break;
					case PathType.Curve:
						Paint = PaintCurve;
						break;
				}
			}
		}

		public delegate bool PaintMethod(Cairo.Context context);
		public PaintMethod Paint;

		public MPath()
		{
			Points = new Colls.List<MPoint>();
		}

		private bool PaintLine(Cairo.Context context)
		{
			if(Points.Count < 2)
				return false;

			context.MoveTo(Points[0].GetPoint(T));

			for (int i = 1; i < Points.Count; i++) 
			{
				context.LineTo(Points[i].GetPoint(T));
			}

			if(Closed)
				context.ClosePath();

			return true;
		}

		private bool PaintCurve(Cairo.Context context)
		{
			context.MoveTo(Points[0].GetPoint(T));

			for (int i = 1; i < Points.Count; i += 3) 
			{
				context.CurveTo(Points[i].GetPoint(T), 
					Points[i + 1].GetPoint(T), 
					Points[i + 2].GetPoint(T));
			}

			if(Closed)
				context.ClosePath();

			return true;
		}
	}

	public enum PathType 
	{
		None,
		Line,
		Curve
	}
}

