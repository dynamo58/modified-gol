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
            startStop_btn = new Button();
            manual_btn = new Button();
            speed_trackBar = new TrackBar();
            size_trackBar = new TrackBar();
            speed_lbl = new Label();
            size_lbl = new Label();
            randomizeCells_btn = new Button();
            randomizeCells_txtbx = new TextBox();
            clearCells_btn = new Button();
            startStopRecording_btn = new Button();
            saveStateToFile_btn = new Button();
            loadStateFromFile_btn = new Button();
            cells_pnl = new Panel();
            chooser_tabControl = new TabControl();
            healthy_chooserTab = new TabPage();
            button1 = new Button();
            sickPeaceful_chooserTab = new TabPage();
            sickAggresive_chooserTab = new TabPage();
            ((System.ComponentModel.ISupportInitialize)speed_trackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)size_trackBar).BeginInit();
            chooser_tabControl.SuspendLayout();
            healthy_chooserTab.SuspendLayout();
            SuspendLayout();
            // 
            // startStop_btn
            // 
            startStop_btn.ForeColor = Color.Black;
            startStop_btn.Location = new Point(10, 9);
            startStop_btn.Margin = new Padding(3, 2, 3, 2);
            startStop_btn.Name = "startStop_btn";
            startStop_btn.Size = new Size(113, 24);
            startStop_btn.TabIndex = 0;
            startStop_btn.Text = "Start";
            startStop_btn.UseVisualStyleBackColor = true;
            // 
            // manual_btn
            // 
            manual_btn.ForeColor = Color.Black;
            manual_btn.Location = new Point(10, 38);
            manual_btn.Margin = new Padding(3, 2, 3, 2);
            manual_btn.Name = "manual_btn";
            manual_btn.Size = new Size(113, 22);
            manual_btn.TabIndex = 1;
            manual_btn.Text = "Manual";
            manual_btn.UseVisualStyleBackColor = true;
            // 
            // speed_trackBar
            // 
            speed_trackBar.LargeChange = 1;
            speed_trackBar.Location = new Point(74, 74);
            speed_trackBar.Margin = new Padding(3, 2, 3, 2);
            speed_trackBar.Maximum = 100;
            speed_trackBar.Minimum = 1;
            speed_trackBar.Name = "speed_trackBar";
            speed_trackBar.Size = new Size(113, 45);
            speed_trackBar.TabIndex = 2;
            speed_trackBar.TickFrequency = 10;
            speed_trackBar.Value = 1;
            // 
            // size_trackBar
            // 
            size_trackBar.LargeChange = 1;
            size_trackBar.Location = new Point(74, 120);
            size_trackBar.Margin = new Padding(3, 2, 3, 2);
            size_trackBar.Maximum = 100;
            size_trackBar.Minimum = 10;
            size_trackBar.Name = "size_trackBar";
            size_trackBar.Size = new Size(114, 45);
            size_trackBar.TabIndex = 3;
            size_trackBar.TickFrequency = 10;
            size_trackBar.Value = 10;
            // 
            // speed_lbl
            // 
            speed_lbl.AutoSize = true;
            speed_lbl.Location = new Point(10, 81);
            speed_lbl.Name = "speed_lbl";
            speed_lbl.Size = new Size(51, 15);
            speed_lbl.TabIndex = 4;
            speed_lbl.Text = "Speed: 1";
            speed_lbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // size_lbl
            // 
            size_lbl.AutoSize = true;
            size_lbl.Location = new Point(17, 120);
            size_lbl.Name = "size_lbl";
            size_lbl.Size = new Size(45, 15);
            size_lbl.TabIndex = 5;
            size_lbl.Text = "Size: 10";
            size_lbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // randomizeCells_btn
            // 
            randomizeCells_btn.ForeColor = Color.Black;
            randomizeCells_btn.Location = new Point(17, 166);
            randomizeCells_btn.Margin = new Padding(3, 2, 3, 2);
            randomizeCells_btn.Name = "randomizeCells_btn";
            randomizeCells_btn.Size = new Size(124, 22);
            randomizeCells_btn.TabIndex = 6;
            randomizeCells_btn.Text = "Randomize cells";
            randomizeCells_btn.UseVisualStyleBackColor = true;
            // 
            // randomizeCells_txtbx
            // 
            randomizeCells_txtbx.Location = new Point(146, 166);
            randomizeCells_txtbx.Margin = new Padding(3, 2, 3, 2);
            randomizeCells_txtbx.Name = "randomizeCells_txtbx";
            randomizeCells_txtbx.Size = new Size(41, 23);
            randomizeCells_txtbx.TabIndex = 7;
            randomizeCells_txtbx.Text = "10";
            // 
            // clearCells_btn
            // 
            clearCells_btn.ForeColor = Color.Black;
            clearCells_btn.Location = new Point(59, 201);
            clearCells_btn.Margin = new Padding(3, 2, 3, 2);
            clearCells_btn.Name = "clearCells_btn";
            clearCells_btn.Size = new Size(82, 22);
            clearCells_btn.TabIndex = 8;
            clearCells_btn.Text = "Clear cells";
            clearCells_btn.UseVisualStyleBackColor = true;
            // 
            // startStopRecording_btn
            // 
            startStopRecording_btn.ForeColor = Color.Black;
            startStopRecording_btn.Location = new Point(31, 239);
            startStopRecording_btn.Margin = new Padding(3, 2, 3, 2);
            startStopRecording_btn.Name = "startStopRecording_btn";
            startStopRecording_btn.Size = new Size(134, 22);
            startStopRecording_btn.TabIndex = 9;
            startStopRecording_btn.Text = "Start recording";
            startStopRecording_btn.UseVisualStyleBackColor = true;
            // 
            // saveStateToFile_btn
            // 
            saveStateToFile_btn.ForeColor = Color.Black;
            saveStateToFile_btn.Location = new Point(31, 288);
            saveStateToFile_btn.Margin = new Padding(3, 2, 3, 2);
            saveStateToFile_btn.Name = "saveStateToFile_btn";
            saveStateToFile_btn.Size = new Size(134, 22);
            saveStateToFile_btn.TabIndex = 10;
            saveStateToFile_btn.Text = "Save state to file";
            saveStateToFile_btn.UseVisualStyleBackColor = true;
            // 
            // loadStateFromFile_btn
            // 
            loadStateFromFile_btn.ForeColor = Color.Black;
            loadStateFromFile_btn.Location = new Point(31, 314);
            loadStateFromFile_btn.Margin = new Padding(3, 2, 3, 2);
            loadStateFromFile_btn.Name = "loadStateFromFile_btn";
            loadStateFromFile_btn.Size = new Size(134, 22);
            loadStateFromFile_btn.TabIndex = 11;
            loadStateFromFile_btn.Text = "Load state from file";
            loadStateFromFile_btn.UseVisualStyleBackColor = true;
            // 
            // cells_pnl
            // 
            cells_pnl.BorderStyle = BorderStyle.FixedSingle;
            cells_pnl.Location = new Point(272, 11);
            cells_pnl.Margin = new Padding(3, 2, 3, 2);
            cells_pnl.Name = "cells_pnl";
            cells_pnl.Size = new Size(615, 615);
            cells_pnl.TabIndex = 13;
            cells_pnl.Click += cells_pnl_Click;
            cells_pnl.Paint += cells_pnl_Paint;
            // 
            // chooser_tabControl
            // 
            chooser_tabControl.Controls.Add(healthy_chooserTab);
            chooser_tabControl.Controls.Add(sickPeaceful_chooserTab);
            chooser_tabControl.Controls.Add(sickAggresive_chooserTab);
            chooser_tabControl.Location = new Point(12, 358);
            chooser_tabControl.Name = "chooser_tabControl";
            chooser_tabControl.Padding = new Point(6, 6);
            chooser_tabControl.SelectedIndex = 0;
            chooser_tabControl.Size = new Size(239, 268);
            chooser_tabControl.TabIndex = 14;
            // 
            // healthy_chooserTab
            // 
            healthy_chooserTab.BackColor = Color.FromArgb(37, 37, 37);
            healthy_chooserTab.Controls.Add(button1);
            healthy_chooserTab.Location = new Point(4, 30);
            healthy_chooserTab.Name = "healthy_chooserTab";
            healthy_chooserTab.Padding = new Padding(3);
            healthy_chooserTab.Size = new Size(231, 234);
            healthy_chooserTab.TabIndex = 0;
            healthy_chooserTab.Text = "Healthy";
            // 
            // button1
            // 
            button1.ForeColor = Color.Black;
            button1.Location = new Point(50, 88);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // sickPeaceful_chooserTab
            // 
            sickPeaceful_chooserTab.BackColor = Color.FromArgb(37, 37, 37);
            sickPeaceful_chooserTab.Location = new Point(4, 30);
            sickPeaceful_chooserTab.Name = "sickPeaceful_chooserTab";
            sickPeaceful_chooserTab.Padding = new Padding(3);
            sickPeaceful_chooserTab.Size = new Size(231, 234);
            sickPeaceful_chooserTab.TabIndex = 1;
            sickPeaceful_chooserTab.Text = "Sick - Peaceful";
            // 
            // sickAggresive_chooserTab
            // 
            sickAggresive_chooserTab.BackColor = Color.FromArgb(37, 37, 37);
            sickAggresive_chooserTab.Location = new Point(4, 30);
            sickAggresive_chooserTab.Name = "sickAggresive_chooserTab";
            sickAggresive_chooserTab.Padding = new Padding(3);
            sickAggresive_chooserTab.Size = new Size(231, 234);
            sickAggresive_chooserTab.TabIndex = 2;
            sickAggresive_chooserTab.Text = "Sick - aggresive";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(1264, 681);
            Controls.Add(chooser_tabControl);
            Controls.Add(cells_pnl);
            Controls.Add(loadStateFromFile_btn);
            Controls.Add(saveStateToFile_btn);
            Controls.Add(startStopRecording_btn);
            Controls.Add(clearCells_btn);
            Controls.Add(randomizeCells_txtbx);
            Controls.Add(randomizeCells_btn);
            Controls.Add(size_lbl);
            Controls.Add(speed_lbl);
            Controls.Add(size_trackBar);
            Controls.Add(speed_trackBar);
            Controls.Add(manual_btn);
            Controls.Add(startStop_btn);
            ForeColor = Color.WhiteSmoke;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainWindow";
            Text = "Modified Game of Life";
            Load += MainWindow_Load;
            ((System.ComponentModel.ISupportInitialize)speed_trackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)size_trackBar).EndInit();
            chooser_tabControl.ResumeLayout(false);
            healthy_chooserTab.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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