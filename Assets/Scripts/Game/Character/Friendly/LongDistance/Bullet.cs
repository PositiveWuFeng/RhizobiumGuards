using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40; 

    [SerializeField] private Rigidbody2D rb;

    private void FixedUpdate() {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent <Enemy> ();
        
        if (enemy != null){
            enemy.TakeDamage (damage);
        }

        gameObject.SetActive(false);
    }
}
