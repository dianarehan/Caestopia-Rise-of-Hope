using System.Collections.Generic;
using UnityEngine.UIElements;

public static class DialogueManager
{
    private static UIDocument dialogueTemplate;

    private static VisualElement root;
    private static Label charName;
    private static Label message;
    private static VisualElement charAvatar;

    private static List<Dialogue> dialogueList;
    private static int dialogueIndex;

    private static string questionAfter;
    private static List<Choice> choicesAfter;

    public static void Initialize(UIDocument _dialogueTemplate)
    {
        dialogueIndex = 0;
        dialogueTemplate = _dialogueTemplate;
        root = dialogueTemplate.rootVisualElement;
        charName = root.Q<Label>("CharName");
        message = root.Q<Label>("Message");
        charAvatar = root.Q<VisualElement>("CharAvatar");

        root.RegisterCallback((ClickEvent evt) => 
        {
            dialogueIndex++;
            if (dialogueIndex >= dialogueList.Count)
            {
                root.style.display = DisplayStyle.None;
                if (questionAfter != null) 
                {
                    ChoicesManager.ShowChoices(questionAfter, choicesAfter);
                }
            }
            else
            {
                BindDialogue();
            }
        });
        root.style.display = DisplayStyle.None;
    }

    private static void BindDialogue()
    {
        Dialogue dialogue = dialogueList[dialogueIndex];

        charName.text = dialogue.CharName;
        message.text = dialogue.Message;
        charAvatar.style.backgroundImage = new StyleBackground(dialogue.CharAvatar);
    }

    public static void ShowDialogue(List<Dialogue> _dialogueList) 
    {
        choicesAfter = null;
        questionAfter = null;
        dialogueList = _dialogueList;
        dialogueIndex = 0;
        root.style.display = DisplayStyle.Flex;
        BindDialogue();
    }

    public static void ShowDialogue(List<Dialogue> _dialogueList, string _question,List<Choice> _choicesAfter)
    {
        ShowDialogue(_dialogueList);
        choicesAfter = _choicesAfter;
        questionAfter = _question;
    }

}
