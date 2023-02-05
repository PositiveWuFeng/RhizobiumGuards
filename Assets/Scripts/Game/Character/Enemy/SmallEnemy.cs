using System.Collections;
using System.Collections.Generic;
using Game.Tool.Ray;
using UnityEngine;

namespace Game.Base
{
    public class SmallEnemy : Character
    {
        private IEnumerator attackCor;

        
        protected override void Start()
        {
            rayCast = new RayCastInput(this.transform, this.myProperty.attackRange, 0.75f, "Friendly");
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
                    CreateEnemyManager.Instance.curNum--;
                    if (CreateEnemyManager.Instance.curNum == 0)
                    {
                        GameManager.Instance.EndFight(true);
                        CreateEnemyManager.Instance.curNum = CreateEnemyManager.Instance.smallEnemyNum[CreateEnemyManager.Instance.roundNum] + CreateEnemyManager.Instance.bossEnemyNum[CreateEnemyManager.Instance.roundNum];
                        CharacterManager.Instance.InitFrendly();
                    }
                }
                CharacterManager.Instance.isAllUnitMove = false;
                GameObject.Destroy(this.gameObject);
            }
        }
        
        protected override void FixedUpdate()
        {
            base.FixedUpdate();
        }
    
        private void Attack()
        {
            if (isAttacking && GameManager.Instance.myGameState==GameManager.GameState.Fight)
            {
                if (attackCor == null && !isAttackIng && CharacterManager.Instance.GetFriendly(attackUnit)!=null)
                {
                    isAttackIng = true;
                    attackCor=AttackEffect();
                    StartCoroutine(attackCor);
                }
            }
        }
        
        /// <summary>
        /// Some effects of the attack such as blood reduction on the attacking unit Floating s on the attacking unit
        /// </summary>
        /// <returns></returns>
        IEnumerator AttackEffect()
        {
            yield return new WaitForSeconds(0.75f);
            if (CharacterManager.Instance.GetFriendly(attackUnit))
            {
                var c = CharacterManager.Instance.GetFriendly(attackUnit).GetComponent<Character>();
                c.myProperty.HP-=this.myProperty.power;
                c.Hurt();
                var a = GameObject.Instantiate(floatTxt, c.transform.position, Quaternion.identity);
                a.GetComponent<FloatPoint>().DamageFloatPoint((int)this.myProperty.power);
            }
            isAttacking = false;
            isAttackIng = false;
            attackCor = null;
            myAnimator.SetBool("isAttack",isAttacking);
        }
    }
}