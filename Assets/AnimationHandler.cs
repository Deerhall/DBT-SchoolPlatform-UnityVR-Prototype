using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AnimationHandler : MonoBehaviour
{
    public InputActionReference micRefrence = null;
    public RawImage teacher;
    public float speed = 50f;

    public InputActionReference AvatarToggle = null;
    public InputActionReference xAxis = null;

    private bool isAvatarVisible = true;
    private bool clicked = false;

    public RawImage myRawImage;

    private bool startAnimation;
    // Start is called before the first frame update
    private void Awake()
    {
        myRawImage.enabled = false;
        startAnimation = false;
    }

    private void Update()
    {
        float value = AvatarToggle.action.ReadValue<float>();
        float valueX = xAxis.action.ReadValue<float>();

        if (startAnimation)
        {
            AnimateTeacher();
        }

        if (valueX < 0 && value == 1 && !clicked)
        {
            startAnimation = true;

        }
        else if (value == 0)
        {
            clicked = false;
        }
    }

    private void AnimateTeacher()
    {
        // Update the RectTransform after making changes
        if (teacher.rectTransform.anchoredPosition.x < -550)
        {
            teacher.rectTransform.anchoredPosition += new Vector2(speed * Time.deltaTime, 0f);
            teacher.rectTransform.ForceUpdateRectTransforms();
        }
    }
}