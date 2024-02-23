using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ResourcesManager : MonoBehaviour
{
    private static int happiness;
    private static int money;
    private static int population;
    private static UIDocument resourcesUI;
    private static VisualElement root;
    private static Label happinessLabel;
    private static Label moneyLabel;
    private static Label populationLabel;
    AudioSource source;
    public AudioClip audioClip;
    public static Boolean flag = false;
    public static int Happiness {  get { return happiness; } }
    public static int Money { get { return money; } }
    public static int Population { get { return population; } }

    private void Start()
    {

        source= gameObject.AddComponent<AudioSource>();
    }
    private void Update()
    {
        if (flag)
        {
            music();
        }
        flag = false;
    }
    public static void Initialize()
    {
        happiness = 50; money = 50; population = 50;
        resourcesUI = GameObject.Find("Resources Manager").GetComponent<UIDocument>();
        SetVisualElement();
        UpdateVisualEmelent();
    }
    public void music()
    {
        source.PlayOneShot(audioClip);
    }
    public static void AddMoney(int moneyToAdd)
    {
        ResourcesManager.flag = true;
        money += moneyToAdd;
        
        UpdateVisualEmelent();
    }
    public static void AddHappiness(int happinessToAdd)
    {
        ResourcesManager.flag = true;
        happiness += happinessToAdd;
        UpdateVisualEmelent();
    }
    public static void AddPopulation(int populationToAdd)
    {
        population += populationToAdd;
        ResourcesManager.flag = true;
        UpdateVisualEmelent();
    }

    private static void UpdateVisualEmelent()
    {
        happinessLabel.text = happiness.ToString();
        moneyLabel.text = money.ToString();
        populationLabel.text = population.ToString();
    }

    private static void SetVisualElement()
    {
        root = resourcesUI.rootVisualElement;
        happinessLabel = root.Q<Label>("Happiness");
        moneyLabel = root.Q<Label>("Money");
        populationLabel = root.Q<Label>("Loyality");
    }
}
