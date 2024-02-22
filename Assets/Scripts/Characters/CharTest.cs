using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CharTest : Character
{
    static List<Scenario> scenarios = new List<Scenario>();
    static int index = 0;

    protected override void Start()
    {
        base.Start();

        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Hello my king i have a problem.", avatar));
        scenario.Push(new Dialogue(name, "a goat of mine was eating the new elctropizza happy meal, but a hard chip cut its neck and killed it.\n" +
            "I want to get money as a compensation for the damage.", avatar));
        scenario.Push(new Question("Choose", new List<Choice>()
        {
            new Choice("How possible you are poor and your goat eats elctropizza you are a liar and have to pay 50 coin", YouAreLiar),
            new Choice("Walla a3teh 200 coins", Pay200),
            new Choice("ahmmmm, you are poor it's better to be killed now", Scenario2)
        }));

        scenarios.Add(scenario);


        scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Hello my king i have a problem.", avatar));
        scenario.Push(new Dialogue(name, "a goat of mine was eating the new elctropizza happy meal, but a hard chip cut its neck and killed it.\n" +
            "I want to get money as a compensation for the damage.", avatar));
        scenario.SetActionAfter(Leave);
        scenarios.Add(scenario);

        if (scenarios.Count > index)
        {
            SetFirstScenario(scenarios[index]);
            scenarios.Clear();
            index++;
        }
    }

    void YouAreLiar()
    {
        ResourcesManager.AddMoney(50);
        ResourcesManager.AddHappiness(-20);
        ResourcesManager.AddLoyality(-20);
        Leave();
    }
    void Pay200()
    {
        ResourcesManager.AddMoney(-200);
        Leave();
    }
    void Scenario2()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new List<Dialogue>()
        {
            new Dialogue(name, "nooo king I'm Mr:Krabs the owner of a big burger restaurant in the Bikini Bottom city. It's April fool hahahaha.", avatar),
            new Dialogue("King", "It's not April.", kingAvatar),
            new Dialogue(name, "oohh Really !!!!!! what a surprise", avatar)
        });
        scenario.Push(new Question("What will you say ?", new List<Choice>()
        {
            new Choice("You are fined 25 conis", Add25),
            new Choice("hahaha. send my regards to Spongebob and el osra el kareema", Leave),
        }));
        scenario.StartScenario();
    }
    void Add25()
    {
        ResourcesManager.AddMoney(25);
        Leave();
    }
}
