using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V1CamController : MonoBehaviour
{

    public static V1CamController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
