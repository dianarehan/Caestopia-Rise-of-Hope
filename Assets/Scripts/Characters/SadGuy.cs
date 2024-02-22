using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadGuy : Character
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Scenario scenario = new Scenario();
        scenario.Push(new List<Dialogue>()
        {
            new Dialogue(name, "Hello King, I ....", avatar),
            new Dialogue(name, "I am here to ask ...", avatar),
            new Dialogue("King", "Huh!?", kingAvatar),
            new Dialogue(name, "I want you to end my life.", avatar),
            new Dialogue("King", "That's strange.", kingAvatar),
        });
        scenario.Push(new Question("", new List<Choice>()
        {
            new Choice("How much money do you have?", HowMuchMoney),
            new Choice("What's bothering you?", WhatHappend),
            new Choice("Whoa, I'm not going to be part of this. Leave now.", LessHappyAndLeave)
        }));
        SetFirstScenario(scenario);
    }

    void HowMuchMoney()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new List<Dialogue>()
        {
            new Dialogue(name, "45 coins", avatar),
            new Dialogue("King", "So, you're thinking of this because you're broke. " +
            "There are easier ways to get help.", kingAvatar),
            new Dialogue(name, "It's not about the money.", avatar),
            new Dialogue("King", "It's about what ?", kingAvatar)
        });
        scenario.StartScenario(WhatHappend);
    }
    void WhatHappend()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new List<Dialogue>()
        {
            new Dialogue(name, "I've had some really bad stuff happen.", avatar),
            new Dialogue("King", "Go ahead, tell me.", kingAvatar),
            new Dialogue(name, "my true love ....", avatar),
            new Dialogue(name, "She left me. She was everything to me, literally everything.", avatar),
            new Dialogue("King", "When did this happen?", kingAvatar),
            new Dialogue(name, "some months ago.", avatar),
            new Dialogue("King", "Maybe It's time to move on and find something better.", kingAvatar),
            new Dialogue(name, "That's the problem, Your Majesty. I can't forget anything or move past it.", avatar)
        });
        scenario.Push(new Question("What will you say?", new List<Choice>()
        {
            new Choice("Your life is worth more than this; you don't deserve to give up.", YourLifeWorth),
            new Choice("Consider the reasons; you'll see a brighter path.", ConsiderTheReasons),

        }));
        scenario.StartScenario();
    }
    void YourLifeWorth()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "I can't handle this pain anymore. It just won't go away.", avatar));
        scenario.Push(new Question("Choose", new List<Choice>()
        {
            new Choice("If you won't choose life, then I'll have to help you end it.", KillTheGuy),
            new Choice("Do you have a job?", HaveAJob)
        }));
        scenario.StartScenario();
    }
    void KillTheGuy()
    {
        KillCharacter();
        ResourcesManager.AddPopulation(-5);
        ResourcesManager.AddHappiness(-15);
    }
    void HaveAJob()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new List<Dialogue>()
        {
            new Dialogue(name, "No, I quit my job.", avatar),
            new Dialogue("King", "I'll give you work here in the castle and support you.", kingAvatar)
        });
        scenario.StartScenario(() => 
        {
            ResourcesManager.AddMoney(-30);
            ResourcesManager.AddHappiness(15);
            Leave();
        });
    }
    void ConsiderTheReasons()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new List<Dialogue>()
        {
            new Dialogue(name, "The reasons seem weak, all of them.", avatar),
            new Dialogue(name, "I think these things could change or get better.", avatar),
            new Dialogue("King", "you don't have to change to be loved and valued.", kingAvatar),
            new Dialogue(name, "I just want to feel peaceful and safe again.", avatar)
        });
        scenario.Push(new Question("", new List<Choice>()
        {
            new Choice("Ask the guards to get her back", ()=>{ResourcesManager.AddHappiness(-5); Leave(); }),
            new Choice("Make him see a doctor", ()=>{ResourcesManager.AddMoney(-20); Leave(); }),
            new Choice("End the pain (kill him)", KillTheGuy)
        }));
        scenario.StartScenario();
    }
    void LessHappyAndLeave()
    {
        ResourcesManager.AddHappiness(35);
        Leave();
    }
}
