using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();

		var puppetWindow = new PuppetMaster.PuppetWindow();
		puppetWindow.SetSizeRequest(300, 300);

		//PuppetMaster.MPoint p1 = new PuppetMaster.MPoint(69.75, 86.75, 122.314, 73.709);
		PuppetMaster.MPoint p1 = new PuppetMaster.MPoint(69.75, 86.75);
		PuppetMaster.MPoint p2 = new PuppetMaster.MPoint(156.091, 96.165, 176, 66.5);
		PuppetMaster.MPoint p3 = new PuppetMaster.MPoint(156.091, 96.165, 211, 113.5);
		//PuppetMaster.MPoint p4 = new PuppetMaster.MPoint(230.25,104.25 , 188.314,154.709);
		PuppetMaster.MPoint p4 = new PuppetMaster.MPoint(230.25, 104.25);
		PuppetMaster.MPoint p5 = new PuppetMaster.MPoint(228.212, 150, 151, 136);
		PuppetMaster.MPoint p6 = new PuppetMaster.MPoint(228.212, 150, 195.335, 230.5);
		//PuppetMaster.MPoint p7 = new PuppetMaster.MPoint(225.75, 205.25, 127.814, 207.709);
		PuppetMaster.MPoint p7 = new PuppetMaster.MPoint(225.75, 205.25);
		PuppetMaster.MPoint p8 = new PuppetMaster.MPoint(172.959, 208.906, 77.5, 186);
		PuppetMaster.MPoint p9 = new PuppetMaster.MPoint(172.959, 208.906, 103, 114.5);
		//PuppetMaster.MPoint p10 = new PuppetMaster.MPoint(110.25, 213.25, 130.814, 142.709);
		PuppetMaster.MPoint p10 = new PuppetMaster.MPoint(110.25, 213.25);
		PuppetMaster.MPoint p11 = new PuppetMaster.MPoint(89.373, 148.043, 140.5, 106.5);
		PuppetMaster.MPoint p12 = new PuppetMaster.MPoint(89.373, 148.043, 77, 96);
		//PuppetMaster.MPoint p13 = new PuppetMaster.MPoint(69.75, 86.75, 122.314, 73.709);
		PuppetMaster.MPoint p13 = new PuppetMaster.MPoint(69.75, 86.75);

		PuppetMaster.MPath path = new PuppetMaster.MPath();
		path.PathType = PuppetMaster.PathType.Curve;
		path.Closed = true;
		path.Points.Add(p1);
		path.Points.Add(p2);
		path.Points.Add(p3);
		path.Points.Add(p4);
		path.Points.Add(p5);
		path.Points.Add(p6);
		path.Points.Add(p7);
		path.Points.Add(p8);
		path.Points.Add(p9);
		path.Points.Add(p10);
		path.Points.Add(p11);
		path.Points.Add(p12);
		path.Points.Add(p13);
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
