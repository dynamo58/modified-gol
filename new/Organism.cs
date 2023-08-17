using System.Drawing;

namespace modified_gol
{
    abstract public class Organism
    {
        public enum Kind { Dead, Healthy, Infected, Aggressive }
        public Kind kind;

        // performs a computation on what the next state of the cell should be
        public abstract Organism DecideNextState(int healthyNeighborCount);
        // special implementation of the above for empty cells
        public static Organism DecideEmptyCellNextState(int healthyNeighborCount)
        {
            if (healthyNeighborCount > 0 && Simulation.newCellBeBornConds[healthyNeighborCount - 1])
                return new HealthyOrganism();
            return null;
        }

        public static Organism FromStr(string str)
        {
            switch (str)
            {
                case "healthy": return new HealthyOrganism();
                case "infected": return new InfectedOrganism();
                case "aggressive": return new AggressiveOrganism();
                default: throw new UnreachableException();
            }
        }

        // gets a colored brush usng which the cell shall be painted
        public abstract Brush GetBrush();
    }

    // a kind of organism that doesnt interact with surroundings in any way
    public class HealthyOrganism : Organism
    {
        public override Brush GetBrush() => Brushes.Green;

        public override Organism DecideNextState(int healthyNeighborCount)
        {
            // if the org. is unfortunate, infect it
            if (Program._rand.Next(0, 100) < Simulation.sporadicInfectionChance)
                return new InfectedOrganism();

            // if the org. has sufficient amount of neighbors, keep it alive
            if (healthyNeighborCount > 0 && Simulation.surviveConds[healthyNeighborCount - 1])
                return this;

            // default case - kill it
            return null;
        }

        public HealthyOrganism()
        {
            this.kind = Kind.Healthy;
        }
    }

    // an org. that has been infected, eventually it will either die or turn into an aggressive organism
    public class InfectedOrganism : Organism
    {
        public int currentDaysIncubating = 0;

        public override Brush GetBrush() => Brushes.Orange;

        public override Organism DecideNextState(int healthyNeighborCount)
        {
            this.currentDaysIncubating += 1;

            if (this.currentDaysIncubating >= Simulation.incubationPeriod)
            {
                bool cellHeals = Program._rand.Next(1, 101) <  Simulation.chanceOfInfectedHealing;

                return (cellHeals) ? (new HealthyOrganism() as Organism) : (new AggressiveOrganism() as Organism);
            }
            
            return this;
        }

        public InfectedOrganism()
        {
            this.kind = Kind.Infected;
        }
    }

    // an infected organism, that has turned rogue
    public class AggressiveOrganism : Organism
    {
        public int currentHungerStrike = 0;

        public override Brush GetBrush() => Brushes.Red;

        public override Organism DecideNextState(int healthyNeighborCount)
        {
            this.currentHungerStrike += 1;
            // if it  hasn't eaten in a while, it shall die
            return (this.currentHungerStrike == Simulation.hungerStrikeThreshold) ? null : this;
        }

        public AggressiveOrganism()
        {
            this.kind = Kind.Aggressive;
        }
    }
}
