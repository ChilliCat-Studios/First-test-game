using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField]
    private float bulletSpeed = 5f;
    [SerializeField]
    private int bulletDmg = 1;

    private Transform target;

    private void FixedUpdate()
    {
        if(!target) return;

        Vector2 dir = (target.position - transform.position).normalized;

        //replace wiht transform translate method to have 100% accuracy
        rb.velocity = dir * bulletSpeed;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Health>().TakeDamage(bulletDmg);
        Destroy(gameObject);
    }
}
