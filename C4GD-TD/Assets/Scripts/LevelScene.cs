using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // <-- Required for Button

public class LevelScene : MonoBehaviour
{

    public Button Level1;
    public Button Level2;
    public Button Level3;

    public void Level1Pressed()
    {
        SceneManager.LoadScene("Battle1");
    }


    public void Level2Pressed()
    {
        SceneManager.LoadScene("Battle2");
    }



    public void Level3Pressed()
    {
        SceneManager.LoadScene("Battle3");
    }



    // Start is called before the first frame update
    void Start()
    {
        Level1.onClick.AddListener(Level1Pressed);
        Level2.onClick.AddListener(Level2Pressed);
        Level3.onClick.AddListener(Level3Pressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
