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
    int indx = 0;
    public virtual Scenario GetNextScenario()
    {
        if (indx < CharacterScenarios.Count)
        {
            return CharacterScenarios[indx++];
        }
        else {
            Scenario scenario = new Scenario();
            scenario.Push(new Dialogue(name, "Hallo King", avatar));
            return scenario;
        }
    }
}
