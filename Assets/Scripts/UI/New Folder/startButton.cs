using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    public void onClick_Play() 
    {
        Debug.Log("���U'�}�l'���s");
        SceneManager.LoadScene("DemoHouse");
    }

}
