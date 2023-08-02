using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace modified_gol
{
    abstract internal class Organism
    {
        public enum Kind { Dead, Healthy, Infected, PeacefulSick, AggresiveSick }
        
        public Kind kind;
        // possible amounts of neighbors for a cell to become a new organism
        public static int[] newCellBeBornConds = new int[] { 3 };

        public abstract Brush GetBrush();
    }

    internal class HealthyOrganism : Organism
    {
        // possible amounts of neighbors for a cell to survive
        public static int[] surviveConds = new int[] { 2, 3 };

        public override Brush GetBrush() => Brushes.Green;

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

        public AggresiveSickOrganism()
        {
            this.kind = Kind.AggresiveSick;
        }
    }
}
