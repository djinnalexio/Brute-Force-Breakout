using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Encryption : MonoBehaviour
{
    [SerializeField] Text displayCode;// text object that will display the current code entered by the player
    public static string realCode;// the secret code entered by the player
    // declaring the variable as static so that it can remain event after the gameObject disappears with the scene
    [SerializeField] GameObject[] arrows;// the buttons that lead to the next scene
    [SerializeField] GameObject checkLight;// object that appears when 3 digits have been entered
    
    void Start() { SetupKeypad(); }

    void SetupKeypad()
    {
        displayCode.text = "___";// start with this
        realCode = "";// code starts as an empty string
        foreach (GameObject i in arrows) { i.SetActive(false); }//make arrows disappear
        checkLight.SetActive(false);//turn off the checklight
    }

    public void Enter(int i)// function used by the keypad buttons
    { 
        if (realCode.Length < 3) // if the player needs more digits
        {
            realCode += i.ToString();//add the corresponding digit from the button to the code
            displayCode.text = realCode;// update the code being displayed
        }

        if (realCode.Length >= 3) // if the player has 3 digits
        {// activate the buttons to the next level and the checklight
            foreach (GameObject j in arrows) { j.SetActive(true); }
            checkLight.SetActive(true);
        }
    }
}
