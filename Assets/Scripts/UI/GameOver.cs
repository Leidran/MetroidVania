using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject GameOverText;
    public static GameObject GameOverStatic;




    void Start()
    {

        GameOver.GameOverStatic = GameOverText;
        GameOver.GameOverStatic.gameObject.SetActive(false);

    }


    void Update()
    {

    }

    public static void show()
    {
        GameOver.GameOverStatic.gameObject.SetActive(true);
    }

    public void TReturn(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
