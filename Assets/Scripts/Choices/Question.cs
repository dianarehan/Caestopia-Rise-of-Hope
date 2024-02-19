using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : ScenarioBaseClass
{
    string name;
    List<Choice> choices = new List<Choice>();

    public string Name { get { return name; } }
    public List<Choice> Choices { get { return choices; } }

    public Question(string name, List<Choice> choices)
    {
        this.name = name;
        this.choices = choices;
    }
}
