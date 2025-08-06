using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public Button backButton;

    public void backButtonPressed()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(backButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
