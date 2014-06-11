using System;

using Colls = System.Collections.Generic;

namespace PuppetMaster
{
	public class MPath
	{
		public Colls.List<MPoint> Points { get; private set; }
		public PathType PathType { get; set; }

		public MPath()
		{
			Points = new Colls.List<MPoint>();
		}
	}

	public enum PathType 
	{
		None,
		Line,
		Curve3,
		Curve4
	}
}

