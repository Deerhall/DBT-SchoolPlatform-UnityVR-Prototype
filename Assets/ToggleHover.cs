using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ToggleHover : MonoBehaviour
{
    public InputActionReference Toggle = null;
    public InputActionReference xAxis = null;

    public GameObject p;
    public GameObject pct;
    public GameObject pcb;
    public GameObject pht;
    public GameObject phb;
    public GameObject pr;
    public GameObject pctr;
    public GameObject pcbr;
    public GameObject phtr;
    public GameObject phbr;

    private bool SceneChangeing = false;

    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        setFalse();
        time = 0f;
        if (SceneManager.GetActiveScene().name.Equals("ClassRoom"))
        {
            p.SetActive(true);
        } else
        {
            pr.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float value = Toggle.action.ReadValue<float>();
        float valueX = xAxis.action.ReadValue<float>();
        //Debug.Log(Mathf.Round(Time.time) % 2);

        if (valueX > 0 && value == 1)
        {
            setFalse();

            if (SceneManager.GetActiveScene().name.Equals("ClassRoom"))
            {
                pct.SetActive(true);
            }
            else
            {
                pctr.SetActive(true);
            }
        } else if (valueX > 0 && value != 1)
        {
            setFalse();

            if (SceneManager.GetActiveScene().name.Equals("ClassRoom"))
            {
                pht.SetActive(true);
            }
            else
            {
                phtr.SetActive(true);
            }
        } else if (valueX < 0 && value == 1)
        {
            setFalse();

            if (SceneManager.GetActiveScene().name.Equals("ClassRoom"))
            {
                pcb.SetActive(true);
            }
            else
            {
                pcbr.SetActive(true);
            }

            if (SceneManager.GetActiveScene().name.Equals("ClassRoom"))
            {
               
                time += Time.deltaTime;
                Debug.Log(time);
                if (time >= 2f && !SceneChangeing)
                {
                    time = 0f;
                    SceneChangeing = true;
                    int sceneIndex = 1 + (int)(Mathf.Round(Time.time) % 2);

                    Debug.Log("Index: " + sceneIndex);

                    SceneManager.LoadScene(sceneIndex);
                    
                }
                
               

            } else if (!SceneChangeing)
            {
                time += Time.deltaTime;
                if (time >= 2f)
                {
                    time = 0f;
                    SceneChangeing = true;
                    SceneManager.LoadScene(0);
                }
          
            }


        } else if (valueX < 0 && value != 1)
        {
            setFalse();

            if (SceneManager.GetActiveScene().name.Equals("ClassRoom"))
            {
                phb.SetActive(true);
            }
            else
            {
                phbr.SetActive(true);
            }
        } else
        {
            setFalse();
            time = 0f;
            if (SceneManager.GetActiveScene().name.Equals("ClassRoom"))
            {
                p.SetActive(true);
            }
            else
            {
                pr.SetActive(true);
            }
            SceneChangeing = false;
        }
    }

    private void setFalse ()
    {
        p.SetActive(false);
        pct.SetActive(false);
        pht.SetActive(false);
        phb.SetActive(false);
        pcb.SetActive(false);

        pr.SetActive(false);
        pctr.SetActive(false);
        phtr.SetActive(false);
        phbr.SetActive(false);
        pcbr.SetActive(false);
    }
}
