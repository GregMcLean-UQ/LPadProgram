using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LLogger
	{
	static class Program
		{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
			{
			try
				{
				Boolean canRun = false;
				string argument = "";
				System.Threading.Mutex mutex = new System.Threading.Mutex(true, "Mutex", out canRun);
				if (canRun)
					{
					if (args.Count() > 0)
						argument = args[0];
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.Run(new mainForm(argument));
					//--Tell the Garbage collector not to dispose this mutex
					GC.KeepAlive(mutex);
					}
				else
					{
					MessageBox.Show("LLogger is already running.", "LLogger", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			catch (Exception ex)
				{
				MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			finally
				{
				//your logic
				}

			}
		}
	}
