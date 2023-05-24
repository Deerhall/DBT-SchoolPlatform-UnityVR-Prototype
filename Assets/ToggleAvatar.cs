using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ToggleAvatar : MonoBehaviour
{
    public InputActionReference AvatarToggle = null;
    public InputActionReference xAxis = null;

    private bool isAvatarVisible = true;
    private bool clicked = false;

    public RawImage myRawImage;

    public GameObject on;
    public GameObject off;

    public GameObject position;

    private float time = 0f;

    // Start is called before the first frame update
    private void Awake()
    {
        myRawImage.enabled = false;
        on.SetActive(false);
        off.SetActive(false);
    }

    private void Update()
    {
        float value = AvatarToggle.action.ReadValue<float>();
        float valueX = xAxis.action.ReadValue<float>();

    

        

        if (valueX > 0 && value == 1 && !clicked)
        {
            clicked = true;
            if (isAvatarVisible)
            {
                isAvatarVisible = !isAvatarVisible;
                myRawImage.enabled = true;
                Debug.Log("Avatar på");
                ShowNotification(true, 0);
                time = 0f;
            } else
            {
                isAvatarVisible = !isAvatarVisible;
                myRawImage.enabled = false;
                Debug.Log("Avatar av");
                ShowNotification(true, 1);
                time = 0f;
            }
            
        } else if (value == 0)
        {
            time += Time.deltaTime;
            if (time >= 3f)
            {
                clicked = false;
                ShowNotification(false, 0);
            }
            
        }
    }

    private async void ShowNotification (bool show, int on_off)
    {
        if (show)
        {
            if (on_off == 0)
            {
                on.SetActive(true);

                on.transform.position = position.transform.position;
                on.transform.rotation = position.transform.rotation;
            } else
            {
                off.SetActive(true);

                off.transform.position = position.transform.position;
                off.transform.rotation = position.transform.rotation;
            }
        } else
        {
            on.SetActive(false);
            off.SetActive(false);
        }
    }
}
