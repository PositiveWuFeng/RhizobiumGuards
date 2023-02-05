using System.Collections;
using System.Collections.Generic;
using Game.Tool.Ray;
using UnityEngine;

namespace Game.Base
{
    public class Venerable : Character
    {
        private IEnumerator attackCor;

        public GameObject spellPrefab;
        
        private void Attack()
        {
            if (isAttacking && GameManager.Instance.myGameState==GameManager.GameState.Fight)
            {
                if (attackCor == null && !isAttackIng && CharacterManager.Instance.GetEnemy(attackUnit)!=null)
                {
                    isAttackIng = true;
                    attackCor = AttackEffect();
                    StartCoroutine(attackCor);
                }
            }
        }

        protected override void Start()
        {
            rayCast = new RayCastInput(this.transform, this.myProperty.attackRange, this.myProperty.attackRange, "Enemy");
            base.Start();
        }
        
        protected override void Update()
        {
            base.Update();
            Attack();
            if (isDie)
            {
                if (!isDis)
                {
                    isDis = true;
                    PlayerData.peopleNum--;
                }
                CharacterManager.Instance.isAllUnitMove = false;
                GameObject.Destroy(this.gameObject);
            }
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        /// <summary>
        /// Some effects of the attack such as blood reduction on the attacking unit Floating s on the attacking unit
        /// </summary>
        /// <returns></returns>
        IEnumerator AttackEffect()
        {
            yield return new WaitForSeconds(0.5f);
            List<GameObject> temp=new List<GameObject>();
            if (CharacterManager.Instance.GetEnemy(attackUnit))
            {
                temp = DetectsAllEnemy(CharacterManager.Instance.GetEnemy(attackUnit).transform);
                int tempNum = 0;
                foreach (var i in temp)
                {
                    if (tempNum > 3) break;
                    var c = i.GetComponent<Character>();
                    c.myProperty.HP-=this.myProperty.power;
                    CreateEffet(c.myProperty.index);
                    c.Hurt();
                    var a = GameObject.Instantiate(floatTxt, c.transform.position, Quaternion.identity);
                    a.GetComponent<FloatPoint>().DamageFloatPoint((int)this.myProperty.power);
                }
            }
            isAttacking = false;
            isAttackIng = false;
            myAnimator.SetBool("isAttack", isAttacking);
            attackCor = null;
        }
        
        /// <summary>
        /// Detects all enemies within range of the spell
        /// </summary>
        private List<GameObject> DetectsAllEnemy(Transform tf)
        {
            List<GameObject> temp=new List<GameObject>();
            var colliders = Physics2D.OverlapCircleAll(tf.position, this.myProperty.spellRange,LayerMask.GetMask("Enemy"));
            foreach (var i in colliders)
            {
                temp.Add(i.gameObject);
            }
            return temp;
        }
        
        private void CreateEffet(int index)
        {
            if (index <0 || index>=CharacterManager.Instance.enemys.Count) return;
            GameObject.Instantiate(spellPrefab,CharacterManager.Instance.GetEnemy(index).transform.position,Quaternion.identity);
        }
    }
}


