using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPlayer : MonoBehaviour
{
    public GameObject petObeject;
    public List<Vector3> positionList;
    public int distance = 20;
    private Vector3 previousPosition, currentPosition;

    void FixedUpdate()
    {
        currentPosition = transform.position;
        if (previousPosition != currentPosition)
        {
            positionList.Add(transform.position); 
            previousPosition = currentPosition;
        }
        if (positionList.Count > distance)
        {
            positionList.RemoveAt(0);
            petObeject.transform.position = positionList[0];
            PetMovement();
        }   
    }
    public void PetMovement()
    {
        if(Vector3.Distance(positionList[0], positionList[1]) > 0)
        {
            petObeject.SendMessage("Move");
        }
    }
}
