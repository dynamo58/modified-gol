using System.Drawing;
using System.Windows.Forms;
using System;

namespace modified_gol
{
    [Serializable]
    public class UnreachableException : Exception
    {
        public UnreachableException() { }
        public UnreachableException(string message) : base(message) { }
    }

    public partial class MainWindow : Form
    {
        Simulation sim;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            sim = new Simulation(size_trackBar.Value, speed_trackBar.Value);
            cells_pnl.Refresh();

            System.Diagnostics.Debug.WriteLine("test");
            System.Diagnostics.Debug.WriteLine((new HealthyOrganism()).GetBrush().ToString());
            System.Diagnostics.Debug.WriteLine((new PeacefulSickOrganism()).GetBrush().ToString());
            System.Diagnostics.Debug.WriteLine((new AggresiveSickOrganism()).GetBrush().ToString());
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

            System.Diagnostics.Debug.WriteLine(chooser_tabControl.SelectedTab.Name);

            (int x, int y) = (
                (int)Math.Floor(((coords.X) / (double)((cells_pnl.Width - 2) / sim.boardSize))),
                (int)Math.Floor(((coords.Y) / (double)((cells_pnl.Width - 2) / sim.boardSize)))
            );

            if (sim.cells[x, y].occupier != null)
            {
                int width = (cells_pnl.Width - 2) / sim.boardSize;
                cells_pnl.Invalidate(new Rectangle(width * x, width * y, width, width));
                sim.cells[x, y].occupier = null;

            }
            else
            {
                Graphics canvas = cells_pnl.CreateGraphics();
                int width = (cells_pnl.Width - 2) / sim.boardSize;
                canvas.FillRectangle(Brushes.Red, width * x, width * y, width, width);
            }

            //panel1.Refresh();
        }
    }
}