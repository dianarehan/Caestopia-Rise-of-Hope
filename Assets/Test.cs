using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Sprite rick;
    [SerializeField] private Sprite morty;
    [SerializeField] private Sprite batman;


    // Start is called before the first frame update
    void Start()
    {
        List<Dialogue> list = new List<Dialogue>()
        {
            new Dialogue("Rick", "What the Hell is this !!!", rick),
            new Dialogue("Morty", "Wubba Lubba Dub Dub", morty),
            new Dialogue("Batman", "What is this mess", batman)
        };

        DialogueManager.ShowDialogue(list);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
