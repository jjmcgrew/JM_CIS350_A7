/*
 * Josh McGrew
 * Assignment 7 Prototype 4
 * enemy ai
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody enemyRb;
    public GameObject player;
    public float speed = 3.0f;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        //add force towards the direction from the player to the enemy

        //vector for direction from enemy to player, normalize to just get direction and not distance
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        //add force towards player
        enemyRb.AddForce(lookDirection * speed);

        //destroy enemy when it falls off
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
