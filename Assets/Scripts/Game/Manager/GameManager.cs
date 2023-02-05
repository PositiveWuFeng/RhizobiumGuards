using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Base;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance { get { return _instance; } }

        public GameObject envRoot;

        public GameObject victoryUIRoot;
        public GameObject defeatUIRoot;

        public GameObject viewRoot;


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

        public enum GameState
        {
            NotStarted,
            Prepare,
            Fight,
            Fail,
            Victory
        }
        //Current game status
        public GameState myGameState;
        
/*        //List of friendly forces
        [SerializeField]
        private List<Property> friends;
        
        //Enemy List
        [SerializeField]
        private List<Property> enemys;*/

        private void Start()
        {
            myGameState = GameState.NotStarted;
        }

        public void StartGame() {
            myGameState = GameState.Prepare;
            PlayerData.Init();
            envRoot.SetActive(true);
            StartMenuManager.Instance.Hide();
            GameMenuManager.Instance.Show();
            GameMenuManager.Instance.ShowFightButton();
            CreateEnemyManager.Instance.CreateEnemy();
        }

        public void StartFight()
        {
            myGameState = GameState.Fight;
           
            CharacterManager.Instance.StartCombat();
        }

        public void EndFight(bool isWin)
        {
            if(myGameState == GameState.Fight)
            {
                if (isWin)
                {
                    if(PlayerData.rounds == 12)
                    {
                        myGameState = GameState.Victory;
                        victoryUIRoot.SetActive(true);
                        viewRoot.SetActive(false);
                        return;
                    }
                    myGameState = GameState.Prepare;
                    PlayerData.gold += CreateEnemyManager.Instance.golds[PlayerData.rounds-1];
                    //Invoke("EnterPrepare", 1);
                    StartCoroutine(EnterPrepare());
                }
                else
                {
                    myGameState = GameState.Fail;
                    defeatUIRoot.SetActive(true);
                    viewRoot.SetActive(false);

                }
            }
        }
        private IEnumerator EnterPrepare()
        {
            yield return new WaitForSeconds(0.5f);
          
            myGameState = GameState.Prepare;
            GameMenuManager.Instance.ShowFightButton();
            CreateEnemyManager.Instance.CreateEnemy();

            PlayerData.rounds++;
        }
        private void Update()
        {
            //StateManager();
        }

        /// <summary>
        /// Execution methods based on status
        /// </summary>
        private void StateManager()
        {
            if (myGameState == GameState.NotStarted)
            {
                
            }
            else if (myGameState == GameState.Prepare)
            {
   
            }
            else if (myGameState == GameState.Fight)
            {
                
            }
            else if (myGameState == GameState.Fail)
            {
                
            }
            else
            {
                
            }
        }
        /// <summary>
        /// Get all friendly units
        /// </summary>
/*        private void GetAllFriends()
        {
            int num = 0;
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Friendly");
            while (num < temp.Length)
            {
                temp[num].GetComponent<Property>().index = num;
                friends.Add(temp[num++].GetComponent<Property>());
            }
        }

        private void GetAllEnemys()
        {
            int num = 0;
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Enemy");
            while (num < temp.Length)
            {
                temp[num].GetComponent<Property>().index = num;
                enemys.Add(temp[num++].GetComponent<Property>());
            }
        }*/
        
        /// <summary>
        /// Find the unit to attack
        /// Time Complexity O(n2) ,Too lazy to optimize
        /// </summary>
        /// <param name="tag">Your own label</param>
        /// <param name="index">Your own index</param>
    /*    private GameObject FindAttackUnit(string tag,int index)
        {
            if (tag == "Enemy")
            {
                float minDis = 999;
                int minIndex = -1;
                for (int i = 0; i < friends.Count; i++)
                {
                    float dis = Vector2.Distance(enemys[index].gameObject.transform.position, friends[i].gameObject.transform.position);
                    if (dis < minDis)
                    {
                        minDis = dis;
                        minIndex = i;
                    }
                }
                return minIndex == -1 ? null : friends[minIndex].gameObject;
            }
            else
            {
                float minDis = 999;
                int minIndex = -1;
                for (int i = 0; i < enemys.Count; i++)
                {
                    float dis = Vector2.Distance(enemys[i].gameObject.transform.position, friends[index].gameObject.transform.position);
                    if (dis < minDis)
                    {
                        minDis = dis;
                        minIndex = i;
                    }
                }
                return minIndex == -1 ? null : enemys[minIndex].gameObject;
            }
        }
        
        /// <summary>
        /// All units move towards the closest unit
        /// </summary>
        private IEnumerator AllUnitMove()
        {
            while (true)
            {
                for (int i = 0; i < friends.Count; i++)
                {
                    Character temp=friends[i].GetComponent<Character>();
                    if (temp.attackUnit != -1) continue;
                    if(!temp.isAttacking) temp.direction = FindAttackUnit("Friendly", i).transform.position - friends[i].transform.position;
                }

                for (int i = 0; i < enemys.Count; i++)
                {
                    Character temp=enemys[i].GetComponent<Character>();
                    if (temp.attackUnit != -1) continue; 
                    if(!temp.isAttacking) temp.GetComponent<Character>().direction = FindAttackUnit("Enemy", i).transform.position - enemys[i].transform.position;
                }

                yield return new WaitForSeconds(1.0f);
            }
        }
        
        /// <summary>
        /// Find friendly units by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public GameObject GetFriendly(int index)
        {
            return friends[index].gameObject;
        }
        
        /// <summary>
        /// Find enemy units by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public GameObject GetEnemy(int index)
        {
            return enemys[index].gameObject;
        }*/
    }
}

