using System;
using Colls = System.Collections.Generic;

namespace PuppetMaster
{
	public class PathManager
	{
		private Colls.Dictionary<int, MPath> PathReference;
		private int count = 0;

		public PathManager()
		{
			PathReference = new Colls.Dictionary<int, MPath>();
		}

		public int AddPath(MPath path) 
		{
			int idx = count++;
			PathReference.Add(idx, path);
			return idx;
		}

		public MPath GetPath(int idx) 
		{
			if(!PathReference.ContainsKey(idx))
				return null;

			return PathReference[idx];
		}
	}
}

