using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public static class DialogueSequence
{
    private static List<UnityAction> dialogues = new List<UnityAction>();
    private static int currentDialoueIndex = 0;
    static Sprite sprite;
    public static void Initialize ()
    {
        
    }

    // Dialogue Functions 
    static void Dialogue1 ()
    {
        List<Dialogue> list = new List<Dialogue>()
        {
            new Dialogue("Royal counsler", "my lord, I’ll Help you rule the City" +
            " but you have to make some tough choices, do you understand?", sprite),
        };
        

    }
}
