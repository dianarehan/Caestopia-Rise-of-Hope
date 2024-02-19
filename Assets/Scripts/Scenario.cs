using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario
{
    private List<ScenarioBaseClass> scenarioSequences;

    public Scenario()
    {
        scenarioSequences = new List<ScenarioBaseClass>();
    }

    public void Push(List<Dialogue> dialoguesList)
    {
        foreach (var dialogue in dialoguesList) 
        {
            scenarioSequences.Add(dialogue);
        }
    }

    private void ConnectToLast(ScenarioBaseClass newItem)
    {
        if (scenarioSequences[scenarioSequences.Count-1] is Dialogue)
        {
            Dialogue last = scenarioSequences[scenarioSequences.Count-1] as Dialogue;
            last.Connect(newItem);
        }
    }

    public void Push(Dialogue dialogue)
    {
        if (scenarioSequences.Count > 0)
        {
            ConnectToLast(dialogue);
        }
        scenarioSequences.Add(dialogue);
    }
    public void Push(Question question)
    {
        if (scenarioSequences.Count > 0)
        {
            ConnectToLast(question);
        }
        scenarioSequences.Add((Question)question);
    }


    public void StartScenario()
    {
        if (scenarioSequences.Count > 0) 
        {
            if (scenarioSequences[0] is Dialogue)
            {
                DialogueManager.Instance.ShowDialogue((Dialogue)scenarioSequences[0]);
            }
            else if (scenarioSequences[0] is Question) 
            {
                ChoicesManager.ShowChoices((Question)scenarioSequences[0]);
            }
        }
        scenarioSequences.Clear();
    }
    
}
