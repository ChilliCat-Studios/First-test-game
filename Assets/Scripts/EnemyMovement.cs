using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float movespeed = 2f;

    private Transform target;
    private int pathIndex = 0;
    private float baseSpeed;

    // Start is called before the first frame update
    void Start()
    {
        target = LevelManager.main.path[pathIndex];
        baseSpeed = movespeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(target.position, transform.position) <= 0.1)
        {
            pathIndex++;

            //enemy reaches end of path
            if(pathIndex == LevelManager.main.path.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                //TODO implement lost health state/game loss

                //force exit method
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 dir = (target.position - transform.position).normalized;

        rb.velocity = dir * movespeed;
    }

    public void UpdateSpeed(float newSpeed)
    {
        movespeed = newSpeed;
    }

    public void ResetMoveSpeed()
    {
        movespeed = baseSpeed;
    }
}
