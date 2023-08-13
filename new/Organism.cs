using System;
using System.Drawing;
using System.Linq;
using System.Text.Json.Serialization;

namespace modified_gol
{
    abstract internal class Organism
    {
        public enum Kind { Dead, Healthy, Infected, PeacefulSick, AggresiveSick }
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

        // gets a colored brush usng which the cell shall be painted
        public abstract Brush GetBrush();
    }

    internal class HealthyOrganism : Organism
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

    internal class InfectedOrganism : Organism
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

    internal class AggressiveOrganism : Organism
    {
        // how many days without "eating" for an aggressive cell to die
        public int currentHungerStrike = 0;

        public override Brush GetBrush() => Brushes.Red;

        public override Organism DecideNextState(int healthyNeighborCount)
        {
            this.currentHungerStrike += 1;
            // if the org. hasn't eaten in a while, it shall die
            return (this.currentHungerStrike == Simulation.hungerStrikeThreshold) ? null : this;
        }

        public AggressiveOrganism()
        {
            this.kind = Kind.AggresiveSick;
        }
    }
}
