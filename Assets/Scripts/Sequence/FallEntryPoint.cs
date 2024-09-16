using System;
using System.Collections;
using System.Collections.Generic;
using LookingGlass;
using UnityEngine;

public class FallEntryPoint : MonoBehaviour
{
    [SerializeField] private LoadView loadView;
    
    private HologramCamera _camera;
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = FindObjectOfType<HologramCamera>();
        _camera.Events.OnViewRendered.AddListener(OnRendered);
    }

    private void OnDestroy()
    {
        _camera.Events.OnViewRendered.RemoveListener(OnRendered);
    }

    private void OnRendered(HologramCamera cam, int num)
    {
        loadView.Toggle(false);
    }
}
