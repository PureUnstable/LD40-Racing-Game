using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public PlayerMovement pm1, pm2;
	float backupDir = 1;
	bool canTurn;

	// Use this for initialization
	void Awake () 
	{
		canTurn = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Player 1 Controls WASD
		if (Input.GetButton ("P1Forward")) 
		{
			pm1.MovePlayer (-1);
			backupDir = 1;
		} 
		if (Input.GetButton ("P1Backward")) 
		{
			pm1.MovePlayer (0.75f);
			backupDir = -0.75f;
		}
		if (Input.GetButton ("P1Left")) 
		{
			if(canTurn)
				pm1.TurnPlayer (-1*backupDir);
		}
		if (Input.GetButton ("P1Right")) 
		{
			if(canTurn)
				pm1.TurnPlayer (1*backupDir);
		}
		if(Input.GetButtonDown("P1Reset"))
		{
			pm1.car.transform.position = new Vector3 (-1.9f, -2.04f, -51.4f);
		}

		// Player 2 Controls Arrow Keys
		if (Input.GetButton ("P2Forward")) 
		{
			pm2.MovePlayer (1);
		} 
		else if (Input.GetButton ("P2Backward")) 
		{
			pm2.MovePlayer (-0.25f);
		}
		/*if (Input.GetButton ("P2Left")) 
		{

		}
		else if (Input.GetButton ("P2Right")) 
		{

		}*/
	}

	public void CanTurn(bool turn)
	{
		canTurn = turn;
	}
}
