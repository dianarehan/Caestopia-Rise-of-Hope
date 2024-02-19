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

        root.style.display = DisplayStyle.None;
    }

    public static void ShowChoices(Question question)
    {
        root.style.display = DisplayStyle.Flex;
        choicesList.Clear();
        questionLable.text = question.Name;

        foreach (Choice choice in question.Choices)
        {
            VisualElement _choice = choiceCard.Instantiate();
            Button choiceBut = _choice.Q<Button>("Choice");
            choiceBut.text = choice.Name;
            choiceBut.clicked += () => {
                choice.Action.Invoke();
                if (choice.NxtItem != null ) 
                {
                    if (choice.NxtItem is Question)
                    {
                        // AW3AAAAA EL RECURSION
                        ShowChoices((Question)choice.NxtItem);
                    }
                    else if (choice.NxtItem is Dialogue)
                    {
                        root.style.display = DisplayStyle.None;
                         DialogueManager.Instance.ShowDialogue((Dialogue)choice.NxtItem);
                    }
                }
                root.style.display = DisplayStyle.None;
            };
            choicesList.Add(_choice);
        }
    }
}
