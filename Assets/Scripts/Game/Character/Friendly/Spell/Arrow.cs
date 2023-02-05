using System;
using System.Collections;
using System.Collections.Generic;
using Game.Base;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float moveSpeed=3f;
    private Vector2 direction;
    public GameObject floatTxt;
    public void Direction(Transform target)
    {
        direction = target.position - this.transform.position;
    }

    private Rigidbody2D myRigidbody;
    public float power=5;
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (direction.x > 0)
        {
            this.transform.eulerAngles = new Vector3(0, 0, -90);
        }
        else
        {
            this.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        Move();
    }
    
    /// <summary>
    /// Move
    /// </summary>
    public void Move()
    {
        myRigidbody.velocity = direction.normalized * moveSpeed;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            var c = other.GetComponent<Character>();
            c.myProperty.HP-=power;
            c.Hurt();
            var a = GameObject.Instantiate(floatTxt, c.transform.position, Quaternion.identity);
            a.GetComponent<FloatPoint>().DamageFloatPoint((int)power);
            Destroy(this.gameObject);
        }
    }
}
