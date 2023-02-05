using System;
using System.Collections;
using System.Collections.Generic;
using Game.Tool.Ray;
using UnityEngine;

namespace Game.Base
{
    public class Character : MonoBehaviour
    {
        //Character attributes
        [HideInInspector] public Property myProperty;

        protected Animator myAnimator;

        protected Rigidbody2D myRigidbody;

        //Whether attacked
        public bool isAttacking = false;

        //Character sprite
        private SpriteRenderer spriteRenderer;

        //Color changing concordance
        private Coroutine colorCor;
        
        //Character direction
        public Vector2 direction;
        
        //Attack Speed Timer
        private float attackTime = 0f;
        
        //Availability of attacking units -1=false 0-n=Available
        public int attackUnit=-1;
        
        public bool IsMoving
        {
            get { return direction != Vector2.zero; }
        }

        protected RayCastInput rayCast;

        public bool isDie;

        protected float findAttackTime = 0;

        protected bool isDis;

        protected bool isAttackIng;

        public GameObject floatTxt;
        
        private void Awake()
        {
            myAnimator = GetComponent<Animator>();
            myRigidbody = GetComponent<Rigidbody2D>();
            myProperty = GetComponent<Property>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected virtual void Start()
        {
            
            RegisteredEvents();
        }

        protected virtual void Update()
        {
            if (isDie) return;
            Die();
            HandleLayers();
            rayCast.ShootRay();
            if (GameManager.Instance.myGameState != GameManager.GameState.Fight) direction = Vector2.zero;
        }

        protected virtual void FixedUpdate()
        {
            if (isDie) return;
            Move();
        }

        /// <summary>
        /// Move
        /// </summary>
        public void Move()
        {
            myRigidbody.velocity = direction.normalized * myProperty.moveSpeed;
        }

        /// <summary>
        /// Set the weight of the animation layer
        /// </summary>
        public void HandleLayers()
        {
            /*if(isHurt)
            {
                ActivateLayer("HurtLayer");
                StopAttack();
            }*/
            if (IsMoving)
            {
                ActivateLayer("WalkLayer");

                myAnimator.SetFloat("x", direction.x);
                myAnimator.SetFloat("y", direction.y);
            }
            else if (isAttacking)
            {
                myAnimator.SetBool("isAttack",isAttacking);
                ActivateLayer("AttackLayer");
            }
            else
            {
                ActivateLayer("IdleLayer");
            }
        }

        /// <summary>
        /// Set the animation layer
        /// </summary>
        /// <param name="layerName">Name of the layer</param>
        public void ActivateLayer(string layerName)
        {
            for (int i = 0; i < myAnimator.layerCount; i++)
            {
                myAnimator.SetLayerWeight(i, 0);
            }

            myAnimator.SetLayerWeight(myAnimator.GetLayerIndex(layerName), 1);
        }

        /// <summary>
        /// Injured execution
        /// </summary>
        public void Hurt()
        {
            spriteRenderer.color = Color.red;
            if (colorCor != null)
            {
                StopCoroutine(colorCor);
            }

            colorCor = StartCoroutine(ColorDisappear());
        }

        /// <summary>
        /// Injury animation
        /// </summary>
        /// <returns></returns>
        private IEnumerator ColorDisappear()
        {
            yield return new WaitForSeconds(0.4f);
            spriteRenderer.color = Color.white;
        }

        private void Die()
        {
            if (!isDie&&myProperty.HP <= 0)
            {
                CharacterManager.Instance.isAllUnitMove = true;
                isDie = true;
                CharacterManager.Instance.isNumDie = true;
            }
        }
        
        private IEnumerator DieIEnu()
        {
            for (int i = 0; i < 3; i++)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
                yield return new WaitForSeconds(0.2f);
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 255);
                yield return new WaitForSeconds(0.2f);
            }
        }

        private void RegisteredEvents()
        {
            rayCast.OnRayEnter += (Collider2D c) =>
            {
                attackTime = 0;
                isAttacking = false;
            };
            
            rayCast.OnRayStay += (Collider2D c) =>
            {
                attackUnit = c.GetComponent<Property>().index;
                if (attackUnit == -1) return;
                direction = Vector2.zero;
                attackTime += Time.deltaTime;
                if (attackTime >= myProperty.AttackSpeed)
                {
                    attackTime = 0;
                    isAttacking = true;
                }
            };
        }
    }
}
