using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ResourcesManager : MonoBehaviour
{
    private static int happiness;
    private static int money;

    private UIDocument resourcesUI;
    private VisualElement root;
    private Label happinessLabel;
    private Label moneyLabel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetVisualElement()
    {
        root = resourcesUI.rootVisualElement;
        happinessLabel = root.Q<Label>("Happiness");
        moneyLabel = root.Q<Label>("Money");
    }
}
