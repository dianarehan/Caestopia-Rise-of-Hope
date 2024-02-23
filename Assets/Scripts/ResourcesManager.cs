using System.Collections;
using System.Collections.Generic;
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

    public static int Happiness {  get { return happiness; } }
    public static int Money { get { return money; } }
    public static int Population { get { return population; } }

    public static void Initialize()
    {
        happiness = 50; money = 200; population = 80;
        resourcesUI = GameObject.Find("Resources Manager").GetComponent<UIDocument>();
        SetVisualElement();
        UpdateVisualEmelent();
    }

    public static void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        UpdateVisualEmelent();
    }
    public static void AddHappiness(int happinessToAdd)
    {
        happiness += happinessToAdd;
        UpdateVisualEmelent();
    }
    public static void AddPopulation(int populationToAdd)
    {
        population += populationToAdd;
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
