using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadView : MonoBehaviour, IToggle
{
    private bool _isOn = false;

    private void Start()
    {
        Toggle(true);
    }

    public void Toggle()
    {
        Toggle(!_isOn);
    }

    public void Toggle(bool isOn)
    {
        gameObject.SetActive(isOn);
        _isOn = true;
    }
}
