using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    void Awake()
    {
        List<GameObject> musicManagers = new List<GameObject> { };
        foreach (MusicManager i in FindObjectsOfType<MusicManager>()) { musicManagers.Add(i.gameObject); }

        if (musicManagers.Count > 1)
        {
            musicManagers.Remove(gameObject);
            foreach (GameObject i in musicManagers)// i am new, other is coming
            {
                if (GetComponent<AudioSource>().clip == i.GetComponent<AudioSource>().clip)//if they are the same, destroy the one being started
                {
                    gameObject.SetActive(false);
                    Destroy(gameObject);
                }
                else
                {
                    i.SetActive(false);//if they are not the same, then the old one isn't the right one so destroy it and set the new one
                    Destroy(i);
                    DontDestroyOnLoad(gameObject);
                }
            }
        }
        else DontDestroyOnLoad(gameObject);
    }
}
