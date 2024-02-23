using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSultan : Character
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "A wealthy ruler in a neighbouring city offers to invest in the city's" +
            " infrastructure in exchange for exclusive trading rights.", avatar));
        scenario.Push(new Question("What's your opinion", new List<Choice>()
        {
            new Choice("Yes", Yes1),
            new Choice("No, We better maintain autonomy", No1)
        }));
        SetFirstScenario(scenario);
    }

    void Yes1()
    {
        ResourcesManager.AddHappiness(-7);
        ResourcesManager.AddMoney(40);
        Scenario2();

    }
    void No1()
    {
        ResourcesManager.AddHappiness(6);
        Scenario2();
    }
    void Scenario2()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "I have got a business proposition for" +
            " you and your little city, are you interested?", avatar));
        scenario.Push(new Question("Are you interested", new List<Choice>()
        {
            new Choice("Yes", Yes2),
            new Choice("No", No2)
        }));
        scenario.StartScenario();
    }
    void Yes2()
    {
        ResourcesManager.AddHappiness(3);
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Aha. I will bring you the details soon.", avatar));
        scenario.StartScenario(Leave);
    }
    void No2()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Quite agreeable, maybe we work in the future.", avatar));
        scenario.StartScenario(Leave);
    }
}
