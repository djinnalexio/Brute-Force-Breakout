using System.Collections;
using System.Collections.Generic;
using UnityEngine;//calls for resources from UnityEngine
using UnityEngine.UI;//calls for resources from UnityEngine UI
using TMPro;
using UnityEngine.SceneManagement;//calls for resources from UnityEngine SceneManagement

/// <summary>
/// Script that contains:
/// the logic to guess the number thought of by the user
/// the method to generate the random 12 first digits of the master passcode.
/// the methods that update the minimum and maximum values of the possible range
/// the method to move to another screen when a number of tries is reached
/// the method to convert the numerical value to a visible 3-digit entry
/// the method to display the number of tries left
/// </summary>

public class Decryption : MonoBehaviour
{
    [Header("Guess Range")]
    [SerializeField] int min;//creates integer used as the minimum that can be interacted with in the console
    [SerializeField] int max;//creates integer used as the maximum that can be interacted with in the console
    
    [Header("Code Display")]
    [Space(5)]
    [SerializeField] Text displayGuess;// text object that will display the current guess
    [SerializeField] Text masterCode;// text value that can be display in the UI

    [Header("Pad Display")]
    [Space(5)]
    [SerializeField] TextMeshProUGUI displayTry;// text object that will display the current number of tries left
    [SerializeField] Text errorMessage;// text object that will display error message if boundary is reached
    [SerializeField] GameObject correctButton;// button that gives access to the win scene
    
    int guess;// creates the integer used for calculations of the guess
    int triesLeft = 13; // creates the integer used for counting remaining attempts (+1 since the first guess is included)
    string realCode = Encryption.realCode;// get the code that was entered with the 'Encryption' script

    public void OnPressHigher()//creates the method that will be linked to the "HIGHER" button
    {
        min = guess + 1;//the min value of the range become the guess + 1
        //'+1' is so that the guess itself is no longer part of the possible values the guess could be equal to

        //in case 999 becomes the lowest possible value, so that the screen does not show '1000' or something like that:
        if (min > 999)//if the minimum value somehow becomes 999 or higher
        {
            min = 999;//minimum stays at 999
            errorMessage.text = ">>>ERROR: Upper boundary breached. invalid range entered.";//creates text object for error message
        }
        NextGuess();//generate the next guess
    }

    public void OnPressLower()//creates the method that will be linked to the "LOWER" button
    {
        max = guess - 1;//the max value of the range become the guess - 1
        //'-1' is so that the guess itself is no longer part of the possible values the guess could be equal to
        
		if (max < 0)//if the maximum value becomes lower than 1
        {
            errorMessage.text = ">>>ERROR: Lower boundary breached. invalid range entered.";//creates text object for error message
        }
        NextGuess();//generates the next guess
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateMasterPwd();
        NextGuess();//generate the first guess
        correctButton.SetActive(false);
    }

    void CreateMasterPwd()
    {// can't obtain a 12-digit number through Random.Range so I split it into to.
        int longCodeA = Random.Range(0, 1000000);//get a 6-digit number
        int longCodeB = Random.Range(0, 1000000);//using leading zeros ("D#") to fill missing digits if it happens
        masterCode.text = longCodeA.ToString("D6") + longCodeB.ToString("D6");//assign the two parts as one string to the text object
    }

    void NextGuess()
    {//creates a method that guesses a random number between the current maximum and minimun values
        if (triesLeft <= 0) { SceneManager.LoadScene("Breakout Ending"); } //if remaining attempts is zero, move to the "Breakout Ending"
        else //using 'else' so that you don't see the numbers updating if switching scenes
        {
            triesLeft--;
            displayTry.text = triesLeft.ToString();//converts integer to string, and use it as a text object
            guess = Random.Range(min, max);// picks a random number between min and max   //(min is inclusive, max is exclusive)
            displayGuess.text = guess.ToString("D3");//update the displayed guess and add leading zeros to keep it 3-digit
            if (displayGuess.text.ToString() == realCode) { correctButton.SetActive(true); }// if the guess is correct, display the button that leads to the win scene
        }
    }
}