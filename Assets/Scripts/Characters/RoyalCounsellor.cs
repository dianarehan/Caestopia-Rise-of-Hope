using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoyalCounsellor : Character
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        // First Scenario
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, " my lord, I’ll Help you rule the City but " +
            "you have to make some tough choices, do you understand?", avatar));
        
        
        scenario.Push(new Dialogue(name, "don't worry. I'll help you in your choice", avatar));
        scenario.Push(new Question("Do You Agree?", new List<Choice>()
        {
            new Choice("YES", Yes1),
            new Choice("NO", No1)
        }));
        SetFirstScenario(scenario);
        // The system ignores the actionAfter function if the scenario ends with a question
    }

    // CAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAK
    // AAAAAAAAAAAAAAAAAAAAAAAAAAAA3333333333333333333333333333333333333333
    // AAAAAAAA33333333333333 6 HOURS DEBUGGING AAAAAAAAAAA3333333333333333
    // AAAAAAAAAAAAAAAAAAAAAAAAAAAA3333333333333333333333333333333333333333
    // CAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAK

    void Scenario2()
    {
        // Sceond Scenario
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "OOPS !! There is an Emergency :(!", avatar));
        
        scenario.Push(new Dialogue(name, "I have to go to the bathroom.\n" +
            "I trust you can make the perfect decisions, until I come back", avatar));
        scenario.Push(new Question("Kill the Counsellor ?", new List<Choice>()
        {
            new Choice("Kill Him", KillHim),
            new Choice("Wait for him", WaitForHim)
        }));
        scenario.StartScenario();
    }

    void Yes1()
    {
        Scenario scenario1 = new Scenario();
        scenario1.Push(new Dialogue("King", "Our city is now small and have some issues but it has the potential to grow.", avatar));
        scenario1.Push(new Dialogue("King", "for now you have to keep the citizens happy and grow our city .", avatar));
        scenario1.StartScenario(Scenario2);
           
    }
    void No1()
    {
        Scenario scenario1 = new Scenario();
        scenario1.Push(new Dialogue("King", "haha funny just give the people some answers.", avatar));
        scenario1.StartScenario(Scenario2);
    }

    void KillHim()
    {
        ResourcesManager.AddHappiness(-15);
        ResourcesManager.AddPopulation(-45);
        characterMovement.Kill();
    }
    void WaitForHim()
    {
        Debug.Log("Waiting");
        characterMovement.Leave();
    }
}
