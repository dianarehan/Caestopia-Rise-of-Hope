using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionNote : Interaction
{
    [SerializeField]
    private string message;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private Note noteUi;

    public override void StartInteraction()
    {
        if (sprite == null)
            noteUi.ShowNote(message);
        else
            noteUi.ShowMessageWhithImg(sprite, message);
    }
}
