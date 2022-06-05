using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BombCollisions : MonoBehaviour
{
    public float collisionDamage, dropTimer, timerReset, startHealth;
    public BombHealth bombHealth;
    Detonation detonation;

    public SpriteAnimation bombDroppedWarning, collisionWarning;

    public UIAnimator uIAnimator;

    public TextMeshProUGUI countdownText;

    public Transform carryPos;

    public bool bombDropped;

    private void Awake()
    {
        timerReset = dropTimer;
        bombHealth.health = startHealth;
        detonation = GetComponent<Detonation>();


        uIAnimator.uiDisplay.enabled = false;
        uIAnimator.enabled = false;

        countdownText.enabled = false;
        
    }

    private void Update()
    {
        if (bombDropped)
        {
            dropTimer -= Time.deltaTime;
            countdownText.enabled = true;
            countdownText.text = dropTimer.ToString("0");
        }

        if (dropTimer <= 0.5f)
        {
            countdownText.text = "...";
        }

        if (dropTimer <= 0f)
        {
            countdownText.enabled = false;

            // Explosion - Game Over
            uIAnimator.uiDisplay.enabled = false;
            detonation.Detonate();
            Debug.Log("Bomb Dropped! Game Over!");
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("NPC"))
        {
            bombHealth.health -= collisionDamage;

            

            uIAnimator.enabled = true;
            uIAnimator.uiAnimation = collisionWarning;
            uIAnimator.count = 0;

            uIAnimator.uiDisplay.enabled = true;

            
            Debug.Log("Collision");


            if (bombHealth.health <= 0)
            {
                // Explosion - Game Over
                detonation.Detonate();
                Debug.Log("Too many collisions! Game Over!");
            }
            //uIAnimator.enabled = false;

        }

        if (gameObject.CompareTag("Bomb") && collision.gameObject.CompareTag("Ground"))
        {
            bombDropped = true;
            GetComponent<BombTilt>().tiltWarningAnimation.uiDisplay.enabled = false;
            GetComponent<BombTilt>().enabled = false;

            //uIAnimator.enabled = true;

            //uIAnimator.count = -1;
            //uIAnimator.timePerFrame = 0f;
            //uIAnimator.uiAnimation = bombDroppedWarning;

            //uIAnimator.uiDisplay.enabled = true;
            
            

        }

        if (bombDropped)
        {
            if (gameObject.CompareTag("Bomb") && collision.gameObject.CompareTag("Player"))
            {
                detonation.transform.parent = carryPos.transform;

                detonation.transform.position = Vector3.Lerp(detonation.transform.position, carryPos.transform.position, 1f);
                detonation.transform.rotation = Quaternion.Lerp(detonation.transform.rotation, carryPos.transform.rotation, 1f);

                detonation.transform.GetComponent<Rigidbody>().useGravity = false;
                detonation.transform.GetComponent<Rigidbody>().isKinematic = true;

                GetComponent<BombTilt>().enabled = true;
                //uIAnimator.uiAnimation = GetComponent<BombTilt>().tiltAnimation;
                //uIAnimator.uiDisplay.enabled = false;
                //uIAnimator.enabled = false;
                countdownText.enabled = false;
                dropTimer = timerReset;

                bombDropped = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WinTrigger"))
        {
            // win
            Debug.Log("you win!");
        }
    }
}
