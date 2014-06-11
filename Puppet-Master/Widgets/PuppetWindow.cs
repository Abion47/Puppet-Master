using System;

using Colls = System.Collections.Generic;

namespace PuppetMaster
{
	[System.ComponentModel.ToolboxItem(true)]
	public class PuppetWindow : Gtk.DrawingArea
	{
		public Colls.List<MPath> Paths { get; private set; }

		public PuppetWindow()
		{
			Paths = new Colls.List<MPath>();
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
				context.SetSourceRGB(1, 1, 1);
				context.Rectangle(ev.Area.X, ev.Area.Y, ev.Area.Width, ev.Area.Height);
				context.Fill();

				context.SetSourceRGB(0, 0, 0);
				context.Rectangle(ev.Area.Width / 2 - 50, ev.Area.Height / 2 - 50, 100, 100);
				context.Fill();
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

