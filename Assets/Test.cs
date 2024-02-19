using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;
using System;

public class Test : MonoBehaviour
{
    [SerializeField] private Sprite rick;
    [SerializeField] private Sprite morty;
    [SerializeField] private Sprite batman;


    private void KillBOB()
    {
        Scenario scenario = new Scenario();

        scenario.Push(new Dialogue("BOB", "AAAAAHHHH NOO", rick));
        scenario.Push(new Dialogue("BOB", "7raaaam", rick));
        scenario.Push(new Question("Are you sure", new List<Choice>() {
            new Choice("Yes", () => { Debug.Log("Yes");}),
            new Choice("No", () => { Debug.Log("No");})
            }));
        scenario.StartScenario();
    }

    // Start is called before the first frame update
    void Start()
    {
        Scenario scenario1 = new Scenario();
        scenario1.Push(new Dialogue("BOB", "IAAMMM FOCKIN BOB", rick));
        scenario1.Push(new Dialogue("LOL", "IAAMMM FOCKIN LOL", morty));
        scenario1.Push(new Dialogue("SOS", "IAAMMM FOCKIN SOS", batman));
        scenario1.Push(new Question("Kill someone", 
        new List<Choice>() 
        {
            new Choice("KILL BOB", () => { KillBOB(); }),
            new Choice("KILL LOL", () => {  }),
            new Choice("KILL SOS", () => {  }),
        }
            ));
        scenario1.StartScenario();


        /* List<Dialogue> list = new List<Dialogue>()
         {
             new Dialogue("Rick", "What the Hell is this !!!", rick),
             new Dialogue("Morty", "Wubba Lubba Dub Dub", morty),
             new Dialogue("Batman", "What is this mess", batman)
         };

         DialogueManager.ShowDialogue(list);

        List<Dialogue> list = new List<Dialogue>()
        {
           new Dialogue("Royal counsler", "my lord, I’ll Help you rule the City" +
            " but you have to make some tough choices, do you understand?", rick),
        };
        List<Choice> choices = new List<Choice>
        {
            new Choice("YES", Yes1),
            new Choice("NO", No1)
        };
        DialogueManager.Instance.ShowDialogue(list,"YES Or NO ?", choices);
        */
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }

    void Yes1()
    {
        List<Dialogue> list = new List<Dialogue>()
        {
           new Dialogue("King", "Our city is now small and have some issues but it has the potential to grow.", rick),
           new Dialogue("King", "for now you have to keep the citizens happy and grow our city .", rick),
           new Dialogue("King", "-good luck sir!! .", rick)
        };
        DialogueManager.Instance.ShowDialogue(list, ShowAfter1);
    }
    void No1()
    {
        List<Dialogue> list = new List<Dialogue>()
        {
           new Dialogue("King", "haha funny just give the people some answers.", rick),
        };
        DialogueManager.Instance.ShowDialogue(list, ShowAfter1);

    }

    void ShowAfter1()
    {
        List<Dialogue> list = new List<Dialogue>()
        {
           new Dialogue("Fisherman", " my boat is too tiny, i cant catch many fish" +
           " to be sufficient for the people in the city, may i have some gold to upgrade it?", rick),
        };
        List<Choice> choices = new List<Choice>();
        choices.Add(new Choice("YES", Yes2));
        choices.Add(new Choice("NO", No2));
        DialogueManager.Instance.ShowDialogue(list, "YES Or NO ?", choices);
    }

    void Yes2()
    {
        List<Dialogue> list = new List<Dialogue>()
        {
           new Dialogue("King", " I am continually humbled by your kindness and generosity. -10 gold +9 happiness", rick),
        };
        DialogueManager.Instance.ShowDialogue(list, ShowAfter2);
    }
    void No2 ()
    {
        List<Dialogue> list = new List<Dialogue>()
        {
           new Dialogue("King", "  oh man!!! -2 happiness", rick),
        };
        DialogueManager.Instance.ShowDialogue(list, ShowAfter2);
    }
    void ShowAfter2()
    {
        List<Dialogue> list = new List<Dialogue>()
        {
           new Dialogue("The builder", " I’d like to build a new granary. This could help expand" +
           " our population, but it will cost you a little bit", rick),
        };
        List<Choice> choices = new List<Choice>();
        choices.Add(new Choice("YES", Yes3));
        choices.Add(new Choice("NO", No3));
        DialogueManager.Instance.ShowDialogue(list, "YES Or NO ?", choices);
    }

    void Yes3()
    {
        List<Dialogue> list = new List<Dialogue>()
        {
           new Dialogue("King", "Very well, let's invest in our future. population +10 money -50 ", rick),
        };
        DialogueManager.Instance.ShowDialogue(list);
    }
    void No3()
    {
        List<Dialogue> list = new List<Dialogue>()
        {
           new Dialogue("King", "alright we will stick with what we have got… -1 happiness", rick),
        };
        DialogueManager.Instance.ShowDialogue(list);
    }
    */
}
