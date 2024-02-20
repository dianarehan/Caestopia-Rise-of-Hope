using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testtt2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) 
        {
            ResourcesManager.AddMoney(20);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            ResourcesManager.AddHappiness(10);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ResourcesManager.AddLoyality(30);
        }
    }
}
