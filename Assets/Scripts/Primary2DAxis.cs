using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Primary2DAxis : MonoBehaviour
{
    public InputActionReference colorReference = null;

    public MeshRenderer meshrenderer = null;

    // Start is called before the first frame update
    private void Awake()
    {
        meshrenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        float value = colorReference.action.ReadValue<float>();
        UpdateColor(value);
    }

    private void UpdateColor(float value)
    {
        meshrenderer.material.color = new Color(value, value, value);
    }
}