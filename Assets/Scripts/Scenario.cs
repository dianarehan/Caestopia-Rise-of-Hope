using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scenario
{
    private List<ScenarioBaseClass> scenarioSequences;
    private UnityAction actionAfter;

    public UnityAction ActionAfter {  get { return actionAfter; } }

    public Scenario()
    {
        scenarioSequences = new List<ScenarioBaseClass>();
        actionAfter = null;
    }

    public void Push(List<Dialogue> dialoguesList)
    {
        foreach (var dialogue in dialoguesList) 
        {
            Push(dialogue);
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
        StartScenario(actionAfter);
    }

    public void SetActionAfter(UnityAction unityAction)
    {
        this.actionAfter = unityAction;
    }

    // The system ignores the actionAfter function if the scenario ends with a question
    public void StartScenario(UnityAction actionAfter)
    {
        SetActionAfter(actionAfter);
        if (scenarioSequences.Count > 0)
        {
            if (scenarioSequences[0] is Dialogue)
            {
                DialogueManager.Instance.ShowDialogue((Dialogue)scenarioSequences[0], actionAfter);
            }
            else if (scenarioSequences[0] is Question)
            {
                ChoicesManager.ShowChoices((Question)scenarioSequences[0]);
            }
        }
        scenarioSequences.Clear();
    }
}
