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

        public static Organism DecideEmptyCellNextState(int healthyNeighborCount)
        {
            if (healthyNeighborCount > 0 && Simulation.newCellBeBornConds[healthyNeighborCount-1])
                return new HealthyOrganism();
            return null;
        }

        public abstract Organism DecideNextState(int healthyNeighborCount);
        public abstract Brush GetBrush();
    }

    internal class HealthyOrganism : Organism
    {
        public override Brush GetBrush() => Brushes.Green;

        public override Organism DecideNextState(int healthyNeighborCount)
        {
            if (healthyNeighborCount > 0 && Simulation.surviveConds[healthyNeighborCount - 1])
                return this;
            return null;
        }

        public HealthyOrganism()
        {
            this.kind = Kind.Healthy;
        }
    }

    internal class InfectedOrganism : Organism
    {
        // number of generations before a sickness becomes apparent
        public static int incubationPeriod = 3;
        public static int chanceOfInfectectionCausingAggretion = 30;
        public int currentDaysIncubating = 0;

        public override Brush GetBrush() => Brushes.Yellow;

        public override Organism DecideNextState(int healthyNeighborCount)
        {
            this.currentDaysIncubating += 1;

            if (this.currentDaysIncubating == InfectedOrganism.incubationPeriod)
            {
                bool newIsAggresive = Program._rand.Next(1, 101) < InfectedOrganism.chanceOfInfectectionCausingAggretion;

                return (newIsAggresive) ? (new AggresiveSickOrganism() as Organism) : (new PeacefulSickOrganism() as Organism);
            }
                
            return this;
        }

        public InfectedOrganism()
        {
            this.kind = Kind.Infected;
        }
    }

    internal class PeacefulSickOrganism : Organism
    {
        // number of generations a cell remains sick before it either dies or heals
        public static int generationsUntilRecoveryOrDeath = 3;
        public int currentNumberOfGenerationsSick = 0;
        // chance in percantages that the cell survives the sickness 
        public static int chanceOfRecovery = 30;

        public override Brush GetBrush() => Brushes.Orange;

        public override Organism DecideNextState(int healthyNeighborCount)
        {
            this.currentNumberOfGenerationsSick += 1;

            if (this.currentNumberOfGenerationsSick == PeacefulSickOrganism.generationsUntilRecoveryOrDeath)
            {
                // play god
                bool keepAlive = Program._rand.Next(1, 101) < PeacefulSickOrganism.chanceOfRecovery;

                // the org. has healed!
                return (keepAlive) ? new HealthyOrganism() : null;
            }

            return this;
        }

        public PeacefulSickOrganism()
        {
            this.kind = Kind.PeacefulSick;
        }
    }

    internal class AggresiveSickOrganism : Organism
    {
        // how many days without "eating" for an aggressive cell to die
        public static int hungerStrikeThreshold = 5;
        public int currentHungerStrike = 0;

        public override Brush GetBrush() => Brushes.Red;

        public override Organism DecideNextState(int healthyNeighborCount)
        {
            this.currentHungerStrike += 1;
            // if the org. hasn't eaten in a while, it shall die
            return (this.currentHungerStrike == AggresiveSickOrganism.hungerStrikeThreshold) ? null : this;
        }

        public AggresiveSickOrganism()
        {
            this.kind = Kind.AggresiveSick;
        }
    }
}
