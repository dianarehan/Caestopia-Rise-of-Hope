using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
    private string charName;
    private string message;
    private Sprite charAvatar;

    public string CharName {  get { return charName; } }
    public string Message { get { return message; } }
    public Sprite CharAvatar { get {  return charAvatar; } }

    public Dialogue(string charName, string message, Sprite charAvatar)
    {
        this.charName = charName;
        this.message = message;
        this.charAvatar = charAvatar;
    }
}
