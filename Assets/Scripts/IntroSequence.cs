using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class IntroElement
{
    [SerializeField] public Sprite background;
    [SerializeField] public List<string> texts = new List<string>();
}

public class IntroSequence : MonoBehaviour
{
    public Image image;
    public Text text;
    //public TextMesh text;
    public IntroElement[] introElements;

    public float textDelay = 2f;
    public float transitionDelay = 1f;
    public float fadeDuration = .3f; // Duration of the fade effect

    private int imageIndex = 0;
    private int textIndex = 0;
    private Coroutine textCoroutine;
   // public float typingSpeed = 1f;
    void Start()
    {
        // Start the intro sequence
        StartCoroutine(ShowImageAndText());
    }

    void Update()
    {
        // Check for input to proceed to the next text or image
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextText();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator ShowImageAndText()
    {
        // Fade out the current image and text
        StartCoroutine(FadeOut(image, fadeDuration));
        yield return FadeOut(text, fadeDuration);

        // Display the current image
        image.sprite = introElements[imageIndex].background;

        // Fade in the new image
        yield return FadeIn(image, fadeDuration);

        // Start showing text for the current image
        textIndex = 0;
        textCoroutine = StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        int x = text.text.Length / 100;
        // Display each text for the current image
        while (textIndex < introElements[imageIndex].texts.Count)
        {
            // Fade out the current text
            yield return FadeOut(text, fadeDuration);

            // Display the new text
            text.text = introElements[imageIndex].texts[textIndex];

            // Fade in the new text
            yield return FadeIn(text, fadeDuration);

            // Wait for the text delay
            yield return new WaitForSeconds(textDelay );
            textIndex++;
        }

        // Wait for a delay before transitioning to the next image
        yield return new WaitForSeconds(transitionDelay);

        // Move to the next image if available
        imageIndex++;

        if (imageIndex < introElements.Length)
        {
            StartCoroutine(ShowImageAndText());
        }
        else
        {
            Debug.Log("End of intro sequence");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
   /* IEnumerator ShowText()
    {
        string currentText = introElements[imageIndex].texts[textIndex];
        text.text = ""; // Clear the text initially

        
        for (int i = 0; i <= currentText.Length; i++)
        {
            text.text = currentText.Substring(0, i); 
            yield return new WaitForSeconds(typingSpeed); 
        }

      
        yield return new WaitForSeconds(textDelay);

        
        textIndex++;

        
        if (textIndex < introElements[imageIndex].texts.Count)
        {
            StartCoroutine(ShowText());
        }
        else
        {
           
            yield return new WaitForSeconds(transitionDelay);

           
            imageIndex++;

            if (imageIndex < introElements.Length)
            {
                StartCoroutine(ShowImageAndText());
            }
            else
            {
                Debug.Log("End of intro sequence");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
        }
    }*/


    void NextText()
    {
        if (textCoroutine != null)
        {
            textIndex++;
            if (textIndex < introElements[imageIndex].texts.Count)
            {
                StopCoroutine(textCoroutine);
                textCoroutine = StartCoroutine(ShowText());
            }
        }
    }

    IEnumerator FadeIn(Graphic graphic, float duration)
    {
        graphic.gameObject.SetActive(true);
        float timer = 0f;
        Color startColor = graphic.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (timer < duration)
        {
            float progress = timer / duration;
            graphic.color = Color.Lerp(startColor, targetColor, progress);
            timer += Time.deltaTime;
            yield return null;
        }

        graphic.color = targetColor;
    }

    IEnumerator FadeOut(Graphic graphic, float duration)
    {
        float timer = 0f;
        Color startColor = graphic.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (timer < duration)
        {
            float progress = timer / duration;
            graphic.color = Color.Lerp(startColor, targetColor, progress);
            timer += Time.deltaTime;
            yield return null;
        }

        graphic.color = targetColor;
        graphic.gameObject.SetActive(false);
    }
}
