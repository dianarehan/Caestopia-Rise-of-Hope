using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChoices : MonoBehaviour
{
    private void Start()
    {
        List<Choice> choices = new List<Choice> { new Choice("test1", test1), new Choice("test2", test2) };

         ChoicesManager.ShowChoices("How is the test?",choices);
    }

    void test1 ()
    {
        Debug.Log("First Choice");
    }
    void test2()
    {
        Debug.Log("Second Choice");
    }
}
