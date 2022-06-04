using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonation : MonoBehaviour
{
    public ParticleSystem explosion;
    public Animator animator;

    float timer;

    public GameObject endGameUI;

    public PlayerController player;
    public CamController camController;
    public BombTilt bombTilt;



    public bool mainCameraActive = true;
    //audio effects
    // swap cameras - ground level shockwave & cloud formation, high angle of cloud growth
    // camera shake
    //lose UI

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
        bombTilt.enabled = false;

        if (!explosion.gameObject.activeSelf)
        {
            explosion.transform.parent = null;
            explosion.gameObject.SetActive(true);
        }

        mainCameraActive = false;

        if (!mainCameraActive)
        {
            animator.Play("High Cam");
        }

        //endGameUI.SetActive(true);
    }

}
