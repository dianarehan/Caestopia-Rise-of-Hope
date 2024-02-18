using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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
            }
            else
            {
                BindDialogue();
            }
        });
    }

    private static void BindDialogue()
    {
        Dialogue dialogue = dialogueList[dialogueIndex];

        root.style.display= DisplayStyle.Flex;
        charName.text = dialogue.CharName;
        message.text = dialogue.Message;
        charAvatar.style.backgroundImage = new StyleBackground(dialogue.CharAvatar);
    }

    public static void ShowDialogue(List<Dialogue> _dialogueList) 
    {
        dialogueList = _dialogueList;
        dialogueIndex = 0;
        BindDialogue();
    }
}
