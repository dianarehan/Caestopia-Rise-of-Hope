using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChoicesUI : MonoBehaviour
{
    [SerializeField]
    private VisualTreeAsset choiceCard;
    private VisualElement root;
    private VisualElement choicesList;
    private Label question;
    

    // Start is called before the first frame update
    void Start()
    {
        SetVisualElement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetVisualElement()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        choicesList = root.Q<VisualElement>("ChoicesList");
        question = root.Q<Label>("Question");
    }

}
