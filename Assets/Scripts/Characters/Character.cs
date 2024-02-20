using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected Sprite avatar;

    [SerializeField]
    protected new string name;

    protected List<Scenario> CharacterScenarios = new List<Scenario>();
    int index = 0;
    public virtual Scenario GetNextScenario()
    {
        if (index < CharacterScenarios.Count)
        {
            return CharacterScenarios[index++];
        }
        else 
        {
            Scenario scenario = new Scenario();
            scenario.Push(new Dialogue(name, "Hello King", avatar));
            return scenario;
        }
    }
}
