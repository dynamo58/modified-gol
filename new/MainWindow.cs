using System.Drawing;
using System.Windows.Forms;
using System;
using System.IO;
using AnimatedGif;

namespace modified_gol
{
    public partial class MainWindow : Form
    {
        Simulation sim;
        // man I would love to be using an actual good language that
        // could model this stuff; let rec_gif: Option<ImageAnimator> = None;
        // oh well
        bool recording = false;
        AnimatedGif.AnimatedGifCreator gif = null;
        int framerate = 4;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            sim = new Simulation(40, 4, 35);
            this.UpdateEntireUIFromSimulation();
            autoplay_timer.Interval = 1000 / speed_trackBar.Value;
            cells_pnl.Refresh();

            if (!Directory.Exists(Path.GetTempPath() + "\\modified-gol"))
                Directory.CreateDirectory(Path.GetTempPath() + "\\modified-gol");
        }

        private void UpdateEntireUIFromSimulation()
        {
            speed_trackBar.Value = sim.speed;
            speed_lbl.Text = $"Speed: {speed_trackBar.Value}";

            size_trackBar.Value = sim.boardSize;
            size_lbl.Text = $"Size: {size_trackBar.Value}";

            bRuleset_txtbx.Text = Utils.FlattenArrayOfBoolsToNumbers(Simulation.newCellBeBornConds);
            sRuleset_txtbx.Text = Utils.FlattenArrayOfBoolsToNumbers(Simulation.surviveConds);

            incubationPeriod_txtbx.Text = Simulation.incubationPeriod.ToString();
            chanceOfHealing_txtbx.Text = Simulation.chanceOfInfectedHealing.ToString();

            sporadicInfectionChance_txtbx.Text = Simulation.sporadicInfectionChance.ToString();

            randomizeCells_txtbx.Text = sim.randomizationFactor.ToString();

            cells_pnl.Refresh();
        }

        private void cells_pnl_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            int width = (cells_pnl.Width - 2) / sim.boardSize;

