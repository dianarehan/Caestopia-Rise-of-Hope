using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoorMan : Character
{
    static List<Scenario> scenarios = new List<Scenario>();
    static int index = 0;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "I’d like to build a new granary." +
            " This could help expand our population, but it will cost you a little bit.", avatar));
        scenario.Push(new Question("Build it ?", new List<Choice>()
        {
            new Choice("YES", Yes1),
            new Choice("NO", No1)
        }));
        scenarios.Add(scenario);

        if (scenarios.Count > index)
        {
            SetFirstScenario(scenarios[index]);
            scenarios.Clear();
            index++;
        }
    }

    void Yes1()
    {
        ResourcesManager.AddPopulation(10);
        ResourcesManager.AddMoney(-50);

        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Very well, let's invest in our future.", avatar));
        scenario.StartScenario(Scenario2);
    }
    void No1()
    {
        ResourcesManager.AddHappiness(-5);
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "alright, we will stick with what we have got", avatar));
        scenario.StartScenario(Scenario2);
    }
    void Scenario2()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "My boat is too tiny, I can't catch many fish to be sufficient for the people in the city," +
            " may I have some gold to upgrade it?", avatar));
        scenario.Push(new Question("Pay 18 gold coins", new List<Choice>()
        {
            new Choice("YES", Yes2),
            new Choice("NO", No2)
        }));
        scenario.StartScenario();
    }
    void Yes2() 
    {
        ResourcesManager.AddMoney(-18);
        ResourcesManager.AddHappiness(9);
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "I am continually humbled by your kindness and generosity.", avatar));
        scenario.StartScenario(Leave);
    }
    void No2()
    {
        ResourcesManager.AddHappiness(-6);
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Oh King, as you wish!", avatar));
        scenario.StartScenario(Leave);
    }
}
