using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    //public UIAnimator uiAnimator;
    //public NavigationController navController;
    //public BombCollisions bombCollisions;
    //BombHealth health;

    //public SpriteAnimation collisionAnimation;

    //public TextMeshProUGUI countdownText, objectiveText, winText, startText;

    //public Image collisionImage, healthFill;
    //public Slider healthBar;
    //public Gradient healthGradient;

    //public float countdownTimer, objectiveTimer, collisionTimer, gameTimer;
    //float countdownTimerReset, objectiveTimerReset, collisionTimerReset;

    //public bool countdownIsActive, objectiveIsActive, collisionIsActive;


    //void Start()
    //{
    //    uiAnimator.uiDisplay.enabled = false;
    //    uiAnimator.enabled = false;

    //    countdownTimerReset = countdownTimer;
    //    objectiveTimerReset = objectiveTimer;
    //    collisionTimerReset = collisionTimer;

    //    health = bombCollisions.bombHealth;
    //}

    //void Update()
    //{
    //    if (countdownIsActive)
    //    {
    //        countdownTimer -= Time.deltaTime;

    //        countdownText.enabled = true;
    //        countdownText.text = countdownTimer.ToString("0");
    //        objectiveText.text = "Pick up the bomb!";
    //        objectiveText.enabled = true;

    //        //UISizeLerp(countdownText, 10f);
    //        //UIHover(countdownText, Random.Range(10f, -10f));
    //        //UIBounce(objectiveText, Random.Range(0f, 10f));

    //        if (countdownTimer <= 0.5f)
    //        {
    //            countdownText.text = "...";
    //        }

    //        if (collisionTimer <= 0f)
    //        {
    //            DisableGameUI();
    //        }
    //    }
    //    else
    //    {
    //        ResetTimer(countdownTimer, countdownTimerReset, countdownText, countdownIsActive);
    //    }

    //    if (objectiveIsActive)
    //    {
    //        objectiveTimer -= Time.deltaTime;

    //        if (objectiveTimer <= 0f)
    //        {
    //            ResetTimer(objectiveTimer, objectiveTimerReset, objectiveText, objectiveIsActive);
    //        }
    //    }
       

    //    if (collisionIsActive)
    //    {
    //        collisionTimer -= Time.deltaTime;

    //        collisionImage.enabled = true;
    //        uiAnimator.uiAnimation = collisionAnimation;
    //        uiAnimator.count = 0;
    //        uiAnimator.uiDisplay = collisionImage;

    //        //UISizeLerp(collisionImage, Random.Range(10f, -10f));
    //        //UIBounce(collisionImage, Random.Range(10f, 0f));

    //        if (collisionTimer <= 0f)
    //        {
    //            ResetTimer(collisionTimer, collisionTimerReset, collisionImage, collisionIsActive);

    //        }
    //    }

    //    healthBar.value = health.health;
    //    healthFill.color = healthGradient.Evaluate(healthBar.normalizedValue);

    //    if (navController.inGame)
    //    {
    //        gameTimer += Time.deltaTime;
    //    }
    //}

    //// Reset timer and deactivate UI image
    //void ResetTimer (float timer, float timerReset, Image image, bool isActive)
    //{
    //    timer = timerReset;
    //    image.enabled = false;
    //    isActive = false;
    //}
    
    //// OR reset timer and deactivate UI text
    //void ResetTimer (float timer, float timerReset, TextMeshProUGUI text, bool isActive)
    //{
    //    timer = timerReset;
    //    text.enabled = false;
    //    isActive = false;
    //}

    //void DisableGameUI()
    //{
    //    countdownText.enabled = false;
    //    objectiveText.enabled = false;
    //    collisionImage.enabled = false;
    //    healthBar.enabled = false;
    //    uiAnimator.uiDisplay.enabled = false;
    //}

    // UI Animation Effects

    public void UIHover(TextMeshProUGUI text, float speed)
    {
        text.transform.position = Vector3.Lerp(text.transform.position, new Vector3(text.transform.position.x + Random.Range(-0.5f, 0.5f), text.transform.position.y + Random.Range(-0.5f, 0.5f), text.transform.position.z), Mathf.PingPong(Time.deltaTime, speed));
    }

    public void UIHover(Image image, float speed)
    {
        image.transform.position = Vector3.Lerp(image.transform.position, new Vector3(image.transform.position.x + Random.Range(-1f, 1f), image.transform.position.y + Random.Range(-1f, 1f), image.transform.position.z), Mathf.PingPong(Time.deltaTime, speed));
    }

    public void UIBounce(TextMeshProUGUI text, float speed)
    {
        text.transform.position = Vector3.Lerp(text.transform.position, new Vector3(text.transform.position.x, text.transform.position.y + 1f, text.transform.position.z), Mathf.PingPong(Time.deltaTime, speed));
    }
    public void UIBounce(Image image, float speed)
    {
        image.transform.position = Vector3.Lerp(image.transform.position, new Vector3(image.transform.position.x , image.transform.position.y + 1f, image.transform.position.z), Mathf.PingPong(Time.deltaTime, speed));

    }

    public void UISizeLerp(TextMeshProUGUI text, float speed)
    {
        text.fontSizeMin = text.fontSize / 2;
        text.fontSizeMax = text.fontSize * 2;
        text.fontSize = Mathf.Lerp(text.fontSizeMin, text.fontSizeMax, speed * Time.deltaTime);
    }

    public void UISizeLerp(Image image, float speed)
    {
        //float xMin = image.transform.localScale.x / 2;
        //float xMax = image.transform.localScale.x * 2;
        //float yMin = image.transform.localScale.x / 2;
        //float yMax = image.transform.localScale.x * 2;

        //image.transform.localScale = new Vector3(Mathf.Lerp(xMin, xMax, speed * Time.deltaTime), Mathf.Lerp(yMin, yMax, speed * Time.deltaTime), image.transform.localScale.z);



    }

    public void UIRotate(TextMeshProUGUI text, float speed)
    {
        text.transform.rotation = Quaternion.Lerp(text.transform.rotation, new Quaternion(text.transform.rotation.x, text.transform.rotation.y, text.transform.rotation.z + Random.Range(-30f, 30f), text.transform.rotation.w), Mathf.PingPong(Time.deltaTime, speed));
    }
    
    public void UIRotate(Image image, float speed)
    {
        image.transform.rotation = Quaternion.Lerp(image.transform.rotation, new Quaternion(image.transform.rotation.x, image.transform.rotation.y, image.transform.localScale.z + Random.Range(-30f, 30f), image.transform.rotation.w), Mathf.PingPong(Time.deltaTime, speed));
    }

    public void UIFadeIn(TextMeshProUGUI text, float speed)
    {
       text.color = Color.Lerp(new Color(text.color.r, text.color.g, text.color.b, 0f), new Color(text.color.r, text.color.g, text.color.b, 1f), speed * Time.deltaTime);
    }
    
    public void UIFadeIn(Image image, float speed)
    {
        image.color = Color.Lerp(new Color(image.color.r, image.color.g, image.color.b, 0f), new Color(image.color.r, image.color.g, image.color.b, 1f), speed * Time.time);

    }
    public void UIFadeOut(TextMeshProUGUI text, float speed)
    {
        text.color = Color.Lerp(new Color(text.color.r, text.color.g, text.color.b, 1f), new Color(text.color.r, text.color.g, text.color.b, 0f), speed * Time.deltaTime);

    }

    public void UIFadeOut(Image image, float speed)
    {
        image.color = Color.Lerp(new Color(image.color.r, image.color.g, image.color.b, 1f), new Color(image.color.r, image.color.g, image.color.b, 0f), speed * Time.deltaTime);
    }
}
