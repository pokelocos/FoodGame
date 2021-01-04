using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new LvlData", menuName = "FoodGame/LvlData...")]
public class LevelData : ScriptableObject
{
    [System.Serializable]
    public struct platformData
    {
        public Vector3 position;
        public Vector3 rotation;
        public GameObject platform;
    }

    public List<GameObject> foodList = new List<GameObject>();
    public List<platformData> platformList = new List<platformData>();
    
}
