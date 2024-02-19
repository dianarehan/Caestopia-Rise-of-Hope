using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Choice
{
    private string name;
    private UnityAction action;
    ScenarioBaseClass nxtItem;

    public string Name { get { return name; } }
    public UnityAction Action { get { return action; } }
    public ScenarioBaseClass NxtItem { get { return nxtItem; } }

    public Choice(string name, UnityAction action)
    {
        this.name = name;
        this.action = action;
        this.nxtItem = null;
    }
    public Choice(string name, UnityAction action, ScenarioBaseClass nxtItem)
    {
        this.name = name;
        this.action = action;
        this.nxtItem = nxtItem;
    }
}
