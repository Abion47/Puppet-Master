using System;

using Colls = System.Collections.Generic;

namespace PuppetMaster
{
	[System.ComponentModel.ToolboxItem(true)]
	public class PuppetWindow : Gtk.DrawingArea
	{
		public Colls.List<int> Paths { get; private set; }

		public PuppetWindow()
		{
			Paths = new Colls.List<int>();
		}

		protected override bool OnButtonPressEvent(Gdk.EventButton ev)
		{
			// Insert button press handling code here.
			return base.OnButtonPressEvent(ev);
		}

		protected override bool OnExposeEvent(Gdk.EventExpose ev)
		{
			base.OnExposeEvent(ev);

			using (Cairo.Context context = Gdk.CairoHelper.Create(ev.Window))
			{
				context.Rectangle(ev.Area.X, ev.Area.Y, ev.Area.Width, ev.Area.Height);
				context.SetSourceRGB(1, 1, 1);
				context.Fill();

				foreach (int i in Paths) 
				{
					MPath path = Managers.PathManager.GetPath(i);

					if(path == null)
						continue;

					path.Paint(context);
					context.SetSourceRGB(0, 0, 0);
					context.LineWidth = 5;
					context.Stroke();
				}
			}

			return true;
		}

		protected override void OnSizeAllocated(Gdk.Rectangle allocation)
		{
			base.OnSizeAllocated(allocation);
			// Insert layout code here.
		}

		protected override void OnSizeRequested(ref Gtk.Requisition requisition)
		{
			// Calculate desired size here.
			requisition.Height = 50;
			requisition.Width = 50;
		}
	}
}

