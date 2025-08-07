using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour

{
    private static MusicManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this object alive between scenes
        }
        else
        {
            Destroy(gameObject); // Destroys duplicate MusicManager
        }
    }
}


