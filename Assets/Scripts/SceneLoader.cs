using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadScence()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        ScoreUI._score = 0;
        Platform._moveSpeed = 5;
    }
    public void MenuExid()
    {
        SceneManager.LoadScene(0);
        ScoreUI._score = 0;
    }
}
