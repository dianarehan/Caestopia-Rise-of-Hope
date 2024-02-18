using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public static class ChoicesManager 
{
    private static VisualTreeAsset choiceCard;
    private static VisualElement root;
    private static VisualElement choicesList;
    private static Label questionLable; 

    public static void Initialize(UIDocument choicesUI, VisualTreeAsset _choiceCard)
    {
        root = choicesUI.rootVisualElement;
        choiceCard = _choiceCard;
        choicesList = root.Q<VisualElement>("ChoicesList");
        questionLable = root.Q<Label>("Question");
    }

    public static void ShowChoices(string question, List<Choice> choices)
    {
        root.style.display = DisplayStyle.Flex;
        choicesList.Clear();
        questionLable.text = question;

        foreach (Choice choice in choices)
        {
            VisualElement _choice = choiceCard.Instantiate();
            Button choiceBut = _choice.Q<Button>("Choice");
            choiceBut.text = choice.Name;
            choiceBut.clicked += () => {
                choice.Action.Invoke();
                root.style.display = DisplayStyle.None;
            };
            choicesList.Add(_choice);
        }
    }
}
