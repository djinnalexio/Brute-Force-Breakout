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

    void Update()
    {
        if (realCode.Length == 3)
        {
            foreach (GameObject i in arrows) { i.SetActive(true); }
            checkLight.SetActive(true);
        }
    }

    public void Enter0()
    { if (realCode.Length < 3) { realCode += '0'; displayCode.text = realCode; } }
    public void Enter1()
    { if (realCode.Length < 3) { realCode += '1'; displayCode.text = realCode; } }
    public void Enter2()
    { if (realCode.Length < 3) { realCode += '2'; displayCode.text = realCode; } }
    public void Enter3()
    { if (realCode.Length < 3) { realCode += '3'; displayCode.text = realCode; } }
    public void Enter4()
    { if (realCode.Length < 3) { realCode += '4'; displayCode.text = realCode; } }
    public void Enter5()
    { if (realCode.Length < 3) { realCode += '5'; displayCode.text = realCode; } }
    public void Enter6()
    { if (realCode.Length < 3) { realCode += '6'; displayCode.text = realCode; } }
    public void Enter7()
    { if (realCode.Length < 3) { realCode += '7'; displayCode.text = realCode; } }
    public void Enter8()
    { if (realCode.Length < 3) { realCode += '8'; displayCode.text = realCode; } }
    public void Enter9()
    { if (realCode.Length < 3) { realCode += '9'; displayCode.text = realCode; } }
}
