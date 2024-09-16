using System.Collections;
using System.Collections.Generic;
using AnnulusGames.SceneSystem;
using UnityEngine;

public class StartupEntryPoint : MonoBehaviour
{
    private SceneController _scene = null;
    // Start is called before the first frame update
    async void Start()
    {
        _scene = FindObjectOfType<SceneController>();
        await _scene.PushScene("fall");
    }
}
