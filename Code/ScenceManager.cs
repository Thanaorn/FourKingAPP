using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void resetScene()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void close()
    {
        Application.Quit();
    }
 
}
