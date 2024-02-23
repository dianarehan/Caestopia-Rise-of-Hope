using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoyalAdvisor: Character
{
    static List<Scenario> scenarios = new List<Scenario>();
    static int index = 0;

    public static bool isSpecialLowMony = false;
    public static bool isSpecialLowPopulation = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        if(isSpecialLowPopulation)
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
        scenario.Push(new Dialogue( name, "My lord, I’ll help you rule the city, but you" +
            " have to make some tough choices.", avatar));
        scenario.Push(new Question("Do you understand?", new List<Choice>()
        {
            new Choice ("Yes",Yes1),
            new Choice("No",No1)
        }));

        scenarios.Add(scenario);

        Scenario2();
        Scenario3();
        Scenario4();
        Scenario5();

        if (scenarios.Count > index)
        {
            SetFirstScenario(scenarios[index]);
            scenarios.Clear();
            index++;
        }

    }
    void Yes1()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Our city is now small and have so many issues, " +
            "but it has the potential to grow.", avatar));
        scenario.Push(new Dialogue(name, "For now, you have to keep the citizens happy and grow our city", avatar));
        scenario.Push(new Dialogue(name, "Good Luck sir!!", avatar));
        scenario.StartScenario(Leave);

    }

    void No1 ()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "HAHAHA! Funny, just give the people some answers.", avatar));
        scenario.StartScenario(Leave);
    }

    void Scenario2()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Your Majesty, Mason and David are back again, these two citizens keep arguing each " +
            "one of them claims his that he owns this property, and they are kinda causing chaos in the city.", avatar));

        scenario.Push(new Dialogue(name, "Mason, descendant from the Royal family who was a part of this Reverse we are living right now, seeks to" +
            " reclaim ancestral lands lost during the apocalypse..", avatar));

        scenario.Push(new Dialogue(name, "Meanwhile, David, a former farmer,David led his family and fellow survivors on a journey of survival.", avatar));
        scenario.Push(new Dialogue(name, "After months of hardship, they stumbled upon the abandoned property on the outskirts of the kingdom.", avatar));
        scenario.Push(new Dialogue(name, "He toiled day and night, clearing the land, planting crops, and building shelters for the displaced survivors.", avatar));
        scenario.Push(new Dialogue(name, "As the years passed, David's community flourished, but as you see they are threatend by the return of the kingdom's rulers who want to take back their propert.", avatar));

        scenario.Push(new Question("Who has the right to take this land?", new List<Choice>()
        {
            new Choice ("Give it back to Mason.",Mason),
            new Choice("Take David's side this time.",David)
        }));
        scenarios.Add(scenario);
    }

    void Mason() 
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "You are right!! Because sins of the ancestors" +
            " should not be visited upon the descendants.", avatar));

        scenario.StartScenario(Leave);

        ResourcesManager.AddPopulation(-30);
        ResourcesManager.AddHappiness(-50);
        ResourcesManager.AddMoney(300);

    }

    void David () 
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "You are right!!  As this land is not just their homes, but their hopes and dreams for a better future after what Mason’s Ancestors have done.", avatar));

        scenario.StartScenario(Leave);

        ResourcesManager.AddPopulation(-20);
        ResourcesManager.AddHappiness(13);
        ResourcesManager.AddMoney(10);
    }
    void Scenario3()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Villagers are complaining about garbage in" +
            " the streets.", avatar));

        scenario.Push(new Question("Shall we hire workers to clean it up?", new List<Choice>()
        {
            new Choice ("Yes",Yes3),
            new Choice("No",No3)
        }));
        scenarios.Add(scenario);
    }

    void Yes3 ()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "The villagers noses will thank you for sure.", avatar));

        scenario.StartScenario(Leave);

        ResourcesManager.AddHappiness(5);
        ResourcesManager.AddMoney(-50);
    }

    void No3 ()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Maybe we could solve this later, but we got bigger" +
            " issues right now!!", avatar));

        scenario.StartScenario(Leave);

        ResourcesManager.AddHappiness(-5);
    }

    void Scenario4() 
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Some refugees, arrived in the city, Should we welcome them?", avatar));

        scenario.Push(new Question("Choose what you want to do", new List<Choice>()
        {
            new Choice ("Yes, our city is open to anyone.",Yes4),
            new Choice("No, we must think about the resources before taking any decisions.",No4)
        }));
        scenarios.Add(scenario);
    }
    void Yes4 () 
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "That is great. The city is growing more and more.", avatar));

        scenario.StartScenario(Leave);

        ResourcesManager.AddPopulation(12);
        ResourcesManager.AddHappiness(5);
    }

    void No4 ()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "But.. why? Well, as you wish.", avatar));

        scenario.StartScenario(Leave);
    }

    void Scenario5()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Your Majesty, reports indicate that a deadly plague " +
            "has broken out in the poorer districts of the city", avatar));

        scenario.Push(new Question("Shall we allocate resources for medical aid and quarantine measures?", new List<Choice>()
        {
            new Choice ("Yes",Yes5),
            new Choice("No",No5)
        }));
        scenarios.Add(scenario);
    }
    void Yes5()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Your compassion will be remembered, sir.", avatar));

        scenario.StartScenario(Leave);

        ResourcesManager.AddPopulation(-5);
        ResourcesManager.AddHappiness(10);
        ResourcesManager.AddMoney(-60);
    }

    void No5()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Turning a blind eye could lead to unrest, my lord. But" +
            " as you command.", avatar));

        scenario.StartScenario(Leave);
        ResourcesManager.AddPopulation(-15);
    }

    void SpecialLowMonyScenario()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "The treasury is empty, my lord.", avatar));
        scenario.Push(new Dialogue(name, "We could raise taxes a bit further, but people won’t like it much.", avatar));
        scenario.Push(new Question("Should we try?", new List<Choice>()
        {
            new Choice ("Yes",Yes6),
            new Choice("No",No6)
        }));
        SetFirstScenario(scenario);
    }

    void SpeialLowPopulationScenario()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "The city population increased, " +
            "now this little city became a home to those citizens, so make sure to pay " +
            "attention to them and their issues to raise their happiness", avatar));
        scenario.Push(new Dialogue(name, "Anyways we still a lot of work to do.", avatar));
        SetFirstScenario(scenario,Leave);
    }

    void Yes6()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "It was really tough decision though.", avatar));

        scenario.StartScenario(Leave);

        ResourcesManager.AddHappiness(-5);
        ResourcesManager.AddMoney(+250);
    }
    void No6()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "We will Still need to figure it out!!", avatar));

        scenario.StartScenario(Leave);

        ResourcesManager.AddHappiness(+5);
    }
}
