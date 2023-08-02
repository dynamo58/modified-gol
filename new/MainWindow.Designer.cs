using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace modified_gol
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startStop_btn = new System.Windows.Forms.Button();
            this.manual_btn = new System.Windows.Forms.Button();
            this.speed_trackBar = new System.Windows.Forms.TrackBar();
            this.size_trackBar = new System.Windows.Forms.TrackBar();
            this.speed_lbl = new System.Windows.Forms.Label();
            this.size_lbl = new System.Windows.Forms.Label();
            this.randomizeCells_btn = new System.Windows.Forms.Button();
            this.randomizeCells_txtbx = new System.Windows.Forms.TextBox();
            this.clearCells_btn = new System.Windows.Forms.Button();
            this.startStopRecording_btn = new System.Windows.Forms.Button();
            this.saveStateToFile_btn = new System.Windows.Forms.Button();
            this.loadStateFromFile_btn = new System.Windows.Forms.Button();
            this.cells_pnl = new System.Windows.Forms.Panel();
            this.chooser_tabControl = new System.Windows.Forms.TabControl();
            this.healthy_chooserTab = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.sickPeaceful_chooserTab = new System.Windows.Forms.TabPage();
            this.sickAggresive_chooserTab = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.speed_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.size_trackBar)).BeginInit();
            this.chooser_tabControl.SuspendLayout();
            this.healthy_chooserTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // startStop_btn
            // 
            this.startStop_btn.ForeColor = System.Drawing.Color.Black;
            this.startStop_btn.Location = new System.Drawing.Point(9, 8);
            this.startStop_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startStop_btn.Name = "startStop_btn";
            this.startStop_btn.Size = new System.Drawing.Size(97, 21);
            this.startStop_btn.TabIndex = 0;
            this.startStop_btn.Text = "Start";
            this.startStop_btn.UseVisualStyleBackColor = true;
            // 
            // manual_btn
            // 
            this.manual_btn.ForeColor = System.Drawing.Color.Black;
            this.manual_btn.Location = new System.Drawing.Point(9, 33);
            this.manual_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.manual_btn.Name = "manual_btn";
            this.manual_btn.Size = new System.Drawing.Size(97, 19);
            this.manual_btn.TabIndex = 1;
            this.manual_btn.Text = "Manual";
            this.manual_btn.UseVisualStyleBackColor = true;
            this.manual_btn.Click += new System.EventHandler(this.manual_btn_Click);
            // 
            // speed_trackBar
            // 
            this.speed_trackBar.LargeChange = 1;
            this.speed_trackBar.Location = new System.Drawing.Point(63, 64);
            this.speed_trackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.speed_trackBar.Maximum = 100;
            this.speed_trackBar.Minimum = 1;
            this.speed_trackBar.Name = "speed_trackBar";
            this.speed_trackBar.Size = new System.Drawing.Size(97, 45);
            this.speed_trackBar.TabIndex = 2;
            this.speed_trackBar.TickFrequency = 10;
            this.speed_trackBar.Value = 1;
            // 
            // size_trackBar
            // 
            this.size_trackBar.LargeChange = 1;
            this.size_trackBar.Location = new System.Drawing.Point(63, 104);
            this.size_trackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.size_trackBar.Maximum = 100;
            this.size_trackBar.Minimum = 10;
            this.size_trackBar.Name = "size_trackBar";
            this.size_trackBar.Size = new System.Drawing.Size(98, 45);
            this.size_trackBar.TabIndex = 3;
            this.size_trackBar.TickFrequency = 10;
            this.size_trackBar.Value = 10;
            // 
            // speed_lbl
            // 
            this.speed_lbl.AutoSize = true;
            this.speed_lbl.Location = new System.Drawing.Point(9, 70);
            this.speed_lbl.Name = "speed_lbl";
            this.speed_lbl.Size = new System.Drawing.Size(50, 13);
            this.speed_lbl.TabIndex = 4;
            this.speed_lbl.Text = "Speed: 1";
            this.speed_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // size_lbl
            // 
            this.size_lbl.AutoSize = true;
            this.size_lbl.Location = new System.Drawing.Point(15, 104);
            this.size_lbl.Name = "size_lbl";
            this.size_lbl.Size = new System.Drawing.Size(45, 13);
            this.size_lbl.TabIndex = 5;
            this.size_lbl.Text = "Size: 10";
            this.size_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // randomizeCells_btn
            // 
            this.randomizeCells_btn.ForeColor = System.Drawing.Color.Black;
            this.randomizeCells_btn.Location = new System.Drawing.Point(15, 144);
            this.randomizeCells_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.randomizeCells_btn.Name = "randomizeCells_btn";
            this.randomizeCells_btn.Size = new System.Drawing.Size(106, 19);
            this.randomizeCells_btn.TabIndex = 6;
            this.randomizeCells_btn.Text = "Randomize cells";
            this.randomizeCells_btn.UseVisualStyleBackColor = true;
            // 
            // randomizeCells_txtbx
            // 
            this.randomizeCells_txtbx.Location = new System.Drawing.Point(125, 144);
            this.randomizeCells_txtbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.randomizeCells_txtbx.Name = "randomizeCells_txtbx";
            this.randomizeCells_txtbx.Size = new System.Drawing.Size(36, 20);
            this.randomizeCells_txtbx.TabIndex = 7;
            this.randomizeCells_txtbx.Text = "10";
            // 
            // clearCells_btn
            // 
            this.clearCells_btn.ForeColor = System.Drawing.Color.Black;
            this.clearCells_btn.Location = new System.Drawing.Point(51, 174);
            this.clearCells_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearCells_btn.Name = "clearCells_btn";
            this.clearCells_btn.Size = new System.Drawing.Size(70, 19);
            this.clearCells_btn.TabIndex = 8;
            this.clearCells_btn.Text = "Clear cells";
            this.clearCells_btn.UseVisualStyleBackColor = true;
            // 
            // startStopRecording_btn
            // 
            this.startStopRecording_btn.ForeColor = System.Drawing.Color.Black;
            this.startStopRecording_btn.Location = new System.Drawing.Point(27, 207);
            this.startStopRecording_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startStopRecording_btn.Name = "startStopRecording_btn";
            this.startStopRecording_btn.Size = new System.Drawing.Size(115, 19);
            this.startStopRecording_btn.TabIndex = 9;
            this.startStopRecording_btn.Text = "Start recording";
            this.startStopRecording_btn.UseVisualStyleBackColor = true;
            // 
            // saveStateToFile_btn
            // 
            this.saveStateToFile_btn.ForeColor = System.Drawing.Color.Black;
            this.saveStateToFile_btn.Location = new System.Drawing.Point(27, 250);
            this.saveStateToFile_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveStateToFile_btn.Name = "saveStateToFile_btn";
            this.saveStateToFile_btn.Size = new System.Drawing.Size(115, 19);
            this.saveStateToFile_btn.TabIndex = 10;
            this.saveStateToFile_btn.Text = "Save state to file";
            this.saveStateToFile_btn.UseVisualStyleBackColor = true;
            // 
            // loadStateFromFile_btn
            // 
            this.loadStateFromFile_btn.ForeColor = System.Drawing.Color.Black;
            this.loadStateFromFile_btn.Location = new System.Drawing.Point(27, 272);
            this.loadStateFromFile_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadStateFromFile_btn.Name = "loadStateFromFile_btn";
            this.loadStateFromFile_btn.Size = new System.Drawing.Size(115, 19);
            this.loadStateFromFile_btn.TabIndex = 11;
            this.loadStateFromFile_btn.Text = "Load state from file";
            this.loadStateFromFile_btn.UseVisualStyleBackColor = true;
            // 
            // cells_pnl
            // 
            this.cells_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cells_pnl.Location = new System.Drawing.Point(233, 10);
            this.cells_pnl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cells_pnl.Name = "cells_pnl";
            this.cells_pnl.Size = new System.Drawing.Size(527, 533);
            this.cells_pnl.TabIndex = 13;
            this.cells_pnl.Click += new System.EventHandler(this.cells_pnl_Click);
            this.cells_pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.cells_pnl_Paint);
            // 
            // chooser_tabControl
            // 
            this.chooser_tabControl.Controls.Add(this.healthy_chooserTab);
            this.chooser_tabControl.Controls.Add(this.sickPeaceful_chooserTab);
            this.chooser_tabControl.Controls.Add(this.sickAggresive_chooserTab);
            this.chooser_tabControl.Location = new System.Drawing.Point(10, 310);
            this.chooser_tabControl.Name = "chooser_tabControl";
            this.chooser_tabControl.Padding = new System.Drawing.Point(6, 6);
            this.chooser_tabControl.SelectedIndex = 0;
            this.chooser_tabControl.Size = new System.Drawing.Size(205, 232);
            this.chooser_tabControl.TabIndex = 14;
            // 
            // healthy_chooserTab
            // 
            this.healthy_chooserTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.healthy_chooserTab.Controls.Add(this.button1);
            this.healthy_chooserTab.Location = new System.Drawing.Point(4, 28);
            this.healthy_chooserTab.Name = "healthy_chooserTab";
            this.healthy_chooserTab.Padding = new System.Windows.Forms.Padding(3);
            this.healthy_chooserTab.Size = new System.Drawing.Size(197, 200);
            this.healthy_chooserTab.TabIndex = 0;
            this.healthy_chooserTab.Text = "Healthy";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(43, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // sickPeaceful_chooserTab
            // 
            this.sickPeaceful_chooserTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.sickPeaceful_chooserTab.Location = new System.Drawing.Point(4, 28);
            this.sickPeaceful_chooserTab.Name = "sickPeaceful_chooserTab";
            this.sickPeaceful_chooserTab.Padding = new System.Windows.Forms.Padding(3);
            this.sickPeaceful_chooserTab.Size = new System.Drawing.Size(197, 200);
            this.sickPeaceful_chooserTab.TabIndex = 1;
            this.sickPeaceful_chooserTab.Text = "Sick - Peaceful";
            // 
            // sickAggresive_chooserTab
            // 
            this.sickAggresive_chooserTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.sickAggresive_chooserTab.Location = new System.Drawing.Point(4, 28);
            this.sickAggresive_chooserTab.Name = "sickAggresive_chooserTab";
            this.sickAggresive_chooserTab.Padding = new System.Windows.Forms.Padding(3);
            this.sickAggresive_chooserTab.Size = new System.Drawing.Size(197, 200);
            this.sickAggresive_chooserTab.TabIndex = 2;
            this.sickAggresive_chooserTab.Text = "Sick - aggresive";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1083, 590);
            this.Controls.Add(this.chooser_tabControl);
            this.Controls.Add(this.cells_pnl);
            this.Controls.Add(this.loadStateFromFile_btn);
            this.Controls.Add(this.saveStateToFile_btn);
            this.Controls.Add(this.startStopRecording_btn);
            this.Controls.Add(this.clearCells_btn);
            this.Controls.Add(this.randomizeCells_txtbx);
            this.Controls.Add(this.randomizeCells_btn);
            this.Controls.Add(this.size_lbl);
            this.Controls.Add(this.speed_lbl);
            this.Controls.Add(this.size_trackBar);
            this.Controls.Add(this.speed_trackBar);
            this.Controls.Add(this.manual_btn);
            this.Controls.Add(this.startStop_btn);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.Text = "Modified Game of Life";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.speed_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.size_trackBar)).EndInit();
            this.chooser_tabControl.ResumeLayout(false);
            this.healthy_chooserTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button startStop_btn;
        private Button manual_btn;
        private TrackBar speed_trackBar;
        private TrackBar size_trackBar;
        private Label speed_lbl;
        private Label size_lbl;
        private Button randomizeCells_btn;
        private TextBox randomizeCells_txtbx;
        private Button clearCells_btn;
        private Button startStopRecording_btn;
        private Button saveStateToFile_btn;
        private Button loadStateFromFile_btn;
        private Panel cells_pnl;
        private TabControl chooser_tabControl;
        private TabPage healthy_chooserTab;
        private TabPage sickPeaceful_chooserTab;
        private Button button1;
        private TabPage sickAggresive_chooserTab;
    }
}