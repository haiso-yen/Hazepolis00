using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cam1, cam2;
    bool camChange = true;
    public bool foundDan = false;

    // Start is called before the first frame update
    void Start()
    {
        cam2.SetActive(false);
        cam1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (foundDan == false)
        {
            CheckMeet();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                camChange = !camChange;
            }
        }
        if (camChange)
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
        else
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
    }

    void CheckMeet()
    {
        if (Eammon.instance.scenePassWord == "Level0-1")
        {
            foundDan = true;
        }
    }
}
