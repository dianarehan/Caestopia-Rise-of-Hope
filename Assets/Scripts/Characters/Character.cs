using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected Sprite avatar;

    [SerializeField]
    protected Sprite kingAvatar;

    [SerializeField]
    protected new string name;

    protected Scenario firstScenario;
    protected UnityAction firstActionAfter;

    protected CharacterMovement characterMovement;

    protected virtual void Start() 
    {
        characterMovement = GetComponent<CharacterMovement>(); 
    }
    protected void Leave()
    {
        characterMovement.Leave();
    }
    protected void SetFirstScenario(Scenario scenario)
    {
        this.firstScenario = scenario;
        this.firstActionAfter = null;
    }
    protected void SetFirstScenario(Scenario scenario, UnityAction actionAfter)
    {
        this.firstScenario = scenario;
        this.firstActionAfter = actionAfter;
    }
    public void StartFirstScenario()
    {
        firstScenario.StartScenario(firstActionAfter);
    }
}
