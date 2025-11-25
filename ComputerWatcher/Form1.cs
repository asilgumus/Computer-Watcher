using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace ComputerWatcher
{
    public partial class Form1 : Form
    {
        // PID -> (CPU, RAM) counter eşlemesi

        public Form1()
        {
            InitializeComponent();
            PopulateRows(Process.GetProcesses());

            // Timer ayarı
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000; // 1 saniye
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewProcesses.Items)
            {
                int pid = int.Parse(item.SubItems[1].Text);
                if (!counters.ContainsKey(pid)) continue;

                try
                {
                    var (cpuCounter, ramCounter) = counters[pid];
                    double ram = ramCounter.NextValue() / 1024 / 1024;
                    double cpu = cpuCounter.NextValue();

                    item.SubItems[2].Text = cpu.ToString("0.0");
                    item.SubItems[3].Text = ram.ToString("0.0");
                }
                catch (InvalidOperationException)
                {
                    // Process kapandı veya counter artık geçerli değil
                    item.SubItems[2].Text = "0";
                    item.SubItems[3].Text = "0";
                }
            }
        }
    }
}
