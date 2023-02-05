using System.Collections;
using System.Collections.Generic;
using Game.Base;
using Game.Tool.Ray;
using UnityEngine;

namespace Game.Base
{
    public class Therapists : Character
    {
        private IEnumerator attackCor;

        public GameObject treatPrefab;
        
        protected override void Start()
        {
            rayCast = new RayCastInput(this.transform, this.myProperty.attackRange, this.myProperty.attackRange, "Friendly");
            base.Start();
        }
        
        private void Attack()
        {
            if (isAttacking&& GameManager.Instance.myGameState==GameManager.GameState.Fight)
            {
                if (attackCor == null&&!isAttackIng&& CharacterManager.Instance.GetFriendly(attackUnit)!=null)
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
            if (CharacterManager.Instance.GetFriendly(attackUnit))
            {
                CreateEffet();
                CharacterManager.Instance.GetFriendly(attackUnit).GetComponent<Property>().HP += myProperty.power;
            }
            isAttacking = false;
            isAttackIng = false;
            attackCor = null;
            myAnimator.SetBool("isAttack",isAttacking);
        }

        private void CreateEffet()
        {
            GameObject.Instantiate(treatPrefab,CharacterManager.Instance.GetFriendly(attackUnit).transform.position,Quaternion.identity);
        }
    }
}
