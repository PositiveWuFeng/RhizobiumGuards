using System.Collections;
using System.Collections.Generic;
using Game.Base;
using Game.Tool.Ray;
using UnityEngine;

namespace Game.Base
{
    public class Sagittary : Character
    {
        private IEnumerator attackCor;

        public GameObject arrowPrefab;
        
        public Transform arrowPos;
        
        protected override void Start()
        {
            rayCast = new RayCastInput(this.transform, this.myProperty.attackRange, this.myProperty.attackRange, "Enemy");
            base.Start();
        }
        
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
            if (CharacterManager.Instance.GetEnemy(attackUnit))
            {
                CreateArrow();
            }
            isAttacking = false;
            isAttackIng = false;
            myAnimator.SetBool("isAttack",isAttacking);
            attackCor = null;
        }

        private void CreateArrow()
        {
            GameObject temp = GameObject.Instantiate(arrowPrefab,arrowPos.position,Quaternion.identity);
            var arr = temp.GetComponent<Arrow>();
            arr.Direction(CharacterManager.Instance.GetEnemy(attackUnit).transform);
            arr.power = myProperty.power;
        }
    }
}