using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private void OnEnable()
    {
        MainMenuScreen.scale += OnScaleChanged;
    }

    private void OnDisable()
    {
        MainMenuScreen.scale -= OnScaleChanged;
    }

    float targetScale;
    Vector3 scaleVal; 
    void OnScaleChanged(float newScale)
    {
        targetScale = newScale;
    }

    private void Update()
    {
        transform.localScale =
            Vector3.SmoothDamp(transform.localScale, targetScale
            * Vector3.one, ref scaleVal, 0.15f);
    }

}
