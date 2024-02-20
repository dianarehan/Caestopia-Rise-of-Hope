using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RoyalCounsler : Character
{
    // Start is called before the first frame update
    void Start()
    {
        Scenario scenario1 = new Scenario();
        scenario1.Push(new Dialogue( name, " my lord, I’ll Help you rule the City but" +
            " you have to make some tough choices, do you understand?", avatar));
        List<Choice>choices = new List<Choice>()
        {
            new Choice("YES", Yes1),
            new Choice("No", No1)
        };
        scenario1.Push(new Question("Do You Agree?", choices));
        CharacterScenarios.Add(scenario1);
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
