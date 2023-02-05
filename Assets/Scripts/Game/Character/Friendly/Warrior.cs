using System;
using System.Collections;
using System.Collections.Generic;
using Game.Tool.Ray;
using UnityEngine;

namespace Game.Base
{
    public class Warrior : Character
    {
        private IEnumerator attackCor;
        
        protected override void Start()
        {
            rayCast = new RayCastInput(this.transform, this.myProperty.attackRange, 3f, "Enemy");
            base.Start();
        }
        
        private void Attack()
        {
            if (isAttacking&& GameManager.Instance.myGameState==GameManager.GameState.Fight)
            {
                if (attackCor == null &&!isAttackIng && CharacterManager.Instance.GetEnemy(attackUnit)!=null)
                {
                    isAttackIng = true;
                    attackCor=AttackEffect();
                    StartCoroutine(attackCor);
                }
            }
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
                    CharacterManager.Instance.isNumDie = true;
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
            yield return new WaitForSeconds(0.75f);
            if (CharacterManager.Instance.GetEnemy(attackUnit))
            {
                var c = CharacterManager.Instance.GetEnemy(attackUnit).GetComponent<Character>();
                c.myProperty.HP -= this.myProperty.power;
                c.Hurt();
                var a = GameObject.Instantiate(floatTxt, c.transform.position, Quaternion.identity);
                a.GetComponent<FloatPoint>().DamageFloatPoint((int)this.myProperty.power);
            }

            isAttacking = false;
            isAttackIng = false;
            myAnimator.SetBool("isAttack",isAttacking);
            attackCor = null;
        }
        
        private void IfFindUnit()
        {
            findAttackTime += Time.deltaTime;
            if (findAttackTime >= 0.1f)
            {
                findAttackTime = 0;
                CharacterManager.Instance.FindAttackUnit("Friendly", myProperty.index);
            }
        }
    }
}