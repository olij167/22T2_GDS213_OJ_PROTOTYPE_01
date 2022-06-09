using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BombCollisions : MonoBehaviour
{
    public float collisionDamage, dropTimer, timerReset, startHealth, collisionWarningTimer, collisionTimerReset;
    public BombHealth bombHealth;
    Detonation detonation;

    public SpriteAnimation bombDroppedWarning, collisionWarning;

    public UIAnimator uIAnimator;

    public TextMeshProUGUI countdownText, objectiveText;

    public Transform carryPos;

    public bool bombDropped, collisionWarningActive, gameWon;

    public NavigationController navigationController;

    public Slider bombHealthBar;
    public Image healthBarFill;

    GameObject healthBar;

    public Gradient healthBarGradient;

    private void Awake()
    {
        timerReset = dropTimer;
        collisionTimerReset = collisionWarningTimer;
        bombHealth.health = startHealth;
        detonation = GetComponent<Detonation>();


        uIAnimator.uiDisplay.enabled = false;
        uIAnimator.enabled = false;

        countdownText.enabled = false;

        //gameWon = false;

        bombHealthBar.maxValue = startHealth;
        healthBarFill.color = healthBarGradient.Evaluate(1f);

        healthBar = bombHealthBar.gameObject;

    }

    private void Update()
    {
        if (bombDropped)
        {
            dropTimer -= Time.deltaTime;
            countdownText.enabled = true;
            countdownText.text = dropTimer.ToString("0");
            objectiveText.text = "Pick up the bomb!";
            objectiveText.enabled = true;
        }
        else objectiveText.text = "";

        if (dropTimer <= 0.5f)
        {
            countdownText.text = "...";
        }

        if (dropTimer <= 0f)
        {
            countdownText.enabled = false;

            navigationController.inGame = false;

            // Explosion - Game Over
            uIAnimator.uiDisplay.enabled = false;
            detonation.Detonate();
            objectiveText.enabled = false;
            //healthBar.SetActive(false);

            Debug.Log("Bomb Dropped! Game Over!");
        }

        if (collisionWarningActive)
        {
            collisionWarningTimer -= Time.deltaTime;

            if (collisionWarningTimer <= 0)
            {
                uIAnimator.uiDisplay.enabled = false;
                collisionWarningTimer = collisionTimerReset;
                collisionWarningActive = false;
            }
        }

        //navigationController.winText.fontSize = Mathf.PingPong(navigationController.winText.fontSize, 1) * Time.deltaTime;

        bombHealthBar.value = bombHealth.health;
        healthBarFill.color = healthBarGradient.Evaluate(bombHealthBar.normalizedValue);
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("NPC") || collision.gameObject.CompareTag("Wall"))
        {
            bombHealth.health -= collisionDamage;

            uIAnimator.enabled = true;
            uIAnimator.uiAnimation = collisionWarning;
            uIAnimator.count = 0;

            collisionWarningActive = true;
            uIAnimator.uiDisplay.enabled = true;

            
            Debug.Log("Collision");


            if (bombHealth.health <= 0)
            {
                navigationController.inGame = false;
                // Explosion - Game Over
                detonation.Detonate();
                objectiveText.enabled = false;
                //healthBar.SetActive(false);
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
            navigationController.WinGame();
            //gameWon = true;
        }
    }
}
