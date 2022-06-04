using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimator : MonoBehaviour
{
    public List<Sprite> animationFrames;
    public float timePerFrameReset;
    public float timePerFrame;
    //public string animationID;

    public Image uiDisplay;

    public int count;
    void Start()
    {
        timePerFrame = timePerFrameReset;
    }

    private void Update()
    {
        Animate();
    }

    public void Animate()
    {
        timePerFrame -= Time.deltaTime;

        if (timePerFrame <= 0)
        {
            count++;

            if (count >= animationFrames.Count)
            {
                count = 0;
            }

            uiDisplay.sprite = animationFrames[count];
            timePerFrame = timePerFrameReset;

        }
    }
}
