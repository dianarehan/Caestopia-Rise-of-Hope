using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private Transform endTransform;
    [SerializeField]
    private Transform startTransform;

    Animator chareAnimator;

    private bool isEntring = false;
    private bool isLeaving = false;

    float elapsedTrinsform = 0;

    private Transform tempSwap;

    private float characterSpeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startTransform.position;
        transform.localScale = startTransform.localScale;

        chareAnimator = GetComponent<Animator>();

        isEntring = true;
        chareAnimator.SetBool("front", true);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(startTransform.position, endTransform.position, elapsedTrinsform);
        transform.localScale = Vector3.Lerp(startTransform.localScale, endTransform.localScale, elapsedTrinsform);
        elapsedTrinsform += characterSpeed * Time.deltaTime;

       

        if (isEntring && elapsedTrinsform >= 1)
        {
            isEntring = false;
            GetComponent<Character>().StartFirstScenario();

            chareAnimator.SetBool("front", false);
            // TernOf the Animation;
        }

        if (isLeaving && elapsedTrinsform >= 1)
        {
            isLeaving = false;
            Kill();
            // TernOf the Animation;
        }
    }

    public void Leave()
    {
        tempSwap = new GameObject().transform;

        tempSwap.position = startTransform.position;
        tempSwap.localScale = startTransform.localScale;

        startTransform.position = endTransform.position;
        startTransform.localScale = endTransform.localScale;

        endTransform.position = tempSwap.position;
        endTransform.localScale = tempSwap.localScale;

        Destroy(tempSwap.gameObject);

        isLeaving = true;
        elapsedTrinsform = 0;

        chareAnimator.SetBool("front", true);
        characterSpeed = .2f;
        // Run Leaving Animation;
    }

    public void Kill()
    {
        Destroy(gameObject);
        CharacterSpawner.SpwanNewCharacter();
    }
}
