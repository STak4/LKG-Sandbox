using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugView : MonoBehaviour
{
    private int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            LoadScene(currentSceneIndex + 1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LoadScene(currentSceneIndex - 1);
        }
    }

    private void LoadScene(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
            currentSceneIndex = sceneIndex;
        }
    }
}
