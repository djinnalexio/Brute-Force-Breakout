using System.Collections;
using System.Collections.Generic;
using UnityEngine;//calls for resources from UnityEngine
using UnityEngine.SceneManagement;//calls for resources from UnityEngine SceneManagement

/// <summary>
/// Script that contains the methods that are linked to the buttons to navigate between scenes.
/// </summary>

public class SceneLoader : MonoBehaviour
{
    public void LoadStartScene()//creates method to move to the first scene
    {   SceneManager.LoadScene(0);//load scene with index 0
    }

    public void LoadNextScene()//creates method to move to the following scene
    {   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        //load scene whose index is higher by 1 (the next scene)
    }
    
    public void SkipNextScene()//creates method to skip a scene
    {   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        //load scene whose index is higher by 2 (the scene after the next scene)
    }

    public void GoToCredits()//creates method to move to scene of the credits
    {   SceneManager.LoadScene("Credits");//loads the scene called "Credits"
    }
    
    public void QuitGame()//creates method to end the application
    {   Application.Quit();//ends the application
    }
}
