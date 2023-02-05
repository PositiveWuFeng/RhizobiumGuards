using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreateEnemyManager : MonoBehaviour
{
    private static CreateEnemyManager _instance;
    public static CreateEnemyManager Instance { get { return _instance; } }

    public int curNum;
    public int[] smallEnemyNum;
    public int[] bossEnemyNum;
    public float[] golds;
    public int roundNum;

    public GameObject[] enemyPrefabs;
    
    public GameObject[] grid;
    public int[] vis;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject); return;
        }
        else
        {
            _instance = this;
        }
    }

    public void CreateEnemy()
    {
        CreateEnemyManager.Instance.curNum = CreateEnemyManager.Instance.smallEnemyNum[CreateEnemyManager.Instance.roundNum] + CreateEnemyManager.Instance.bossEnemyNum[CreateEnemyManager.Instance.roundNum];
        vis = new int[15];
        for(int i=0;i<smallEnemyNum[roundNum];i++)
        {
            int temp = Random.Range(0, 14);
            while (vis[temp] == 1)
            {
                temp = Random.Range(0, 14);
            }
            GameObject.Instantiate(enemyPrefabs[0], grid[temp].transform.position, Quaternion.identity);
            vis[temp] = 1;
        }
        for (int i = 0; i < bossEnemyNum[roundNum]; i++)
        {
            int temp = Random.Range(0, 14);
            while (vis[temp] == 1)
            {
                temp = Random.Range(0, 14);
            }
            GameObject.Instantiate(enemyPrefabs[1], grid[temp].transform.position, Quaternion.identity);
            vis[temp] = 1;
        }
        
        roundNum++;
    }
}
