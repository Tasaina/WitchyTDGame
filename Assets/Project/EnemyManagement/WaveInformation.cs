using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Project.Scripts
{
    [System.Serializable]
    public class WaveInformation
    {
        public int fromWave;
        public int toWave;
        public List<Enemy> potentialEnemies = new List<Enemy>();
        public int totalSpawns;
        [NonSerialized]
        public int spawnsLeft;
        public float baseSpawnDelay = 1;
        public int pathId;
    }
}
