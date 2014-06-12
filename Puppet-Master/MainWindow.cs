using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();

		var puppetWindow = new PuppetMaster.PuppetWindow();
		puppetWindow.SetSizeRequest(300, 300);

		PuppetMaster.MPoint p1 = new PuppetMaster.MPoint(100, 100, 200, 100);
		PuppetMaster.MPoint p2 = new PuppetMaster.MPoint(200, 100, 200, 200);
		PuppetMaster.MPoint p3 = new PuppetMaster.MPoint(200, 200, 100, 200);
		PuppetMaster.MPoint p4 = new PuppetMaster.MPoint(100, 200, 100, 100);

		PuppetMaster.MPath path = new PuppetMaster.MPath();
		path.PathType = PuppetMaster.PathType.Line;
		path.Points.Add(p1);
		path.Points.Add(p2);
		path.Points.Add(p3);
		path.Points.Add(p4);
		int pathIdx = Managers.PathManager.AddPath(path);

		puppetWindow.Paths.Add(pathIdx);

		var scale = new HScale(0, 1, 0.05);
		scale.SetSizeRequest(200, 35);
		scale.ValueChanged += (sender, e) => 
		{
			Managers.PathManager.GetPath(pathIdx).T = scale.Value;
			puppetWindow.QueueDraw();
		};

		Fixed fix = new Fixed();
		fix.Put(puppetWindow, 5, 5);
		fix.Put(scale, 315, 5);

		this.Add(fix);

		this.ShowAll();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}
}
