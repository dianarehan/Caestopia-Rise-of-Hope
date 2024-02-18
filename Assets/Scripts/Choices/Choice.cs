using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Choice 
{
    private string name;
    private UnityAction action;

    public string Name { get { return name; } }
    public UnityAction Action { get { return action; } }

    public Choice(string name, UnityAction action)
    {
        this.name = name;
        this.action = action;
    }
}
