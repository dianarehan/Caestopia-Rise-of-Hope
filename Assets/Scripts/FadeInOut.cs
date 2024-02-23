using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float fadeDurarion;
    private float elapsedTime = 0;
    private Color c1, c2;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        elapsedTime = 0;
        c1 = spriteRenderer.color; 
        c2 = spriteRenderer.color;
        c2.a = .1f;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = Color.Lerp(c1, c2, elapsedTime/fadeDurarion);

        if (elapsedTime < fadeDurarion) 
        {
            elapsedTime += Time.deltaTime;
        }
        else if (elapsedTime > fadeDurarion) 
        {
            elapsedTime = 0;
        }
    }
}
