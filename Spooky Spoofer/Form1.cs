using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spooky_Spoofer
{
    public partial class Form1 : Form
    {
        private const int AnimationDuration = 500;
        private const int AnimationSteps = 50;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            await AnimateFadeIn();
        }
        private async Task AnimateFadeIn()
        {
            double stepSize = 1.0 / AnimationSteps;
            double currentOpacity = 0;

            for (int i = 0; i <= AnimationSteps; i++)
            {
                await Task.Delay(AnimationDuration / AnimationSteps);
                currentOpacity += stepSize;
                Opacity = currentOpacity;
            }
        }

            private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string hwid = GetHWID(); 

           guna2Button1.Text = hwid; 
        }
        private string GetHWID()
        {
            string hwid = string.Empty;

            ManagementClass managementClass = new ManagementClass("Win32_ComputerSystemProduct");
            ManagementObjectCollection collection = managementClass.GetInstances();

            foreach (ManagementObject obj in collection)
            {
                hwid = obj["UUID"].ToString();
                break; 
            }
            return hwid;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SpookyHWID.SpoofHWID();
            string message = "...";
            string title = "Spooky Spoofer";
            MessageBoxOptions options = MessageBoxOptions.DefaultDesktopOnly | MessageBoxOptions.RightAlign;
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, options);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string command = "$computerName = \"SpookySpoofer\"; Rename-Computer -NewName $computerName -Force -Restart";
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "powershell.exe";
            startInfo.Arguments = "-NoProfile -ExecutionPolicy Bypass -Command \"" + command + "\"";
            startInfo.Verb = "runas";
            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("xd" + ex.Message);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string gpuName = GetGPUName();
            guna2Button4.Text = gpuName;
        }
        private string GetGPUName()
        {
            string query = "SELECT Name FROM Win32_VideoController";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject mo in searcher.Get())
                {
                    string gpuName = mo["Name"].ToString();
                    return gpuName;
                }
            }
            return "GPU Name Not Found";
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            SpookyCleaner.Gpu();
            string message = "...";
            string title = "Spooky Spoofer";
            MessageBoxOptions options = MessageBoxOptions.DefaultDesktopOnly | MessageBoxOptions.RightAlign;
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, options);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            SpookyOptimizer.SetProcessorAffinity();
            string message = "...";
            string title = "Spooky Spoofer";
            MessageBoxOptions options = MessageBoxOptions.DefaultDesktopOnly | MessageBoxOptions.RightAlign;
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, options);
        }

        private async void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            await AnimateFadeOut();
            Application.Exit(); 
        }
        private async Task AnimateFadeOut()
        {
            double stepSize = 1.0 / AnimationSteps;
            double currentOpacity = 1;

            for (int i = 0; i <= AnimationSteps; i++)
            {
                await Task.Delay(AnimationDuration / AnimationSteps);
                currentOpacity -= stepSize;
                Opacity = currentOpacity;
            }
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
