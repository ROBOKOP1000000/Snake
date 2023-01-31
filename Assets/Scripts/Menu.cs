using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayHangler()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitHangler()
    {
        Application.Quit();
    }
}
