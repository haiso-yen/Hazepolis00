using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class CharacterController2D : MonoBehaviour
{

	public GameObject[] MainPlayer;
	private GameObject currentPlayer, previousPlayer;
	public bool foundDan = false; 

	[SerializeField] private int iCharcaterCount = 0;
	public Camera cam;
	public LayerMask mask;

	void Update()
	{
		ChangeCharacter();
		MagicDetect();
	}
	void CheckMeet()
    {
		currentPlayer = MainPlayer[0];
		if (Eammon.instance.scenePassWord == "Level0-1")
		{
			foundDan = true;
		}
	}
	void ChangeCharacter()
	{
		if (foundDan == false)
		{
			CheckMeet();
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.F))
			{
				iCharcaterCount++;
				if (iCharcaterCount >= MainPlayer.Length)
				{
					iCharcaterCount = 0;
				}
				previousPlayer = currentPlayer;
				currentPlayer = null;
			}
		}

		switch (iCharcaterCount)
		{
			case 0: //Eammmon
				{
					if (currentPlayer == null) { currentPlayer = MainPlayer[0]; Debug.Log(currentPlayer.name); }
					currentPlayer.gameObject.SendMessage("Activate");
					if(previousPlayer != null)previousPlayer.gameObject.SendMessage("Deactivate");
                }
				break;
			case 1: //Dan
				{
					if (currentPlayer == null) { currentPlayer = MainPlayer[1]; Debug.Log(currentPlayer.name); }
                    currentPlayer.gameObject.SendMessage("Activate");
                    previousPlayer.gameObject.SendMessage("Deactivate");
				}
				break;
			default:
				break;
		}
	}

	void MagicDetect()
	{
        Vector3 mousePos = Input.mousePosition;
		mousePos.z = -1.35f;
		
		Vector3 objectPos = cam.WorldToScreenPoint(transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

		RaycastHit2D objHit = Physics2D.Raycast(transform.position, transform.right, 10, 1 << LayerMask.NameToLayer("Interactive"));
		Debug.DrawRay(transform.position, transform.right * 10, Color.red);

		if (Input.GetKey(KeyCode.E) && objHit.collider != null)
        {
			String activeObj = objHit.transform.name;
			Debug.DrawRay(transform.position, transform.right * 10, Color.red);

			if(iCharcaterCount == 0)
            {
				//TimeControl
				if (Input.mouseScrollDelta.y != 0)
				{
					currentPlayer.gameObject.SendMessage("MagicTimeReverseSpeedUp");
					float mouseScr = Input.mouseScrollDelta.y;
					Debug.Log(activeObj);
					GameObject.Find(activeObj).SendMessage("ControlTime", mouseScr);
				}
				//TimePause
				if (Input.GetMouseButtonDown(1))
				{
					currentPlayer.gameObject.SendMessage("MagicTimeStop");
					GameObject.Find(activeObj).SendMessage("PauseTime");
				}
			}

			if(iCharcaterCount == 1)
            {
				if (Input.GetMouseButtonDown(0))
				{
					currentPlayer.gameObject.SendMessage("Magic");
					//GameObject.Find(activeObj).SendMessage("ObjectDrag");
				}
				if (Input.GetMouseButton(0))
				{
					GameObject.Find(activeObj).SendMessage("ObjectDrag");
				}
			}	
		}	
	}
}


