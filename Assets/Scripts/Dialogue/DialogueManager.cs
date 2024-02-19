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

    private List<Dialogue> dialogueList;
    private int dialogueIndex;

    private string questionAfter;
    private List<Choice> choicesAfter;

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
                else if (actionAfter != null)
                {
                    actionAfter.Invoke();
                }
            }
            else
            {
                StopAndStartCoroutine(BindDialogue());
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
        Dialogue dialogue = dialogueList[dialogueIndex];
        message.text = "";

        charAvatar.style.backgroundImage = new StyleBackground(dialogue.CharAvatar);
        yield return StopAndStartCoroutine(AssignLabelText(charName, dialogue.CharName));
        yield return StopAndStartCoroutine(AssignLabelText(message, dialogue.Message));
    }

    public void ShowDialogue(List<Dialogue> _dialogueList) 
    {
        choicesAfter = null;
        questionAfter = null;
        actionAfter = null;

        dialogueList = _dialogueList;
        dialogueIndex = 0;
        root.style.display = DisplayStyle.Flex;
        StopAndStartCoroutine(BindDialogue());
    }

    public void ShowDialogue(List<Dialogue> _dialogueList, string _question,List<Choice> _choicesAfter)
    {
        ShowDialogue(_dialogueList);
        choicesAfter = _choicesAfter;
        questionAfter = _question;
    }

    public void ShowDialogue(List<Dialogue> _dialogueList, UnityAction _actionAfter)
    {
        ShowDialogue(_dialogueList);
        actionAfter = _actionAfter;
    }

}
