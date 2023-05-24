using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ToggleMic : MonoBehaviour
{
    public InputActionReference micRefrence = null;
    public RawImage myRawImage;
    public RawImage teacher;
    public float speed = 50f;

    private bool startAnimation;

    public GameObject on;
    public GameObject position;
    private bool alertOn;
    // Start is called before the first frame update
    private void Awake()
    {
        myRawImage.enabled = false;
        startAnimation = false;
        on.SetActive(true);
        alertOn = false;
    }

    private void Update()
    {
        float value = micRefrence.action.ReadValue<float>();
        //if (startAnimation)
        //{
        //    AnimateTeacher();
        //}
        if (value > 0)
        {
            Debug.Log("Mikrofon på");
            myRawImage.enabled = true;
            if (!alertOn) {
                ShowNotification(true, 0);
                alertOn = true;
            }
            startAnimation = true;
            
        } else
        {
            Debug.Log("mikrofon av");
            ShowNotification(false,0);
            alertOn = false;
            myRawImage.enabled = false;
        }
    }

    private void AnimateTeacher ()
    { 
        // Update the RectTransform after making changes
        if (teacher.rectTransform.anchoredPosition.x < -550)
        {
            teacher.rectTransform.anchoredPosition += new Vector2(speed * Time.deltaTime, 0f);
            teacher.rectTransform.ForceUpdateRectTransforms();
        }
    }

    private async void ShowNotification(bool show, int on_off)
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        Quaternion cameraRotation = Camera.main.transform.rotation;

        if (show)
        {
            if (on_off == 0)
            {
                on.SetActive(true);

                on.transform.position = position.transform.position;
                on.transform.rotation = position.transform.rotation;
            }
        
        }
        else
        {
            on.SetActive(false);
        }
    }
}