using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    private Coroutine curCoroutine;

    private UIDocument dialogueTemplate;
    private Label charName;
    private Label message;
    private VisualElement charAvatar;
    private VisualElement root;

    private Dialogue headDialogue;
    private UnityAction actionAfter;

    public static DialogueManager Instance
    {
        get
        {
            // More Optimized
            if (instance != null) return instance;
            else return instance = FindObjectOfType<DialogueManager>();
        } 
    }

    private Coroutine StopAndStartCoroutine(IEnumerator newCoroutine)
    {
        if (curCoroutine != null)
        {
            StopCoroutine(curCoroutine);
        }

        curCoroutine = StartCoroutine(newCoroutine);
        return curCoroutine;
    }

    public void Initialize(UIDocument _dialogueTemplate)
    {
        actionAfter = null;
        dialogueTemplate = _dialogueTemplate;
        root = dialogueTemplate.rootVisualElement;
        charName = root.Q<Label>("CharName");
        message = root.Q<Label>("Message");
        charAvatar = root.Q<VisualElement>("CharAvatar");

        root.RegisterCallback((ClickEvent evt) => 
        {
            // CAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAK
            // AAAAAAAAAAAAAAAAAAAAAAAAAAAA3333333333333333333333333333333333333333
            // AAAAAAAA33333333333333 6 HOURS DEBUGGING AAAAAAAAAAA3333333333333333
            // AAAAAAAAAAAAAAAAAAAAAAAAAAAA3333333333333333333333333333333333333333
            // CAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAK

            if (headDialogue.NxtItem != null)
            {
                if (headDialogue.NxtItem is Dialogue) 
                {
                    headDialogue = headDialogue.NxtItem as Dialogue;  
                    StopAndStartCoroutine(BindDialogue());
                }
                else if (headDialogue.NxtItem is Question)
                {
                    root.style.display = DisplayStyle.None;
                    ChoicesManager.ShowChoices((Question)headDialogue.NxtItem);
                    headDialogue = null;
                }
            }
            else
            {
                root.style.display = DisplayStyle.None;
                if (actionAfter != null)
                {
                    actionAfter.Invoke();
                }
            }
        });

        root.style.display = DisplayStyle.None;
    }

    private IEnumerator AssignLabelText(Label label, string newText)
    {
        label.text = "";
        foreach (char c in newText)
        {
            label.text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private IEnumerator BindDialogue()
    {
        Dialogue dialogue = headDialogue;
        message.text = "";

        charAvatar.style.backgroundImage = new StyleBackground(dialogue.CharAvatar);
        yield return StopAndStartCoroutine(AssignLabelText(charName, dialogue.CharName));
        yield return StopAndStartCoroutine(AssignLabelText(message, dialogue.Message));
    }

    public void ShowDialogue(Dialogue _headDialogue) 
    {
        this.actionAfter = null;
        ShowDialogue(_headDialogue, actionAfter);
    }

    public void ShowDialogue(Dialogue _headDialogue, UnityAction _actoinAfter)
    {
        this.headDialogue = _headDialogue;
        this.actionAfter = _actoinAfter;

        root.style.display = DisplayStyle.Flex;
        StopAndStartCoroutine(BindDialogue());
    }
}
