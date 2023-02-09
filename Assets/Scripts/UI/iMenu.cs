using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class iMenu : MonoBehaviour
{
    public iMenu iMenuButton;
    public static iMenu iMenuStatic;

    private void Start()
    {
        iMenu.iMenuStatic = iMenuButton;
        iMenu.iMenuStatic.gameObject.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void show()
    {
        iMenu.iMenuStatic.gameObject.SetActive(true);
    }




}