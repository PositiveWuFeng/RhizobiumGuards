using System;
using System.Collections;
using UnityEngine;

namespace Game.Tool.Ray
{
    public class RayCastInput
    {
        public RayCastInput(Transform tf, float x, float y, string layer)
        {
            this.tf = tf;
            this.x = x;
            this.y = y;
            this.layer = layer;
        }
        public event Action<Collider2D> OnRayEnter;
        public event Action<Collider2D> OnRayStay;
        public event Action<Collider2D> OnRayExit;
        Collider2D previousCollider;
        
        private Transform tf;
        private float x;
        private float y;
        private string layer;
        
        
        
        public void ShootRay()
        {
            Vector2 point = new Vector2(tf.position.x, tf.position.y + 0.157f);
            Collider2D collider = Physics2D.OverlapBox(point, new Vector2(x, y), 0,LayerMask.GetMask(layer)); 
            CollisionProcess(collider);
        }
    
        private void CollisionProcess(Collider2D current)
        {
            if (current == null)
            {
                if (previousCollider != null)
                {
                    OnRayExit?.Invoke(previousCollider);
                }
            }
            else if (previousCollider == current)
            {
                OnRayStay?.Invoke(current);
            }
            else if (previousCollider != null)
            {
                OnRayEnter?.Invoke(current);
                OnRayExit?.Invoke(previousCollider);
            }
            else
            {
                // no collider on last frame
                OnRayEnter?.Invoke(current);
            }
            previousCollider = current;
        }
    }
}

