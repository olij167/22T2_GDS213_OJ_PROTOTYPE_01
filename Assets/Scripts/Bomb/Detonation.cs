using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonation : MonoBehaviour
{
    public ParticleSystem explosion;
    public Animator animator;

    float timer;

    public GameObject endGameUI, bombBase;

    public PlayerController player;
    public CamController camController;
    public BombTilt bombTilt;



    public bool mainCameraActive = true;
    //audio effects
    // camera shake

    void Start()
    {
        explosion.gameObject.SetActive(false);
        endGameUI.SetActive(false);

    }

    void Update()
    {
        if (!mainCameraActive)
        {
            timer += Time.deltaTime;

            if (timer >= 2f)
            {
                foreach (GameObject npc in GameObject.FindGameObjectsWithTag("NPC"))
                {
                    npc.GetComponent<Rigidbody>().AddExplosionForce(50f, explosion.transform.position, 1000f, 10f, ForceMode.Force);

                    npc.GetComponent<Rigidbody>().AddTorque(npc.transform.position, ForceMode.Force);
                }
            }

            if (timer >= 3f)
            {
                endGameUI.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
            }

            if (timer >= 8f)
            {
                explosion.Pause(true);
            }

        }
    }

    public void Detonate()
    {
        player.enabled = false;
        camController.enabled = false;
        bombTilt.tiltWarningAnimation.uiDisplay.enabled = false;
        bombTilt.enabled = false;

        if (!explosion.gameObject.activeSelf)
        {
            explosion.transform.parent = null;
            explosion.gameObject.SetActive(true);
            explosion.transform.position = bombBase.transform.position;
        }

       

        mainCameraActive = false;

        if (!mainCameraActive)
        {
            animator.Play("High Cam");
        }

        //endGameUI.SetActive(true);
    }

}
