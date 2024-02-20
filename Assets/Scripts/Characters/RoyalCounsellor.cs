using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RoyalCounsellor : Character
{
    // Start is called before the first frame update
    void Start()
    {
        // First Scenario
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, " my lord, I’ll Help you rule the City but " +
            "you have to make some tough choices, do you understand?", avatar));
        
        scenario.Push(new Question("Do You Agree?", new List<Choice>()
        {
            new Choice("YES", Yes1),
            new Choice("No", No1)
        }));
        CharacterScenarios.Add(scenario);


        // Sceond Scenario
        scenario = new Scenario();
        scenario.Push(new Dialogue(name, "OOPS !! There is an Emergency :(!", avatar));
        scenario.Push(new Dialogue(name, "I have to go to the bathroom.\n" +
            "I trust you can make the perfect decisions, until I come back", avatar));
        /*
        scenario.Push(new Question("Kill the Counsellor ?", new List<Choice>()
        {
            new Choice("Kill Him", )
        }));
        */

        CharacterScenarios.Add(scenario);
    }

    void Yes1()
    {
        Scenario scenario1 = new Scenario();
        scenario1.Push(new Dialogue("King", "Our city is now small and have some issues but it has the potential to grow.", avatar));
        scenario1.Push(new Dialogue("King", "for now you have to keep the citizens happy and grow our city .", avatar));
        scenario1.Push(new Dialogue("King", "-good luck sir!! .", avatar));
        scenario1.StartScenario();
           
    }
    void No1()
    {
        Scenario scenario1 = new Scenario();
        scenario1.Push(new Dialogue("King", "haha funny just give the people some answers.", avatar));
        scenario1.StartScenario();
    }
}
