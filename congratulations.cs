using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prog7312_task1
{
	public partial class congratulations : Form
	{


		//----------------------------------------------START OF CODE ------------------------------------------------------------------------------------//
		/// <summary>
		/// REFERENCE: https://laptrinhvb.net/bai-viet/chuyen-de-csharp/---csharp----chia-se-source-code-firework-effect-trong-winform/5481a0c82f1b246a.html
		/// </summary>
		//----------------------------------------------------------------------------------------------------------------------------------//
		public congratulations()
		{
			InitializeComponent();

			Text = "Fireworks";
			Name = "Fireworks";
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.DoubleBuffer, true);

			ClientSize = new Size(700, 600);
			Timer timer = new Timer();
			timer.Tick += new EventHandler(Tick);
			timer.Interval = UpdateInterval;
			timer.Start();
		}
		//----------------------------------------------------------------------------------------------------------------------------------//

		const int MaxFireWorks = 10;

		firework[] fireworks = new firework[MaxFireWorks];

		static Random rand = new Random();
		//----------------------------------------------------------------------------------------------------------------------------------//

		void Tick(Object o, EventArgs e)
		{

			for (int i = 0; i < MaxFireWorks; ++i)
				if (fireworks[i] != null)
					if (!fireworks[i].Update())
						fireworks[i] = null;

			if (rand.Next(10) == 0)
				for (int i = 0; i < MaxFireWorks; ++i)
					if (fireworks[i] == null)
					{
						fireworks[i] = new firework(ClientRectangle.Width,
									ClientRectangle.Height);
						break;
					}

			Invalidate();

			Update();
		}

		//----------------------------------------------------------------------------------------------------------------------------------//

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.Clear(Color.Black);
			foreach (firework fw in fireworks)
				if (fw != null)
					fw.Paint(e.Graphics);
		}

		const int UpdateInterval = 1;

       
    }
	//----------------------------------------------END OF CODE ------------------------------------------------------------------------------------//


}

