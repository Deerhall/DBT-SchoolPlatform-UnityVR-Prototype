using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleHelp : MonoBehaviour
{
    private bool isHandAboveHead = false;
    private float HandAboveHeadTime = 0f;

    public GameObject objectWithAnimation;

    public RawImage myRawImage;

    public Image animation;

    public InputActionReference gripReference = null;

    bool isPressed = false;

    public GameObject on;
    public GameObject off;

    public GameObject position;

    private float time = 0f;

    bool handIsUp;
    bool noty;

    // Start is called before the first frame update
    private void Awake()
    {
        //animator = objectWithAnimation.GetComponent<Animator>();
        myRawImage.enabled = false;
        objectWithAnimation.SetActive(false);
        on.SetActive(false);
        off.SetActive(false);
        handIsUp = false;
        noty = true;
    }

    void Update()
    {
        float lHand = InputTracking.GetLocalPosition(XRNode.LeftHand).y;
        float rHand = InputTracking.GetLocalPosition(XRNode.RightHand).y;
        float head = InputTracking.GetLocalPosition(XRNode.Head).y;

        float value = gripReference.action.ReadValue<float>();
        Debug.Log(value);
        if (lHand > head || rHand > head)
        {
            isHandAboveHead = true;
            HandAboveHeadTime += Time.deltaTime;
            if (HandAboveHeadTime >= 3f)
            {
                objectWithAnimation.SetActive(false);
                Debug.Log("Hand has been above the head for 3 seconds!");
                myRawImage.enabled = true;

                if (noty)
                {
                    ShowNotification(true, 0);
                    noty = false;
                    time = 0f;
                }

            } else if (!myRawImage.enabled && !isPressed) 
            {
                objectWithAnimation.SetActive(true);
                isPressed = true;
            }

        }
        else if (value > 0 && time == 0f)
        {
            myRawImage.enabled = false;
            if (noty)
            {
                ShowNotification(true, 1);
                handIsUp = true;
                time = 0f;
                noty = false;
            }
        } else if (HandAboveHeadTime >= 3f || handIsUp)
        {
            time += Time.deltaTime;
            if (time >= 3f)
            {
                ShowNotification(false, 0);
                HandAboveHeadTime = 0f;
                time = 0f;
                handIsUp = false;
                noty = true;
            }
        } else
        {
            isPressed = false;
            objectWithAnimation.SetActive(false);
            isHandAboveHead = false;
            
        }
    }

    private async void ShowNotification(bool show, int on_off)
    {
        if (show)
        {
            if (on_off == 0)
            {
                on.SetActive(true);

                on.transform.position = position.transform.position;
                on.transform.rotation = position.transform.rotation;
            }
            else
            {
                off.SetActive(true);

                off.transform.position = position.transform.position;
                off.transform.rotation = position.transform.rotation;
            }
        }
        else
        {
            on.SetActive(false);
            off.SetActive(false);
        }
    }


}