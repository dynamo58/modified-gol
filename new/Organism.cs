using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace modified_gol
{
    abstract internal class Organism
    {
        public enum Kind { Dead, Healthy, Infected, PeacefulSick, AggresiveSick }
        
        public Kind kind;
        // possible amounts of neighbors for a cell to become a new organism
        public static int[] newCellBeBornConds = new int[] { 3 };


        public static Organism DecideEmptyCellNextState(int healthyNeighborCount)
        {
            if (Organism.newCellBeBornConds.Contains(healthyNeighborCount))
                return new HealthyOrganism();
            return null;
        }

        public abstract Organism DecideNextState(int healthyNeighborCount);
        public abstract Brush GetBrush();
    }

    [JsonDerivedType(typeof(HealthyOrganism), typeDiscriminator: "healthy")]
    internal class HealthyOrganism : Organism
    {
        // possible amounts of neighbors for a cell to survive
        public static int[] surviveConds = new int[] { 2, 3 };

        public override Brush GetBrush() => Brushes.Green;

        public override Organism DecideNextState(int healthyNeighborCount)
        {
            return (HealthyOrganism.surviveConds.Contains(healthyNeighborCount) ? this : null);
        }

        public HealthyOrganism()
        {
            this.kind = Kind.Healthy;
        }
    }

    [JsonDerivedType(typeof(InfectedOrganism), typeDiscriminator: "infected")]
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

    [JsonDerivedType(typeof(PeacefulSickOrganism), typeDiscriminator: "peacefulsick")]
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

    [JsonDerivedType(typeof(AggresiveSickOrganism), typeDiscriminator: "peacefulaggresive")]
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
