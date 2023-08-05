using System.Drawing;
using System.Windows.Forms;
using System;
using System.IO;
using System.Text.Json.Nodes;

namespace modified_gol
{
    public partial class MainWindow : Form
    {
        Simulation sim;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            sim = new Simulation(size_trackBar.Value, speed_trackBar.Value, int.Parse(randomizeCells_txtbx.Text));
            autoplay_timer.Interval = 1000 / speed_trackBar.Value;
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
                    case "sickPeaceful_chooserTab":
                        newCell = new PeacefulSickOrganism();
                        break;
                    case "sickAggresive_chooserTab":
                        newCell = new AggresiveSickOrganism();
                        break;
                    default:
                        throw new UnreachableException("THIS SHOULD NEVER BE REACHED");
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

            if (!result)
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

        private void UpdateEntireUIFromSimulation()
        {
            speed_trackBar.Value = sim.speed;
            speed_lbl.Text = $"Speed: {speed_trackBar.Value}";

            size_trackBar.Value = sim.boardSize;
            size_lbl.Text = $"Size: {size_trackBar.Value}";

            randomizeCells_txtbx.Text = sim.randomizationFactor.ToString();

            cells_pnl.Refresh();
        }
    }

    [Serializable]
    public class UnreachableException : Exception
    {
        public UnreachableException() { }
        public UnreachableException(string message) : base(message) { }
    }
}