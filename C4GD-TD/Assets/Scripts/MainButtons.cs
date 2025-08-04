using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtons : MonoBehaviour
{
    private float speed = 1f;
    private void Start()
    {
        Time.timeScale = speed;
    }

    public void game_pause()
    {
        if(Time.timeScale == 0) 
            Time.timeScale = speed;
        else
            Time.timeScale = 0;
        
    }

    public void game_speed()
    {
        if (speed == 1) speed = 2;
        else speed = 1;
    }
}