            for (int i = 0; i < sim.boardSize; i++)
                for (int j = 0; j < sim.boardSize; j++)
                {
                    if (sim.cells[i, j].occupier == null) continue;
                    canvas.FillRectangle(sim.cells[i, j].occupier.GetBrush(), width * i, width * j, width, width);
                }
        }

        private void cells_pnl_Click(object sender, EventArgs e)
        {
            var coords = cells_pnl.PointToClient(Cursor.Position);

            (int x, int y) = (
                (int)Math.Floor(((coords.X) / (double)((cells_pnl.Width - 2) / sim.boardSize))),
                (int)Math.Floor(((coords.Y) / (double)((cells_pnl.Width - 2) / sim.boardSize)))
            );

            if (x >= sim.boardSize || y >= sim.boardSize) return;

            if (sim.cells[x, y].occupier != null)
            {
                int width = (cells_pnl.Width - 2) / sim.boardSize;
                cells_pnl.Invalidate(new Rectangle(width * x, width * y, width, width));
                sim.cells[x, y].occupier = null;
            }
            else
            {
                Organism newCell;
                switch (chooser_tabControl.SelectedTab.Name)
                {
                    case "healthy_chooserTab":
                        newCell = new HealthyOrganism();
                        break;
                    case "infected_chooserTab":
                        newCell = new InfectedOrganism();
                        break;
                    case "aggressive_chooserTab":
                        newCell = new AggressiveOrganism();
                        break;
                    default:
                        throw new UnreachableException("THIS IS UNREACHABLE");
                };

                Graphics canvas = cells_pnl.CreateGraphics();
                int width = (cells_pnl.Width - 2) / sim.boardSize;
                canvas.FillRectangle(newCell.GetBrush(), width * x, width * y, width, width);
                sim.cells[x, y].occupier = newCell;
                cells_pnl.Refresh();
            }
        }

        private void manual_btn_Click(object sender, EventArgs e)
        {
            sim.AdvanceGeneration();
            this.WriteCellsToGif();
            cells_pnl.Refresh();
        }

        private void speed_trackBar_Scroll(object sender, EventArgs e)
        {
            sim.speed = speed_trackBar.Value;
            autoplay_timer.Interval = 1000 / speed_trackBar.Value;
            speed_lbl.Text = $"Speed: {speed_trackBar.Value}";
        }

        private void size_trackBar_Scroll(object sender, EventArgs e)
        {
            sim.Resize(size_trackBar.Value);
            size_lbl.Text = $"Size: {size_trackBar.Value}";
            cells_pnl.Refresh();
        }

        private void startStop_btn_Click(object sender, EventArgs e)
        {
            autoplay_timer.Enabled = !autoplay_timer.Enabled;
            startStop_btn.Text = (autoplay_timer.Enabled) ? "Stop" : "Start";
        }

        private void autoplay_timer_Tick(object sender, EventArgs e)
        {
            sim.AdvanceGeneration();
            if (recording) this.WriteCellsToGif();
            cells_pnl.Refresh();
        }

        private void randomizeCells_btn_Click(object sender, EventArgs e)
        {
            sim.RandomizeCells();
            cells_pnl.Refresh();
        }

        private void randomizeCells_txtbx_TextChanged(object sender, EventArgs e)
        {
            int newVal;
            bool result = int.TryParse(randomizeCells_txtbx.Text, out newVal);

            if (!result || (newVal < 1) || (newVal > 100))
            {
                MessageBox.Show("Value must be an integer between 1 and 100");
                randomizeCells_txtbx.Text = sim.randomizationFactor.ToString();
            }
            else
                sim.randomizationFactor = newVal;
        }

        private void saveStateToFile_btn_Click(object sender, EventArgs e)
        {
            if (simulation_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(simulation_saveFileDialog.FileName))
                    File.Create(simulation_saveFileDialog.FileName).Close();

                File.WriteAllText(simulation_saveFileDialog.FileName, sim.ToJSON());
            }
        }

        private void loadStateFromFile_btn_Click(object sender, EventArgs e)
        {
            if (simulation_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = simulation_openFileDialog.FileName;
                
                if (!File.Exists(path))
                {
                    MessageBox.Show("The specified file does not exist!");
                    return;
                }

                sim = Simulation.DeserializeFromFile(path);
                UpdateEntireUIFromSimulation();
            }
        }

        // handle recording switching
        private void startStopRecording_btn_Click(object sender, EventArgs e)
        {
            recording = !recording;
            startStopRecording_btn.Text = (recording) ? "Stop recording" : "Start recording";

            // setup the recording process
            if (recording)
            {
                string path = Path.GetTempPath() + "\\modified-gol\\temp.gif";
                this.gif = AnimatedGif.AnimatedGif.Create(path, 1000 / this.framerate);
                framerate_txtBox.Enabled = false;
                this.WriteCellsToGif();
            }
            // if the recording has been stopped
            else
            {
                gif.Dispose();
                if (simulationGIF_saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = simulationGIF_saveFileDialog.FileName;
                    File.Copy(Path.GetTempPath() + "\\modified-gol\\temp.gif", path);
                    File.Delete(Path.GetTempPath() + "\\modified-gol\\temp.gif");
                }
                framerate_txtBox.Enabled = true;
            }
        }

        // append a frame to the already-existing GIF file
        private void WriteCellsToGif()
        {
            if (!this.recording) return;
            int width = cells_pnl.Size.Width;
            int height = cells_pnl.Size.Height;
            Bitmap bm = new Bitmap(width, height);
            cells_pnl.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
            this.gif.AddFrame(bm, delay: -1, quality: GifQuality.Bit8);
        }

        private void framerate_txtBox_TextChanged(object sender, EventArgs e)
        {
            bool result = int.TryParse(framerate_txtBox.Text, out int newVal);

            if (!result || (newVal < 1) || (newVal > 100))
            {
                MessageBox.Show("Value must be an integer between 1 and 100");
                framerate_txtBox.Text = sim.randomizationFactor.ToString();
            }
            else
                this.framerate = newVal;
        }

        private void sRuleset_txtbx_TextChanged(object sender, EventArgs e)
        {
            bool[] newVal = new bool[9] {
                false, false, false, false, false, false, false, false, false
            };

            foreach (char c in sRuleset_txtbx.Text)
            {
                bool result = int.TryParse(c.ToString(), out int val);

                if (!result || (val < 1) || (val > 9))
                {
                    MessageBox.Show("Value must be numbers 1 - 9 in any arrangement, with any of them missing");
                    sRuleset_txtbx.Text = Utils.FlattenArrayOfBoolsToNumbers(Simulation.surviveConds);
                    return;
                }

                newVal[val - 1] = true;
            }

            Simulation.surviveConds = newVal;
        }

        private void bRuleset_txtbx_TextChanged(object sender, EventArgs e)
        {
            bool[] newVal = new bool[9] {
                false, false, false, false, false, false, false, false, false
            };

            foreach (char c in bRuleset_txtbx.Text)
            {
                bool result = int.TryParse(c.ToString(), out int val);

                if (!result || (val < 1) || (val > 9))
                {
                    MessageBox.Show("Value must be numbers 1 - 9 in any arrangement, with any of them missing");
                    sRuleset_txtbx.Text = Utils.FlattenArrayOfBoolsToNumbers(Simulation.newCellBeBornConds);
                    return;
                }

                newVal[val - 1] = true;
            }

            Simulation.newCellBeBornConds = newVal;
        }

        private void incubationPeriod_txtbx_TextChanged(object sender, EventArgs e)
        {
            bool result = int.TryParse(incubationPeriod_txtbx.Text, out int newVal);

            if (!result || (newVal < 0))
            {
                MessageBox.Show("Value must be an integer greater or equal to 0.");
                incubationPeriod_txtbx.Text = Simulation.incubationPeriod.ToString();
            }
            else
                Simulation.incubationPeriod = newVal;
        }

        private void chanceOfHealing_txtbx_TextChanged(object sender, EventArgs e)
        {
            bool result = int.TryParse(chanceOfHealing_txtbx.Text, out int newVal);

            if (!result || (newVal < 0) || (newVal > 100))
            {
                MessageBox.Show("Value must be an integer between 0 and 100.");
                chanceOfHealing_txtbx.Text = Simulation.chanceOfInfectedHealing.ToString();
            }
            else
                Simulation.chanceOfInfectedHealing = newVal;
        }

        private void sporadicInfectionChance_txtbx_TextChanged(object sender, EventArgs e)
        {
            bool result = int.TryParse(sporadicInfectionChance_txtbx.Text, out int newVal);

            if (!result || (newVal < 0) || (newVal > 100))
            {
                MessageBox.Show("Value must be an integer between 0 and 100.");
                sporadicInfectionChance_txtbx.Text = Simulation.sporadicInfectionChance.ToString();
            }
            else
                Simulation.sporadicInfectionChance = newVal;
        }

        private void hungerStrikeThreshold_txtbx_TextChanged(object sender, EventArgs e)
        {
            bool result = int.TryParse(hungerStrikeThreshold_txtbx.Text, out int newVal);

            if (!result || (newVal < 0))
            {
                MessageBox.Show("Value must be an integer greater or equal to 0.");
                hungerStrikeThreshold_txtbx.Text = Simulation.hungerStrikeThreshold.ToString();
            }
            else
                Simulation.hungerStrikeThreshold = newVal;
        }
    }

    [Serializable]
    public class UnreachableException : Exception
    {
        public UnreachableException() { }
        public UnreachableException(string message) : base(message) { }
    }
}