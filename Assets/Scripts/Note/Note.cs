using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UIElements;

public class Note : MonoBehaviour
{
    VisualElement root;
    VisualElement imge;
    Label text;
    void Start()
    {
        SetVisualElement();
    }

   void SetVisualElement()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        imge = root.Q<VisualElement>("Img");
        text = root.Q<Label>("Message");

        root.RegisterCallback((ClickEvent evnet) => {
            // Save in Invontory
            root.style.display = DisplayStyle.None;
        });

        root.style.display = DisplayStyle.None;

    }

    public void ShowMessageWhithImg(Sprite sprite, string text)
    {
        root.style.display = DisplayStyle.Flex;
        imge.style.backgroundImage = new StyleBackground(sprite);
        this.text.text = text;
    }

    public void ShowNote(string text)
    {
        root.style.display = DisplayStyle.Flex;
        this.text.text = text;
    }

}
