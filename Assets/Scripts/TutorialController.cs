using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialController : MonoBehaviour
{
    public List<TextMeshProUGUI> tutorialTextList;
    public GameObject buttons, navButtons;

    public int count;

    void Start()
    {
       
    }

    public void StartTutorial()
    {
        buttons.SetActive(false);
        navButtons.SetActive(true);
        foreach (TextMeshProUGUI text in tutorialTextList)
        {
            text.enabled = false;
        }

        tutorialTextList[0].enabled = true;
        tutorialTextList[1].enabled = true;

        count = 1;

        Time.timeScale = 0f;
    }

    public void NextTutorialSection()
    {
        if (count >= tutorialTextList.Count)
        {
            buttons.SetActive(true);
            navButtons.SetActive(false);
        }
        else
        {
            count++;

            tutorialTextList[count].enabled = true;

            if (count >= tutorialTextList.Count)
            {
                buttons.SetActive(true);
                navButtons.SetActive(false);
            }
        }
    }

    public void SkipToEnd()
    {
        foreach (TextMeshProUGUI text in tutorialTextList)
        {
            text.enabled = true;
            navButtons.SetActive(false);
            buttons.SetActive(true);
        }
    }
}
