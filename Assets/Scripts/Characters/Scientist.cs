using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scientist : Character
{
    static int neg500Offer = -1;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        // Handle the accepted offer
        if (neg500Offer == 1)
        {
            Scenario profitScenario = new Scenario();
            profitScenario.Push(new Dialogue(name, " You honor," +
                " I am here to give you updates on the Azor researches," +
                " we are close to a major breakthrough, However," +
                " Might I request the donation for a few skilled workers?", avatar));
            profitScenario.Push(new Question("Choose", new List<Choice>()
            {
                new Choice("YES", SpecYes1),
                new Choice("NO", SpecNo1)
            }));
            SetFirstScenario(profitScenario);
            return;
        }
        else if (neg500Offer == 0)
        {
            KillCharacter();
        }

        Scenario scenario = new Scenario();
        scenario.Push(new List<Dialogue>()
        {
            new Dialogue(name, " Greetings, Your Majesty. I bring news from the laboratories." +
            " We've made a breakthrough in our research on Azor and its applications in technology.", avatar),
            new Dialogue(name, "With your support, we can unlock the true potential of Azor." +
            " This will require a couple of hundreds of gold and time, but the benefits could" +
            " revolutionize our city's technology.", avatar)
        });
        scenario.Push(new Question("Do you agree?", new List<Choice>()
        {
            new Choice("YES", Yes1),
            new Choice("Not today, there is no enough resources", No1)
        }));
        SetFirstScenario(scenario);
    }
    void Yes1()
    {
        ResourcesManager.AddMoney(-200);
        neg500Offer = 1;
        Leave();
    }
    void No1()
    {
        ResourcesManager.AddHappiness(-3);
        neg500Offer = 0;
        Scenario scenario = new Scenario();
        scenario.Push(new List<Dialogue>()
        {
            new Dialogue(name, "I understand, Your Majesty." +
            " We shall continue our research with the resources available." +
            " However, progress may be slower than desired", avatar),
            new Dialogue(name, "Your Majesty. While our research on Azor is important," +
            " We shall focus on the immediate needs of the city. However," +
            " I urge you not to forget the potential it holds for our city's advancement", avatar)
        });
        scenario.StartScenario(Leave);
    }
    void SpecYes1()
    {
        ResourcesManager.AddMoney(-50);
        ResourcesManager.AddPopulation(-12);
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Very well!!", avatar));
        scenario.StartScenario(Leave);
    }
    void SpecNo1()
    {
        ResourcesManager.AddHappiness(-2);
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue(name, "Hmm, this will set us back a bit.Yes," +
            " yes it will", avatar));
        scenario.StartScenario(Leave);
    }
    
}
