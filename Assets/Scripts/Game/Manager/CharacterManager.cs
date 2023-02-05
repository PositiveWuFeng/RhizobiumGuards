using System;
using System.Collections;
using System.Collections.Generic;
using Game.Base;
using UnityEngine;

namespace Game
{
    public class CharacterManager : MonoBehaviour
    {
        private static CharacterManager _instance;
        public static CharacterManager Instance { get { return _instance; } }

        public Coroutine ienu;

        public GameObject[] chaPre;

        public bool isAllUnitMove = false;

        public bool isNumDie;
        public bool isTrueInit;
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

        private void Update()
        {
            if (isNumDie && !isTrueInit)
            {
                isNumDie = false;
                isTrueInit = true;
                StartCoroutine(InitCombat());
            }
        }

        private IEnumerator InitCombat()
        {
            yield return new WaitForSeconds(0.1f);
            StartCombat();
            isTrueInit = false;
        }
        
        public void StartCombat()
        {
            friends.Clear();
            enemys.Clear();
            GetAllFriends();
            GetAllEnemys();
            ienu = StartCoroutine(AllUnitMove());
        }

        //List of friendly forces
        [SerializeField]
        public List<Property> friends;
        
        //Enemy List
        [SerializeField]
        public List<Property> enemys;
        
        /// <summary>
        /// Get all friendly units
        /// </summary>
        private void GetAllFriends()
        {
            int num = 0;
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Friendly");
            while (num < temp.Length)
            {
                temp[num].GetComponent<Character>().attackUnit = -1;
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
                temp[num].GetComponent<Character>().attackUnit = -1;
                temp[num].GetComponent<Property>().index = num;
                enemys.Add(temp[num++].GetComponent<Property>());
            }
        }
        
        /// <summary>
        /// Find the unit to attack
        /// Time Complexity O(n2) ,Too lazy to optimize
        /// </summary>
        /// <param name="tag">Your own label</param>
        /// <param name="index">Your own index</param>
        public GameObject FindAttackUnit(string tag,int index)
        {
            float minDis = 999;
            int minIndex = -1;
            if (tag == "Enemy")
            {
                for (int i = 0; i < friends.Count; i++)
                {
                    if (index < 0 || index >= enemys.Count) continue;
                    if(enemys[index]==null || friends[i]==null) continue;
                    
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
                for (int i = 0; i < enemys.Count; i++)
                {
                    if (index < 0 || index >= friends.Count || !enemys[i]) continue;
                    if(enemys[i]==null || friends[index]==null) continue;
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
                if (GameManager.Instance.myGameState == GameManager.GameState.Fight && !isAllUnitMove)
                {
                    for (int i = 0; i < friends.Count; i++)
                    {
                        if (friends[i] == null) continue;
                        Character temp = friends[i].GetComponent<Character>();
                        if (temp.attackUnit != -1 || temp.isDie) continue;
                        if (!temp.isAttacking&& friends[i]!=null)
                            temp.direction = FindAttackUnit("Friendly", i).transform.position -
                                             friends[i].transform.position;
                    }

                    for (int i = 0; i < enemys.Count; i++)
                    {
                        if (enemys[i] == null) continue;
                        Character temp=enemys[i].GetComponent<Character>();
                        if (temp.attackUnit != -1|| temp.isDie) continue; 
                        if(!temp.isAttacking &&  enemys[i]!=null) temp.direction = FindAttackUnit("Enemy", i).transform.position - enemys[i].transform.position;
                    }
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
            if (index <0 || index>=friends.Count||friends[index]==null) return null;
            return friends[index].gameObject;
        }
        
        /// <summary>
        /// Find enemy units by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public GameObject GetEnemy(int index)
        {
            if (index <0 || index>=enemys.Count || enemys[index]==null) return null;
            return enemys[index].gameObject;
        }

        public void InitFrendly()
        {
            for (int i = 0; i < friends.Count; i++)
            {
                switch (friends[i].id)
                {
                    case 1 :
                        friends[i].HP = 20;
                        break;
                    case 2 :
                        friends[i].HP = 12;
                        break;
                    case 3:
                        friends[i].HP = 10;
                        break;
                    case 4:
                        friends[i].HP = 10;
                        break;
                }
                
            }
        }
    }

}
