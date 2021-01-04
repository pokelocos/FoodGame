using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataSystem
{
    [System.Serializable]
    public class Data
    {
        public List<string> levelsOpen;

        public Data()
        {
            levelsOpen = new List<string>();
        }
    }
}