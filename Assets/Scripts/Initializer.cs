using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Initializer : MonoBehaviour
{
    [SerializeField] private UIDocument dialogueUI;
    [SerializeField] private UIDocument choicesUI;
    [SerializeField] private VisualTreeAsset ChoiceCard;
    [SerializeField] private GameObject moneyFade;
    [SerializeField] private GameObject happinessFade;
    [SerializeField] private GameObject populationFade;

    void Awake()
    {
        DialogueManager.Instance.Initialize(dialogueUI);
        ChoicesManager.Initialize(choicesUI, ChoiceCard);
        ResourcesManager.Initialize(moneyFade, happinessFade, populationFade);
    }
}
