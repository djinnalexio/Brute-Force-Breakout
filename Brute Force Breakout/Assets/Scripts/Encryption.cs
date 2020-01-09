using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Encryption : MonoBehaviour
{
    [SerializeField] Text displayCode;
    public static string realCode;
    [SerializeField] GameObject[] arrows;
    [SerializeField] GameObject checkLight;
    
    // Start is called before the first frame update
    void Start() { SetupKeypad(); }

    void SetupKeypad()
    {
        displayCode.text = "___";
        realCode = "";
        foreach (GameObject i in arrows) { i.SetActive(false); }
        checkLight.SetActive(false);
    }

    public void Enter(int i)
    { 
        if (realCode.Length < 3) 
        {
            realCode += i.ToString();
            displayCode.text = realCode;
        }

        if (realCode.Length >= 3)
        {
            foreach (GameObject j in arrows) { j.SetActive(true); }
            checkLight.SetActive(true);
        }
    }
}
