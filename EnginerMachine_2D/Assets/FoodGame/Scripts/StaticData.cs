using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.FoodGame.Scripts
{
    public static class StaticData
    {
        public static int index = -1;
        public static string levelData = "";

        public static List<string> levels = new List<string>();
        private static List<bool> lvlCompleted = new List<bool>();

        public static void SetNext()
        {
            var n = (index + 1) % levels.Count;
            index = n;
            levelData = levels[n];
            
        }

        internal static string GetNext()
        {
            return levels[(index + 1) % levels.Count];
        }

        public static int Getindex()
        {
            return index;
        }

        public static string GetLevelData()
        {
            return levels[index];
        }

        
    }
}
