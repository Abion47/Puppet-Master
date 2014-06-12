using System;

public static class Managers
{
	public static PuppetMaster.PathManager PathManager;

	static Managers() 
	{
		PathManager = new PuppetMaster.PathManager();
	}
}

