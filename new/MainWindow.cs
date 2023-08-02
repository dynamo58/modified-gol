using System.Drawing;
using System.Windows.Forms;
using System;

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
            sim = new Simulation(5, speed_trackBar.Value);
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
    }

    [Serializable]
    public class UnreachableException : Exception
    {
        public UnreachableException() { }
        public UnreachableException(string message) : base(message) { }
    }
}