using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinningCoinCounter : MonoBehaviour
{    
   Text coinText;
   public static int spinningCoinsAmount;

    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Real coins: " + spinningCoinsAmount.ToString();
    }
}