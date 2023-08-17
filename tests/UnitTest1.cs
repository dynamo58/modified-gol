using modified_gol;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        private void AssertCells(Cell[,] c1, Cell[,] c2, int len, string? annot)
        {
            for (int i = 0; i < len; i++)
                for (int j = 0; j < len; j++)
                {
                    Assert.AreEqual(c1[i, j].occupier == null, c2[i, j].occupier == null, annot);
                    if (c1[i, j].occupier == null) continue;
                    Assert.AreEqual(c1[i, j].occupier.kind, c2[i, j].occupier.kind, annot);
                }
        }

        [TestMethod]
        public void TestClassicS23B3Behavior()
        {
            Simulation sim = new Simulation(10,10,10);
            sim.ChangeCellState((0, 1), "healthy");
            sim.AdvanceGeneration();

            AssertCells(sim.cells, (new Simulation(10,10,10)).cells, 10, "S23B3 single healthy unexpected behavior");
            

            sim.ChangeCellState((0, 0), "healthy");
            sim.ChangeCellState((1, 0), "healthy");
            sim.ChangeCellState((1, 1), "healthy");
            
            Simulation sim2 = (Simulation)sim;

            sim.AdvanceGeneration();

            AssertCells(sim.cells, sim2.cells, 10, "S23B3 healthy block unexpected behavior");

            sim = new Simulation(10,10,10);

            sim.ChangeCellState((1, 1), "healthy");
            sim.ChangeCellState((2, 1), "healthy");
            sim.ChangeCellState((3, 1), "healthy");

            sim.ChangeCellState((0, 2), "healthy");
            sim.ChangeCellState((1, 2), "healthy");
            sim.ChangeCellState((2, 2), "healthy");

            Simulation sim3 = (Simulation)sim;

            sim2 = new Simulation(10,10,10);

            sim2.ChangeCellState((0,1), "healthy");
            sim2.ChangeCellState((0,2), "healthy");
            sim2.ChangeCellState((1,3), "healthy");

            sim2.ChangeCellState((2, 0), "healthy");
            sim2.ChangeCellState((3/*3*/, 1), "healthy");
            sim2.ChangeCellState((3, 2), "healthy");

            sim.AdvanceGeneration();
            AssertCells(sim.cells, sim2.cells, 10, "S23B3 P=2 thingie unexpected behavior 1");
            sim.AdvanceGeneration();
            AssertCells(sim.cells, sim3.cells, 10, "S23B3 P=2 thingie unexpected behavior 2");
        }

        [TestMethod]
        public void TestInfectedCell()
        {
            Simulation sim = new Simulation(10,10,10);

            sim.ChangeCellState((0, 0), "infected");

            for (int i = 0; i < Simulation.incubationPeriod; i++)
                sim.AdvanceGeneration();

            Assert.IsTrue(sim.cells[0,0].occupier.kind == Organism.Kind.Healthy || sim.cells[0,0].occupier.kind == Organism.Kind.Aggressive, "infected cell not healthy or aggressive after end of incubation period");
        }

        [TestMethod]
        public void TestAggressiveCell()
        {
            Simulation sim = new Simulation(10, 10, 10);

            sim.ChangeCellState((0, 0), "aggressive");

            for (int i = 0; i < Simulation.hungerStrikeThreshold; i++)
                sim.AdvanceGeneration();

            Assert.IsTrue(sim.cells[0,0].occupier == null, "aggressive cell not dead after hunger threshold reached");

            sim.ChangeCellState((1, 1), "aggressive");

            Simulation sim2 = (Simulation)sim;

            sim.ChangeCellState((0, 0), "healthy");
            sim.ChangeCellState((0, 1), "healthy");
            sim.ChangeCellState((1, 0), "infected");

            sim.AdvanceGeneration();

            AssertCells(sim.cells, sim2.cells, 10, "aggressive not eating unaggressive");
        }
    }
}