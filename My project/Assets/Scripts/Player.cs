using System.Collections.Generic;

namespace DefaultNamespace
{
    public record Player()
    {
        public string Name { get; set; }
        public int StackCount { get; set; } = 6;
        public List<Card> Stack { get; set; }
        public bool EnergyState { get; set; } = true;
        public bool ShieldState { get; set; } = true;
        public int SpeedLimiter { get; set; }
    }
}