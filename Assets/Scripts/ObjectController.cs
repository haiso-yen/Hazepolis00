using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectController : MonoBehaviour
{
    private Animator animator;
    //private float magicState;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("speed", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ControlTime(float timer)
    {
        float Pretimer = 0;

        if (timer > 0 && Pretimer!=1)
        {
            animator.SetFloat("speed", 1);
            Pretimer = 1;
        }

        if (timer < 0 && Pretimer != -1)
        {
            animator.SetFloat("speed", -1);
            Pretimer = -1;
        }
        //Debug.Log("ControlTime" + timer);
        //animator.SetFloat("speed", timer);
        //magicState = timer;
    }
    public void PauseTime()
    {
        Debug.Log("PauseTime");
        animator.SetFloat("speed", 0);
        //magicState = 0;
    }

    public void ObjectDrag()
    {
        Debug.Log("ObjectDrag");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        objPosition.z = gameObject.transform.position.z;
        objPosition.x = gameObject.transform.position.x;
        transform.position = objPosition; 
    }
}
