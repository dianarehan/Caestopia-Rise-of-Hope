using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Characters;

    static float elapsedTime = 0f;
    static float duration = 3f;
    static bool isStart = false;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateCharacter();
    }

    // Update is called once per frame
    void Update()
    {

        elapsedTime += Time.deltaTime;

        if (isStart && elapsedTime >= duration)
        {
            InstantiateCharacter();
            isStart = false;
            elapsedTime = 0f;
        }
    }

    void InstantiateCharacter()
    {
        if (Characters.Count > 0)
        {
            Instantiate(Characters[0]);
            Characters.RemoveAt(0);
        }
        else
        {
            // Game Over
        }

    }


    public static void SpwanNewCharacter()
    {
        elapsedTime = 0;
        isStart = true;
    }
    
}
