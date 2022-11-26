using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject DialogUI;
    public DialogTrigger trigger;



    //�a��NpC��ܹ�ܲŸ�
    private void OnTriggerEnter2D(Collider2D other)
    {
        Button.SetActive(true);
        DialogUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);
        DialogUI.SetActive(false);
    }

    void Update()
    {

        //��"T"���J���
        if (Input.GetKeyDown(KeyCode.T))
        {
            DialogUI.SetActive(true);
            trigger.StartDialog();
            Debug.Log("Conversation");
        }
    }
}
