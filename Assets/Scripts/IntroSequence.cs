using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

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

    public IntroElement[] introElements;

    public float textDelay = 2f;
    public float transitionDelay = 1f;
    public float fadeDuration = .3f; // Duration of the fade effect

    private int imageIndex = 0;
    private int textIndex = 0;
    private Coroutine textCoroutine;

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
    }

    IEnumerator ShowImageAndText()
    {
        // Fade out the current image and text
        yield return FadeOut(image, fadeDuration);
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
            yield return new WaitForSeconds(textDelay);
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
            // You may want to add logic here to handle the end of the intro sequence,
            // such as loading the next scene or starting the game.
        }
    }

    void NextText()
    {
        // Skip to the next text immediately
        if (textCoroutine != null)
        {
            StopCoroutine(textCoroutine);
            textIndex++;
            if (textIndex < introElements[imageIndex].texts.Count)
            {
                textCoroutine = StartCoroutine(ShowText());
            }
        }
    }

    IEnumerator FadeIn(Graphic graphic, float duration)
    {
        graphic.gameObject.SetActive(true); // Ensure the object is active before fading in
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
        graphic.gameObject.SetActive(false); // Ensure the object is inactive after fading out
    }
}
