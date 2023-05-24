using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class toggleGuide : MonoBehaviour
{
    public InputActionReference hand;

    public GameObject guideObjectFront;

    public GameObject guideObjectBack;

    public GameObject guideObjectFrontSafe;

    public GameObject infoObject;

    public GameObject infoObjectClicked;

    private bool guideVisible = false;

    private bool guidePressed = false;

    // Start is called before the first frame update
    void Start()
    {
        guideObjectFront.SetActive(false);
        guideObjectBack.SetActive(false);
        guideObjectFrontSafe.SetActive(false);

        infoObject.SetActive(true);
        infoObjectClicked.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        float value = hand.action.ReadValue<float>();

        if (value == 1 && !guidePressed)
        {
          

            guidePressed = true;
            if (!guideVisible)
            {
                guideVisible = true;
                infoObject.SetActive(false);
                infoObjectClicked.SetActive(true);
                if (SceneManager.GetActiveScene().name.Equals("ClassRoom"))
                {
                    guideObjectFront.SetActive(true);
                } else
                {
                    guideObjectFrontSafe.SetActive(true);
                }
               
                guideObjectBack.SetActive(true);
            } else
            {
                guideVisible = false;
                infoObject.SetActive(true);
                infoObjectClicked.SetActive(false);
                guideObjectFront.SetActive(false);
                guideObjectFrontSafe.SetActive(false);
                guideObjectBack.SetActive(false);
            }

        } else if (guidePressed && value == 0)
        {
            guidePressed = false;
            
        } 
    }
}
