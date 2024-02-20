using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;
using System;

public class Test : MonoBehaviour
{
    [SerializeField] private Sprite rick;
    [SerializeField] private Sprite morty;
    [SerializeField] private Sprite batman;


    // Start is called before the first frame update
    void Start()
    {
        Scenario scenario = new Scenario();


        scenario.Push(new Dialogue("Poor Guy", "My king, this man hasn't paid me for four months, even though I've worked diligently. When I asked him about my paycheck, he kicked me from my job.", rick));
        scenario.Push(new Dialogue("Rich Guy", "My king, this man owes me nothing. The transplant was poor this year, and I have a surplus of workers. I can't keep hiring them all.", rick));
        scenario.Push(new Question("What will you say", new List<Choice>()
        {
            new Choice("He owes you nothing", HeOwesYouNothing),
            new Choice("Get Lost", GetLost),
            new Choice("Give him his money", GiveHimHisMoney),

        }  
            ));
        scenario.StartScenario();
    }

    void HeOwesYouNothing()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue("Poor Guy", "But my king, that paycheck is the only way to feed my family. Please reconsider your judgment, my lord.", rick));
        scenario.StartScenario();
    }
    void GetLost()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue("Poor Guy", "That's not fair! -2 Happiness, -2 Popularity", rick));
        scenario.StartScenario();
    }
    void GiveHimHisMoney()
    {
        Scenario scenario = new Scenario();
        scenario.Push(new Dialogue("Rich Guy", "My lord, it's not fair. I pay taxes and contribute to the economy. Making losses for a filthy guy, MY MONEY!", rick));
        scenario.Push(new Dialogue("Rich Guy", "Okay, my king, but remember, we who made you. - 15 Gold, +5 Popularity, +2 Happiness", rick));
        scenario.StartScenario();
    }

}
