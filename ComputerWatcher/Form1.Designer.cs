using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace ComputerWatcher
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        ///
        //public double Details()
        //{
        //    var processes = Process.GetProcesses();
        //    foreach (var p in processes)
        //    {
        //        PerformanceCounter ramCounter = new PerformanceCounter("Process", "Working Set", p.ProcessName);
        //        PerformanceCounter cpuCounter = new PerformanceCounter("Process", "% Processor Time", p.ProcessName);


        //        var processNames = new PerformanceCounterCategory("Process").GetInstanceNames();



        //        Thread.Sleep(1000);
        //        double ram = ramCounter.NextValue();
        //        double cpu = cpuCounter.NextValue();
        //        Console.WriteLine($"{p.ProcessName}, {p.Id}");
        //        Console.WriteLine("RAM: " + (ram / 1024 / 1024) + " MB; CPU: " + (cpu) + " %");
        //        Console.WriteLine("***********************************************");



        //    }
        //}

        private Dictionary<int, (PerformanceCounter cpu, PerformanceCounter ram)> counters = new();

        private void PopulateRows(Process[] processes)
        {

            
            listViewProcesses.Items.Clear();

            foreach (var p in processes)
            {
                var ramCounter = new PerformanceCounter("Process", "Working Set", p.ProcessName);
                var cpuCounter = new PerformanceCounter("Process", "% Processor Time", p.ProcessName);


                var item = new ListViewItem(p.ProcessName);
                item.SubItems.Add(p.Id.ToString());
                item.SubItems.Add("0"); // CPU placeholder
                item.SubItems.Add("0"); // CPU placeholder
                listViewProcesses.Items.Add(item);

                counters[p.Id] = (cpuCounter, ramCounter);
            }
        }
        private void InitializeComponent()
        {
            this.listViewProcesses = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listViewProcesses
            // 
            this.listViewProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewProcesses.Location = new System.Drawing.Point(0, 0);
            this.listViewProcesses.Name = "listViewProcesses";
            this.listViewProcesses.Size = new System.Drawing.Size(984, 561);
            this.listViewProcesses.TabIndex = 0;
            this.listViewProcesses.UseCompatibleStateImageBehavior = false;

            // UX improvements
            this.listViewProcesses.View = System.Windows.Forms.View.Details;
            this.listViewProcesses.FullRowSelect = true;
            this.listViewProcesses.GridLines = true;
            this.listViewProcesses.MultiSelect = false;
            this.listViewProcesses.HideSelection = false;
            this.listViewProcesses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Clickable;
            this.listViewProcesses.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            // Columns: daha uygun genişlikler ve sağ hizalı sayısal sütunlar
            this.listViewProcesses.Columns.Add("Process Name", 420, HorizontalAlignment.Left);
            this.listViewProcesses.Columns.Add("PID", 80, HorizontalAlignment.Left);
            this.listViewProcesses.Columns.Add("CPU (%)", 100, HorizontalAlignment.Right);
            this.listViewProcesses.Columns.Add("RAM (MB)", 120, HorizontalAlignment.Right);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.listViewProcesses);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "Form1";
            this.Text = "Computer Watcher";
            this.ResumeLayout(false);
        }


        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    PopulateRows(Process.GetProcesses()); // sadece satır ekle
        //    //timerUpdate.Start();                   // CPU/RAM güncelleme için
        //}

        #endregion

        private System.Windows.Forms.ListView listViewProcesses;
    }
}

