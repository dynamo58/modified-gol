﻿using static System.Net.Mime.MediaTypeNames;
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
            this.components = new System.ComponentModel.Container();
            this.startStop_btn = new System.Windows.Forms.Button();
            this.manual_btn = new System.Windows.Forms.Button();
            this.speed_trackBar = new System.Windows.Forms.TrackBar();
            this.size_trackBar = new System.Windows.Forms.TrackBar();
            this.speed_lbl = new System.Windows.Forms.Label();
            this.size_lbl = new System.Windows.Forms.Label();
            this.randomizeCells_btn = new System.Windows.Forms.Button();
            this.clearCells_btn = new System.Windows.Forms.Button();
            this.startStopRecording_btn = new System.Windows.Forms.Button();
            this.saveStateToFile_btn = new System.Windows.Forms.Button();
            this.loadStateFromFile_btn = new System.Windows.Forms.Button();
            this.cells_pnl = new System.Windows.Forms.Panel();
            this.chooser_tabControl = new System.Windows.Forms.TabControl();
            this.healthy = new System.Windows.Forms.TabPage();
            this.sporadicInfectionChance_txtbx = new System.Windows.Forms.TextBox();
            this.sporadicInfectionChance_lbl = new System.Windows.Forms.Label();
            this.bRuleset_txtbx = new System.Windows.Forms.TextBox();
            this.sRuleset_txtbx = new System.Windows.Forms.TextBox();
            this.bRuleset_lbl = new System.Windows.Forms.Label();
            this.sRuleset_lbl = new System.Windows.Forms.Label();
            this.infected = new System.Windows.Forms.TabPage();
            this.chanceOfAggression_lbl = new System.Windows.Forms.Label();
            this.chanceOfHealing_txtbx = new System.Windows.Forms.TextBox();
            this.incubationPeriod_txtbx = new System.Windows.Forms.TextBox();
            this.incubationPeriod_lbl = new System.Windows.Forms.Label();
            this.aggressive = new System.Windows.Forms.TabPage();
            this.hungerStrikeThreshold_txtbx = new System.Windows.Forms.TextBox();
            this.hungerStrikeThreshold_lbl = new System.Windows.Forms.Label();
            this.autoplay_timer = new System.Windows.Forms.Timer(this.components);
            this.randomizeCells_txtbx = new System.Windows.Forms.TextBox();
            this.simulation_saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.simulation_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.simulationGIF_saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.framerate_txtBox = new System.Windows.Forms.TextBox();
            this.currentGenerationPre_lbl = new System.Windows.Forms.Label();
            this.currentGenerationVal_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.speed_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.size_trackBar)).BeginInit();
            this.chooser_tabControl.SuspendLayout();
            this.healthy.SuspendLayout();
            this.infected.SuspendLayout();
            this.aggressive.SuspendLayout();
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
            this.startStop_btn.Click += new System.EventHandler(this.startStop_btn_Click);
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
            this.speed_trackBar.Value = 10;
            this.speed_trackBar.Scroll += new System.EventHandler(this.speed_trackBar_Scroll);
            // 
            // size_trackBar
            // 
            this.size_trackBar.LargeChange = 1;
            this.size_trackBar.Location = new System.Drawing.Point(62, 96);
            this.size_trackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.size_trackBar.Maximum = 100;
            this.size_trackBar.Minimum = 10;
            this.size_trackBar.Name = "size_trackBar";
            this.size_trackBar.Size = new System.Drawing.Size(98, 45);
            this.size_trackBar.TabIndex = 3;
            this.size_trackBar.TickFrequency = 10;
            this.size_trackBar.Value = 10;
            this.size_trackBar.Scroll += new System.EventHandler(this.size_trackBar_Scroll);
            // 
            // speed_lbl
            // 
            this.speed_lbl.AutoSize = true;
            this.speed_lbl.Location = new System.Drawing.Point(6, 64);
            this.speed_lbl.Name = "speed_lbl";
            this.speed_lbl.Size = new System.Drawing.Size(56, 13);
            this.speed_lbl.TabIndex = 4;
            this.speed_lbl.Text = "Speed: 10";
            this.speed_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // size_lbl
            // 
            this.size_lbl.AutoSize = true;
            this.size_lbl.Location = new System.Drawing.Point(6, 96);
            this.size_lbl.Name = "size_lbl";
            this.size_lbl.Size = new System.Drawing.Size(45, 13);
            this.size_lbl.TabIndex = 5;
            this.size_lbl.Text = "Size: 10";
            this.size_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // randomizeCells_btn
            // 
            this.randomizeCells_btn.ForeColor = System.Drawing.Color.Black;
            this.randomizeCells_btn.Location = new System.Drawing.Point(9, 145);
            this.randomizeCells_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.randomizeCells_btn.Name = "randomizeCells_btn";
            this.randomizeCells_btn.Size = new System.Drawing.Size(106, 19);
            this.randomizeCells_btn.TabIndex = 6;
            this.randomizeCells_btn.Text = "Randomize cells";
            this.randomizeCells_btn.UseVisualStyleBackColor = true;
            this.randomizeCells_btn.Click += new System.EventHandler(this.randomizeCells_btn_Click);
            // 
            // clearCells_btn
            // 
            this.clearCells_btn.ForeColor = System.Drawing.Color.Black;
            this.clearCells_btn.Location = new System.Drawing.Point(9, 184);
            this.clearCells_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearCells_btn.Name = "clearCells_btn";
            this.clearCells_btn.Size = new System.Drawing.Size(70, 19);
            this.clearCells_btn.TabIndex = 8;
            this.clearCells_btn.Text = "Clear cells";
            this.clearCells_btn.UseVisualStyleBackColor = true;
            this.clearCells_btn.Click += new System.EventHandler(this.clearCells_btn_Click);
            // 
            // startStopRecording_btn
            // 
            this.startStopRecording_btn.ForeColor = System.Drawing.Color.Black;
            this.startStopRecording_btn.Location = new System.Drawing.Point(9, 230);
            this.startStopRecording_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startStopRecording_btn.Name = "startStopRecording_btn";
            this.startStopRecording_btn.Size = new System.Drawing.Size(91, 19);
            this.startStopRecording_btn.TabIndex = 9;
            this.startStopRecording_btn.Text = "Start recording";
            this.startStopRecording_btn.UseVisualStyleBackColor = true;
            this.startStopRecording_btn.Click += new System.EventHandler(this.startStopRecording_btn_Click);
            // 
            // saveStateToFile_btn
            // 
            this.saveStateToFile_btn.ForeColor = System.Drawing.Color.Black;
            this.saveStateToFile_btn.Location = new System.Drawing.Point(9, 320);
            this.saveStateToFile_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveStateToFile_btn.Name = "saveStateToFile_btn";
            this.saveStateToFile_btn.Size = new System.Drawing.Size(106, 19);
            this.saveStateToFile_btn.TabIndex = 10;
            this.saveStateToFile_btn.Text = "Save state to file";
            this.saveStateToFile_btn.UseVisualStyleBackColor = true;
            this.saveStateToFile_btn.Click += new System.EventHandler(this.saveStateToFile_btn_Click);
            // 
            // loadStateFromFile_btn
            // 
            this.loadStateFromFile_btn.ForeColor = System.Drawing.Color.Black;
            this.loadStateFromFile_btn.Location = new System.Drawing.Point(9, 297);
            this.loadStateFromFile_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadStateFromFile_btn.Name = "loadStateFromFile_btn";
            this.loadStateFromFile_btn.Size = new System.Drawing.Size(107, 19);
            this.loadStateFromFile_btn.TabIndex = 11;
            this.loadStateFromFile_btn.Text = "Load state from file";
            this.loadStateFromFile_btn.UseVisualStyleBackColor = true;
            this.loadStateFromFile_btn.Click += new System.EventHandler(this.loadStateFromFile_btn_Click);
            // 
            // cells_pnl
            // 
            this.cells_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cells_pnl.Location = new System.Drawing.Point(196, 33);
            this.cells_pnl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cells_pnl.Name = "cells_pnl";
            this.cells_pnl.Size = new System.Drawing.Size(527, 533);
            this.cells_pnl.TabIndex = 13;
            this.cells_pnl.Click += new System.EventHandler(this.cells_pnl_Click);
            this.cells_pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.cells_pnl_Paint);
            // 
            // chooser_tabControl
            // 
            this.chooser_tabControl.Controls.Add(this.healthy);
            this.chooser_tabControl.Controls.Add(this.infected);
            this.chooser_tabControl.Controls.Add(this.aggressive);
            this.chooser_tabControl.Location = new System.Drawing.Point(12, 369);
            this.chooser_tabControl.Name = "chooser_tabControl";
            this.chooser_tabControl.Padding = new System.Drawing.Point(6, 6);
            this.chooser_tabControl.SelectedIndex = 0;
            this.chooser_tabControl.Size = new System.Drawing.Size(178, 197);
            this.chooser_tabControl.TabIndex = 14;
            // 
            // healthy
            // 
            this.healthy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.healthy.Controls.Add(this.sporadicInfectionChance_txtbx);
            this.healthy.Controls.Add(this.sporadicInfectionChance_lbl);
            this.healthy.Controls.Add(this.bRuleset_txtbx);
            this.healthy.Controls.Add(this.sRuleset_txtbx);
            this.healthy.Controls.Add(this.bRuleset_lbl);
            this.healthy.Controls.Add(this.sRuleset_lbl);
            this.healthy.Location = new System.Drawing.Point(4, 28);
            this.healthy.Name = "healthy";
            this.healthy.Padding = new System.Windows.Forms.Padding(3);
            this.healthy.Size = new System.Drawing.Size(170, 165);
            this.healthy.TabIndex = 0;
            this.healthy.Text = "Healthy";
            // 
            // sporadicInfectionChance_txtbx
            // 
            this.sporadicInfectionChance_txtbx.Location = new System.Drawing.Point(67, 119);
            this.sporadicInfectionChance_txtbx.Name = "sporadicInfectionChance_txtbx";
            this.sporadicInfectionChance_txtbx.Size = new System.Drawing.Size(45, 20);
            this.sporadicInfectionChance_txtbx.TabIndex = 20;
            this.sporadicInfectionChance_txtbx.TextChanged += new System.EventHandler(this.sporadicInfectionChance_txtbx_TextChanged);
            // 
            // sporadicInfectionChance_lbl
            // 
            this.sporadicInfectionChance_lbl.AutoSize = true;
            this.sporadicInfectionChance_lbl.Location = new System.Drawing.Point(6, 103);
            this.sporadicInfectionChance_lbl.Name = "sporadicInfectionChance_lbl";
            this.sporadicInfectionChance_lbl.Size = new System.Drawing.Size(131, 13);
            this.sporadicInfectionChance_lbl.TabIndex = 19;
            this.sporadicInfectionChance_lbl.Text = "Sporadic infection chance";
            // 
            // bRuleset_txtbx
            // 
            this.bRuleset_txtbx.Location = new System.Drawing.Point(67, 44);
            this.bRuleset_txtbx.Name = "bRuleset_txtbx";
            this.bRuleset_txtbx.Size = new System.Drawing.Size(51, 20);
            this.bRuleset_txtbx.TabIndex = 18;
            this.bRuleset_txtbx.TextChanged += new System.EventHandler(this.bRuleset_txtbx_TextChanged);
            // 
            // sRuleset_txtbx
            // 
            this.sRuleset_txtbx.Location = new System.Drawing.Point(67, 18);
            this.sRuleset_txtbx.Name = "sRuleset_txtbx";
            this.sRuleset_txtbx.Size = new System.Drawing.Size(51, 20);
            this.sRuleset_txtbx.TabIndex = 17;
            this.sRuleset_txtbx.TextChanged += new System.EventHandler(this.sRuleset_txtbx_TextChanged);
            // 
            // bRuleset_lbl
            // 
            this.bRuleset_lbl.AutoSize = true;
            this.bRuleset_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bRuleset_lbl.Location = new System.Drawing.Point(6, 42);
            this.bRuleset_lbl.Name = "bRuleset_lbl";
            this.bRuleset_lbl.Size = new System.Drawing.Size(55, 15);
            this.bRuleset_lbl.TabIndex = 2;
            this.bRuleset_lbl.Text = "B ruleset";
            // 
            // sRuleset_lbl
            // 
            this.sRuleset_lbl.AutoSize = true;
            this.sRuleset_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sRuleset_lbl.Location = new System.Drawing.Point(6, 18);
            this.sRuleset_lbl.Name = "sRuleset_lbl";
            this.sRuleset_lbl.Size = new System.Drawing.Size(55, 15);
            this.sRuleset_lbl.TabIndex = 1;
            this.sRuleset_lbl.Text = "S ruleset";
            // 
            // infected
            // 
            this.infected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.infected.Controls.Add(this.chanceOfAggression_lbl);
            this.infected.Controls.Add(this.chanceOfHealing_txtbx);
            this.infected.Controls.Add(this.incubationPeriod_txtbx);
            this.infected.Controls.Add(this.incubationPeriod_lbl);
            this.infected.Location = new System.Drawing.Point(4, 28);
            this.infected.Name = "infected";
            this.infected.Padding = new System.Windows.Forms.Padding(3);
            this.infected.Size = new System.Drawing.Size(170, 165);
            this.infected.TabIndex = 1;
            this.infected.Text = "Infected";
            // 
            // chanceOfAggression_lbl
            // 
            this.chanceOfAggression_lbl.AutoSize = true;
            this.chanceOfAggression_lbl.Location = new System.Drawing.Point(6, 37);
            this.chanceOfAggression_lbl.Name = "chanceOfAggression_lbl";
            this.chanceOfAggression_lbl.Size = new System.Drawing.Size(93, 13);
            this.chanceOfAggression_lbl.TabIndex = 3;
            this.chanceOfAggression_lbl.Text = "Chance of healing";
            // 
            // chanceOfHealing_txtbx
            // 
            this.chanceOfHealing_txtbx.Location = new System.Drawing.Point(101, 34);
            this.chanceOfHealing_txtbx.Name = "chanceOfHealing_txtbx";
            this.chanceOfHealing_txtbx.Size = new System.Drawing.Size(42, 20);
            this.chanceOfHealing_txtbx.TabIndex = 2;
            this.chanceOfHealing_txtbx.TextChanged += new System.EventHandler(this.chanceOfHealing_txtbx_TextChanged);
            // 
            // incubationPeriod_txtbx
            // 
            this.incubationPeriod_txtbx.Location = new System.Drawing.Point(101, 10);
            this.incubationPeriod_txtbx.Name = "incubationPeriod_txtbx";
            this.incubationPeriod_txtbx.Size = new System.Drawing.Size(42, 20);
            this.incubationPeriod_txtbx.TabIndex = 1;
            this.incubationPeriod_txtbx.TextChanged += new System.EventHandler(this.incubationPeriod_txtbx_TextChanged);
            // 
            // incubationPeriod_lbl
            // 
            this.incubationPeriod_lbl.AutoSize = true;
            this.incubationPeriod_lbl.Location = new System.Drawing.Point(6, 13);
            this.incubationPeriod_lbl.Name = "incubationPeriod_lbl";
            this.incubationPeriod_lbl.Size = new System.Drawing.Size(89, 13);
            this.incubationPeriod_lbl.TabIndex = 0;
            this.incubationPeriod_lbl.Text = "Incubation period";
            // 
            // aggressive
            // 
            this.aggressive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.aggressive.Controls.Add(this.hungerStrikeThreshold_txtbx);
            this.aggressive.Controls.Add(this.hungerStrikeThreshold_lbl);
            this.aggressive.Location = new System.Drawing.Point(4, 28);
            this.aggressive.Name = "aggressive";
            this.aggressive.Padding = new System.Windows.Forms.Padding(3);
            this.aggressive.Size = new System.Drawing.Size(170, 165);
            this.aggressive.TabIndex = 2;
            this.aggressive.Text = "Aggressive";
            // 
            // hungerStrikeThreshold_txtbx
            // 
            this.hungerStrikeThreshold_txtbx.Location = new System.Drawing.Point(35, 29);
            this.hungerStrikeThreshold_txtbx.Name = "hungerStrikeThreshold_txtbx";
            this.hungerStrikeThreshold_txtbx.Size = new System.Drawing.Size(45, 20);
            this.hungerStrikeThreshold_txtbx.TabIndex = 1;
            this.hungerStrikeThreshold_txtbx.TextChanged += new System.EventHandler(this.hungerStrikeThreshold_txtbx_TextChanged);
            // 
            // hungerStrikeThreshold_lbl
            // 
            this.hungerStrikeThreshold_lbl.AutoSize = true;
            this.hungerStrikeThreshold_lbl.Location = new System.Drawing.Point(6, 13);
            this.hungerStrikeThreshold_lbl.Name = "hungerStrikeThreshold_lbl";
            this.hungerStrikeThreshold_lbl.Size = new System.Drawing.Size(116, 13);
            this.hungerStrikeThreshold_lbl.TabIndex = 0;
            this.hungerStrikeThreshold_lbl.Text = "Hunger strike threshold";
            // 
            // autoplay_timer
            // 
            this.autoplay_timer.Tick += new System.EventHandler(this.autoplay_timer_Tick);
            // 
            // randomizeCells_txtbx
            // 
            this.randomizeCells_txtbx.Location = new System.Drawing.Point(121, 144);
            this.randomizeCells_txtbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.randomizeCells_txtbx.Name = "randomizeCells_txtbx";
            this.randomizeCells_txtbx.Size = new System.Drawing.Size(36, 20);
            this.randomizeCells_txtbx.TabIndex = 7;
            this.randomizeCells_txtbx.Text = "10";
            this.randomizeCells_txtbx.TextChanged += new System.EventHandler(this.randomizeCells_txtbx_TextChanged);
            // 
            // simulation_saveFileDialog
            // 
            this.simulation_saveFileDialog.AddExtension = false;
            this.simulation_saveFileDialog.DefaultExt = "json";
            this.simulation_saveFileDialog.FileName = "mySimulation";
            // 
            // simulation_openFileDialog
            // 
            this.simulation_openFileDialog.AddExtension = false;
            this.simulation_openFileDialog.DefaultExt = "json";
            // 
            // simulationGIF_saveFileDialog
            // 
            this.simulationGIF_saveFileDialog.AddExtension = false;
            this.simulationGIF_saveFileDialog.DefaultExt = "gif";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Framerate:";
            // 
            // framerate_txtBox
            // 
            this.framerate_txtBox.Location = new System.Drawing.Point(82, 250);
            this.framerate_txtBox.Name = "framerate_txtBox";
            this.framerate_txtBox.Size = new System.Drawing.Size(31, 20);
            this.framerate_txtBox.TabIndex = 16;
            this.framerate_txtBox.Text = "4";
            this.framerate_txtBox.TextChanged += new System.EventHandler(this.framerate_txtBox_TextChanged);
            // 
            // currentGenerationPre_lbl
            // 
            this.currentGenerationPre_lbl.AutoSize = true;
            this.currentGenerationPre_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.currentGenerationPre_lbl.Location = new System.Drawing.Point(504, 7);
            this.currentGenerationPre_lbl.Name = "currentGenerationPre_lbl";
            this.currentGenerationPre_lbl.Size = new System.Drawing.Size(146, 20);
            this.currentGenerationPre_lbl.TabIndex = 17;
            this.currentGenerationPre_lbl.Text = "Current generation:";
            // 
            // currentGenerationVal_lbl
            // 
            this.currentGenerationVal_lbl.AutoSize = true;
            this.currentGenerationVal_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.currentGenerationVal_lbl.Location = new System.Drawing.Point(656, 9);
            this.currentGenerationVal_lbl.Name = "currentGenerationVal_lbl";
            this.currentGenerationVal_lbl.Size = new System.Drawing.Size(18, 20);
            this.currentGenerationVal_lbl.TabIndex = 18;
            this.currentGenerationVal_lbl.Text = "0";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.currentGenerationVal_lbl);
            this.Controls.Add(this.currentGenerationPre_lbl);
            this.Controls.Add(this.framerate_txtBox);
            this.Controls.Add(this.label1);
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
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.Text = "Modified Game of Life";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.speed_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.size_trackBar)).EndInit();
            this.chooser_tabControl.ResumeLayout(false);
            this.healthy.ResumeLayout(false);
            this.healthy.PerformLayout();
            this.infected.ResumeLayout(false);
            this.infected.PerformLayout();
            this.aggressive.ResumeLayout(false);
            this.aggressive.PerformLayout();
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
        private Button clearCells_btn;
        private Button startStopRecording_btn;
        private Button saveStateToFile_btn;
        private Button loadStateFromFile_btn;
        private Panel cells_pnl;
        private TabControl chooser_tabControl;
        private TabPage healthy;
        private TabPage infected;
        private TabPage aggressive;
        private Timer autoplay_timer;
        private TextBox randomizeCells_txtbx;
        private SaveFileDialog simulation_saveFileDialog;
        private OpenFileDialog simulation_openFileDialog;
        private SaveFileDialog simulationGIF_saveFileDialog;
        private Label label1;
        private TextBox framerate_txtBox;
        private Label sRuleset_lbl;
        private Label bRuleset_lbl;
        private TextBox bRuleset_txtbx;
        private TextBox sRuleset_txtbx;
        private TextBox incubationPeriod_txtbx;
        private Label incubationPeriod_lbl;
        private Label chanceOfAggression_lbl;
        private TextBox chanceOfHealing_txtbx;
        private Label sporadicInfectionChance_lbl;
        private TextBox sporadicInfectionChance_txtbx;
        private TextBox hungerStrikeThreshold_txtbx;
        private Label hungerStrikeThreshold_lbl;
        private Label currentGenerationPre_lbl;
        private Label currentGenerationVal_lbl;
    }
}