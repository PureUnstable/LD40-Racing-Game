using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIHelper : MonoBehaviour {

	public PlayerMovement pm;
	public Text scoreText;
	public float time, maxTime;
	bool racing;
	int minutes, seconds;
	public TextMeshProUGUI textMesh;

	// Use this for initialization
	void Start () {
		racing = false;
		time = 0;
		maxTime = 120f;
	}
	
	// Update is called once per frame
	void Update () {
		if (racing) 
		{
			maxTime -= Time.deltaTime;
			TimeHelper ();
			if (maxTime <= 0) 
			{
				StopTime ();
			}
		}
	}

	void OnGUI()
	{
		scoreText.text = "Coins: " + pm.coins + "\nScore:" + pm.score + "\nTime: " + minutes.ToString() + ":" + seconds.ToString() + "\nLaps: " + pm.lap;
	}

	public void StartRace()
	{
		racing = true;
	}

	public float GetLapTime()
	{
		float lapTime = time;
		time = 0f;
		return lapTime;
	}

	public void StopTime()
	{
		racing = false;
		textMesh.text = "Out of Time!\nYour score: " + pm.score;
		textMesh.gameObject.SetActive (true);

	}

	void TimeHelper()
	{
		float timeLeft = maxTime;
		minutes = Mathf.FloorToInt (timeLeft/60f);
		seconds = Mathf.FloorToInt (timeLeft - (minutes * 60f));
	}
}
