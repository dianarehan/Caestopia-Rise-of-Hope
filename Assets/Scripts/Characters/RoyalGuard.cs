using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoyalGuard : Character
{
    [SerializeField]
    Sprite royalAdvisorAvatar;

    [SerializeField]
    Sprite poorManAvatar;

    public static bool isSpecialLowMony = false;
    public static bool isSpecialLowPopulation = false;
    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start();

        if (isSpecialLowPopulation)
        {
            isSpecialLowPopulation = false;
            SpeialLowPopulationScenario();
            return;
        }

        if (isSpecialLowMony) 
        {
            isSpecialLowMony = false;
            SpecialLowMonyScenario();
            return;
        }

        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Representatives from neighboring tribes " +
            "seek an alliance with the city for mutual protection and trade", avatar));
        scenario.Push(new Question("Will you ally with them?", new List<Choice>()
        {
            new Choice ("Yes.",Yes1),
            new Choice("Not now.",NotNow)
        }));
        SetFirstScenario(scenario);
    }

    void Yes1()
    {
        ResourcesManager.AddPopulation(20);
        ResourcesManager.AddHappiness(-5);
        ResourcesManager.AddMoney(-25);
        Scenario2();
       
    }

    void NotNow()
    {
        ResourcesManager.AddHappiness(5);
        Scenario2();
    }

    void Scenario2 ()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "The town we made an alliance with is in trouble!", avatar));

        scenario.Push(new Question("Should we send soldiers to assist them?", new List<Choice>()
        {
            new Choice ("Yes",Yes2),
            new Choice("No",No2)
        }));
        scenario.StartScenario();
    }
    
    void Yes2()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Sure! I’ll tell the military general about your decision.", avatar));

        scenario.StartScenario(Scenario3);

        ResourcesManager.AddPopulation(-10);

    }

    void No2()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "But… we promised we’d protect them. They won’t" +
            " be happy about this.", avatar));

        scenario.StartScenario(Scenario3);
        ResourcesManager.AddPopulation(10);
    }

    void Scenario3()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "There is a party I’d like to go to this evening, my lord.", avatar));

        scenario.Push(new Question("Might I have the rest of the day off?", new List<Choice>()
        {
            new Choice ("Yes",Yes3),
            new Choice("No",No3)
        }));
        scenario.StartScenario();
    }

    void Yes3 ()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Thank you! We will toast to your honor!", avatar));

        scenario.StartScenario(Leave);
        ResourcesManager.AddHappiness(5);
    }

    void No3 ()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Oh dear… I told my friends I’d be there.", avatar));

        scenario.StartScenario(Leave);
        ResourcesManager.AddHappiness(-5);
    }

    void SpecialLowMonyScenario()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "I’ve came across this treasure and decided to give it to the Kingdom", avatar));

        scenario.Push(new Question("Will you accept it?", new List<Choice>()
        {
            new Choice ("Yes",Yes4),
            new Choice("No",No4)
        }));
        SetFirstScenario(scenario);
    }

    void SpeialLowPopulationScenario()
    {

    }

    void Yes4()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "It’s my pleasure to serve you.", avatar));

        scenario.StartScenario(Leave);

        ResourcesManager.AddMoney(100);
    }

    void No4()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "We will Still need to figure the money issue out!! ", avatar));

        scenario.StartScenario(Leave);

        ResourcesManager.AddMoney(100);
    }
}
