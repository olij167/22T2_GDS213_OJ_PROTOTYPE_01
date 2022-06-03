using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollisions : MonoBehaviour
{
    public float collisionDamage;
    public BombHealth bombHealth;

    private void Start()
    {
        bombHealth.health = 100f;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("NPC"))
        {
            bombHealth.health -= collisionDamage;
            if (bombHealth.health <= 0)
            {
                // Explosion - Game Over
                Debug.Log("Too many collisions! Game Over!");
            }
        }

        if (gameObject.CompareTag("Bomb") && collision.gameObject.CompareTag("Ground"))
        {
            // Explosion - Game Over
            Debug.Log("Bomb Dropped! Game Over!");
        }
    }
}
