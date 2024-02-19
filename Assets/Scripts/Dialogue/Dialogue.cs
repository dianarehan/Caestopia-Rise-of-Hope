using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dialogue : ScenarioBaseClass
{
    private string charName;
    private string message;
    private Sprite charAvatar;
    private ScenarioBaseClass nxtItem;

    public string CharName {  get { return charName; } }
    public string Message { get { return message; } }
    public Sprite CharAvatar { get {  return charAvatar; } }
    public ScenarioBaseClass NxtItem { get { return nxtItem; } }

    public Dialogue(string charName, string message, Sprite charAvatar)
    {
        this.charName = charName;
        this.message = message;
        this.charAvatar = charAvatar;
        nxtItem = null;
    }

    public Dialogue(string charName, string message, Sprite charAvatar, ScenarioBaseClass nxtItem)
    {
        this.charName = charName;
        this.message = message;
        this.charAvatar = charAvatar;
        this.nxtItem = nxtItem;
    }

    public void Connect(ScenarioBaseClass nxtItem)
    {
        this.nxtItem = nxtItem;
    }
}
