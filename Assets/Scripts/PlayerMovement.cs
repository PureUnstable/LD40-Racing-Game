using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	float initialSpeed, speedMult;
	public int coins, heldCoins;
	public GameObject car;
	public Controller c;
	Rigidbody carRB;
	int checkpointsReached;
	public int lap;
	public GUIHelper gh;
	float lap1Time, lap2Time, lap3Time;
	public float score;
	Vector3 startPos;

	void Awake()
	{
		
	}

	// Use this for initialization
	void Start () 
	{
		score = 0f;
		lap = 0;
		checkpointsReached = 0;
		initialSpeed = 1f;
		speedMult = 1.75f;
		coins = 0;
		heldCoins = 0;
		carRB = car.GetComponent<Rigidbody>();
		startPos = Menus.menus.GetStartingPosition ();
		transform.position = startPos;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void ResetCar()
	{
		transform.position = startPos;
	}

	float SpeedMultiplier()
	{
		return Mathf.Pow (speedMult, (heldCoins + coins)*0.25f);
	}

	public void MovePlayer(float dir)
	{
		carRB.AddRelativeForce (250*dir*SpeedMultiplier(),0,0);
	}

	public void TurnPlayer(float dir)
	{
		carRB.AddRelativeTorque (new Vector3(0, 60*dir, 0));
		carRB.AddRelativeForce (0,0,100*dir*SpeedMultiplier());
	}

	public void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Coin") 
		{
			col.GetComponent<Coin>().CollectCoin(this);
		}
		if (col.gameObject.tag == "Checkpoint1" && checkpointsReached == 0) 
		{
			checkpointsReached++;
			Debug.Log ("Checkpoint " + checkpointsReached);
		}
		if (col.gameObject.tag == "Checkpoint2" && checkpointsReached == 1)
		{
			checkpointsReached++;
			Debug.Log ("Checkpoint " + checkpointsReached);
		}
		if (col.gameObject.tag == "Checkpoint3" && checkpointsReached == 2)
		{
			checkpointsReached++;
			Debug.Log ("Checkpoint " + checkpointsReached);
		}
		if (col.gameObject.tag == "FinishLine") 
		{
			if (lap == 0) 
			{
				if (checkpointsReached == 0) {
					Debug.Log ("Start!");
					gh.StartRace ();
				} 
				else if (checkpointsReached == 3) 
				{
					heldCoins += coins;
					score += coins * 1000;
					coins = 0;
					checkpointsReached = 0;
					lap++;
					Debug.Log ("Lap " + lap);
				}
			}
			else if (checkpointsReached == 3) 
			{
				heldCoins += coins;
				score += coins * 1000;
				coins = 0;
				checkpointsReached = 0;
				lap++;
				Debug.Log ("Lap " + lap);

			}
		}
	}

	public void OnCollisionEnter(Collision col)
	{
		Debug.Log ("Collision with " + col.gameObject.ToString() + " Tag: " + col.gameObject.tag);
		if (col.gameObject.tag == "Obstacle") 
		{
			// PLAYER EXPLODES
			/*for (int i = 0; i < coins; i++) 
			{

			}*/
			coins = 0;
		}
		if (col.gameObject.tag == "Ground")
			c.CanTurn (true);
		if (col.gameObject.tag == "Airborne")
			c.CanTurn (false);
	}

	public void OnClickMainMenu()
	{
		SceneManager.UnloadSceneAsync (1);
		SceneManager.LoadScene (0);
	}
}
