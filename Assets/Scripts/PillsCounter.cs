using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillsCounter : MonoBehaviour
{
    Text pillText;
    
    public static int pillsAmount;

    // Start is called before the first frame update
    void Start()
    {
        pillText = GetComponent<Text>();        
    }

    // Update is called once per frame
    void Update()
    {
        pillText.text = "Pills: " + pillsAmount;  
        if (pillsAmount == 3)
        {
            pillText.color = Color.red;
        }
        else
            pillText.color = Color.white;
    }
}
