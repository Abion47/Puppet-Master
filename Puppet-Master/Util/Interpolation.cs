using System;

namespace PuppetMaster.Util
{
	public static class Interpolation
	{
		public static double Lerp(double a, double b, double t)
		{
			return (1 - t) * a + t * b;
		}
	}
}

