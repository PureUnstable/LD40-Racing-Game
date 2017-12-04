using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

	Scene currentScene;
	public static Menus menus;
	public List<GameObject> startMenuObjects;
	public List<GameObject> helpMenuObjects;
	public List<GameObject> levelSelectObjects;
	Vector3 startTTrack, startHourglass;
	Vector3 selectedTrack;

	void Awake() 
	{
		DontDestroyOnLoad (this.gameObject);
		if (menus != null)
			Destroy (this);
		else
			menus = this;
		currentScene = SceneManager.GetActiveScene ();
		startTTrack = new Vector3 (123.45f, 1.1f, 1.57f);
		startHourglass = new Vector3 (338.6f, 1.1f, -29.75f);
	}

	// Use this for initialization
	void Start () {
		if (currentScene.buildIndex == 0) {
			foreach (GameObject go in startMenuObjects) {
				go.SetActive (true);
			}
			foreach (GameObject go in helpMenuObjects) {
				go.SetActive (false);
			}
			foreach (GameObject go in levelSelectObjects) {
				go.SetActive (false);
			}
		} else if (currentScene.buildIndex == 1) {
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClickStartFromMain()
	{
		foreach (GameObject go in startMenuObjects) 
		{
			go.SetActive (false);
		}
		foreach (GameObject go in levelSelectObjects) 
		{
			go.SetActive (true);
		}
	}

	public void OnClickStartFromHelp()
	{
		foreach (GameObject go in helpMenuObjects) 
		{
			go.SetActive (false);
		}
		foreach (GameObject go in levelSelectObjects) 
		{
			go.SetActive (true);
		}
	}

	public void OnCLickHelp()
	{
		foreach (GameObject go in startMenuObjects) 
		{
			go.SetActive (false);
		}
		foreach (GameObject go in helpMenuObjects) 
		{
			go.SetActive (true);
		}
	}

	public void OnClickTrackT()
	{
		selectedTrack = startTTrack;
		AudioManager.instance.PlayClickEffect ();
		SceneManager.UnloadSceneAsync (0);
		SceneManager.LoadScene (1);
	}

	public void OnClickTrackHourglass()
	{
		selectedTrack = startHourglass;
		AudioManager.instance.PlayClickEffect ();
		SceneManager.UnloadSceneAsync (0);
		SceneManager.LoadScene (1);
	}

	public Vector3 GetStartingPosition()
	{
		return selectedTrack;
	}

	public void OnClickQuit()
	{
		Application.Quit ();
	}
}
