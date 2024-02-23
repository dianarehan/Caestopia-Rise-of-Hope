using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wich : Character
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "I was just passing through, and I thought you may like some magic.\n Anything could happen!", avatar));
        scenario.Push(new Question(" Care to give it a try?", new List<Choice>()
        {
            new Choice ("Yes",Yes1),
            new Choice("NO",No1)
        }));
        SetFirstScenario(scenario);
    }
    void Yes1()
    {
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            Scenario scenario = new Scenario();
            scenario.Push(new Dialogue(name, "I told you anything could happen, enjoy the gold.", avatar));

            scenario.StartScenario();

            ResourcesManager.AddMoney(5);
        }
        else
        {
            Scenario scenario = new Scenario();
            scenario.Push(new Dialogue(name, "Oops, that was not meant to happen, I guess " +
                "the spell turned out to be evil.", avatar));
            scenario.StartScenario(Scenario2);
            ResourcesManager.AddPopulation(-15);
        }

    }

    void No1()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "I see you do not like taking risks, Fair enough!!", avatar));
        scenario.StartScenario(Scenario2);
    }

    void Scenario2()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "My broom’s all worn out, and it is my birthday…..Think you can buy me new one.", avatar));
        scenario.Push(new Question("Do you want to buy her a now one ?", new List<Choice>()
        {
            new Choice ("Yes",Yes2),
            new Choice("NO",No2)
        }));
        scenario.StartScenario();
    }

    void Yes2() 
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Thanks", avatar));
        scenario.StartScenario(Leave);

        ResourcesManager.AddMoney(-5);
        ResourcesManager.AddHappiness(5);
    }
    void No2()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "ou are no fun! I can’t be seen flying around with this shabby old thing", avatar));
        scenario.StartScenario(Leave);
        ResourcesManager.AddHappiness(-5);
    }
}
