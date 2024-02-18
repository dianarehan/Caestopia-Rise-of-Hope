using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Initializer : MonoBehaviour
{
    [SerializeField] private UIDocument DialogueUI;

    void Awake()
    {
        DialogueManager.Initialize(DialogueUI);
    }
}
