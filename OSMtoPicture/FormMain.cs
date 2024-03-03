using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using OSMtoPicture.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OSMtoPicture
{
    public partial class FormMain : Form
    {
        // Program state machine
        private static StateMachine PrgStateMachine = new StateMachine();
        private static Uri WebsiteURL = new Uri("https://www.openstreetmap.org");
        private static string OutputFolder = null;

        public FormMain()
        {
            InitializeComponent();
            SetProgStatus();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Load website
            reloadOSMToolStripMenuItem_Click(null, EventArgs.Empty);
        }

        private void webView_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            // Correct website was loaded
            if (webView.Source == WebsiteURL)
            {
                // Website freshly loaded
                if (PrgStateMachine.GetCurrentState() == ProgramStates.Init)
                {
                    PrgStateMachine.GoToNextState(ProgramTransition.SetInitDone);
                }
                // Coming back from invalid website
                else if (PrgStateMachine.GetCurrentState() == ProgramStates.InvalidURL)
                {
                    PrgStateMachine.GoToNextState(ProgramTransition.SetIdle);
                }

                SetProgStatus();
            }
            // Something else is loaded
            else
            {
                // Is invalid website state already set?
                if (PrgStateMachine.GetCurrentState() != ProgramStates.InvalidURL)
                {
                    PrgStateMachine.GoToNextState(ProgramTransition.SetInvalidURL);
                    SetProgStatus();
                }
            }
        }

        #region Save pictures
        private void backgroundWorker_save_DoWork(object sender, DoWorkEventArgs e)
        {
            string html = (string)e.Argument;

            // Did we recive data?
            if (html == null)
            {
                MessageBox.Show("Could not get get HTML content from website.\nOperation failed", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<OpenSteetMapTile> listOfTiles = new List<OpenSteetMapTile>();
            MatchCollection mc = Regex.Matches(html, @"https:\/\/tile\.openstreetmap\.org\/([0-9]+)\/([0-9]+)\/([0-9]+)\.png");

            int pictureCounter = 0;

            foreach (Match m in mc)
            {
                var tile = new OpenSteetMapTile();
                tile.Adress = m.Groups[0].Value;
                tile.Zoom = m.Groups[1].Value;
                tile.X = m.Groups[2].Value;
                tile.Y = m.Groups[3].Value;
                listOfTiles.Add(tile);

                string zoomFolder = string.Format(@"{0}\{1}", OutputFolder, tile.Zoom);
                string outputPath = string.Format(@"{0}\{1}_{2}_{3}.png", zoomFolder, tile.Zoom, tile.X, tile.Y);
                // Create zoom folder
                if(!Directory.Exists(zoomFolder))
                    Directory.CreateDirectory(zoomFolder);

                // Download only if file does not exist yet
                if (File.Exists(outputPath)) continue;

                WebClient wc = new WebClient();
                wc.Headers.Add("User-Agent: Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");   //that is the simple line!
                wc.DownloadFile(tile.Adress, outputPath);

                pictureCounter++;
            }

            e.Result = pictureCounter;
        }

        private void backgroundWorker_save_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PrgStateMachine.GoToNextState(ProgramTransition.SetIdle);
            SetProgStatus();
            MessageBox.Show($"{(int)e.Result} pictures successfully saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Save OSM to pictures
        /// </summary>
        private async void StartSaveProcessAsync()
        {
            string html = await webView.ExecuteScriptAsync("document.documentElement.outerHTML");
            backgroundWorker_save.RunWorkerAsync(argument: html);
        }

        #endregion

        /// <summary>
        /// Set program status
        /// </summary>
        private void SetProgStatus()
        {
            ProgramStates currentState = PrgStateMachine.GetCurrentState();
            Color c = SystemColors.Control;

            switch (currentState)
            {
                case ProgramStates.Init:
                    toolStripStatusLabel.Text = "Initalizing...";
                    break;
                case ProgramStates.Idle:
                    toolStripStatusLabel.Text = "Ready";
                    savePicturesToolStripMenuItem.Enabled = true;
                    reloadOSMToolStripMenuItem.Enabled = true;
                    changeOutputFolderToolStripMenuItem.Enabled = true;
                    break;
                case ProgramStates.InvalidURL:
                    toolStripStatusLabel.Text = "Invalid URL... Press \"Reload OSM\"";
                    c = Color.OrangeRed;
                    break;
                case ProgramStates.Saving:
                    toolStripStatusLabel.Text = "Saving...";
                    savePicturesToolStripMenuItem.Enabled = false;
                    reloadOSMToolStripMenuItem.Enabled = false;
                    changeOutputFolderToolStripMenuItem.Enabled = false;
                    break;
                default:
                    toolStripStatusLabel.Text = $"ERROR unknown state: {currentState}";
                    c = Color.OrangeRed;
                    break;
            }

            toolStripStatusLabel.BackColor = c;
        }

        /// <summary>
        /// Change output folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeOutputFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select output folder";
            fbd.SelectedPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // User confirmed dialog?
            if (fbd.ShowDialog() != DialogResult.OK) return;
            // Save output folder                
            OutputFolder = fbd.SelectedPath;

            toolStripStatusLabel_OutputFolder.Text = $"Selected output folder: {OutputFolder}";
        }

        /// <summary>
        /// Close program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Reload OSM (Open Street Map) website
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reloadOSMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Load website
            webView.Source = WebsiteURL;
        }

        /// <summary>
        /// Save button pressed - Current view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void savePicturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // No output folder selected
            if (OutputFolder == null)
            {
                changeOutputFolderToolStripMenuItem_Click(null, EventArgs.Empty);
            }

            // Does directory exist?
            if (!Directory.Exists(OutputFolder))
            {
                MessageBox.Show($"Output folder does not exist: \"{OutputFolder}\"?", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OutputFolder = null;
                toolStripStatusLabel_OutputFolder.Text = string.Empty;
                return;
            }

            // Ask for save location
            DialogResult resp = MessageBox.Show($"Download current pictures in this location: \"{OutputFolder}\"?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes != resp) return;

            // Check if folder is empty
            string[] listOfFiles = Directory.GetFiles(OutputFolder);
            string[] listOfFolders = Directory.GetDirectories(OutputFolder);
            if (listOfFiles.Length > 0 || listOfFolders.Length > 0)
            {
                resp = MessageBox.Show($"\"{OutputFolder}\" is not empty.\nContinue?", "Directory not empty", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes != resp) return;
            }

            // Let's save
            PrgStateMachine.GoToNextState(ProgramTransition.SetSaving);
            SetProgStatus();
            StartSaveProcessAsync();

        }
    }
}
