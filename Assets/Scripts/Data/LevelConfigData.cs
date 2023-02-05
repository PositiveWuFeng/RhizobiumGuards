using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelConfigData 
{


    [SerializeField]
    public class LevelData
    {
        public LevelData(int level,int MaxPeople,int cost)
        {
            this.level = level;
            this.MaxPeople = MaxPeople;
            this.cost = cost;
        }
        public int level;
        public int MaxPeople;
        public int cost;
    }

    public static LevelData[] data = new LevelData[] {
        new LevelData(1,2,5),
        new LevelData(2,3,5),
        new LevelData(3,5,5),
        new LevelData(4,7,5),
        new LevelData(5,10,5),

    };
}
