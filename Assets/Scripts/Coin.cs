using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	float spinSpeed;
	public GameObject coin;
	public MeshRenderer mr;
	float ttl;
	public bool carLoadingScreen;

	// Use this for initialization
	void Start () 
	{
		mr = GetComponent<MeshRenderer> ();
		spinSpeed = 125f;
		coin = gameObject;
		ttl = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		SpinCoin ();
		if (!mr.enabled) 
		{
			ttl -= Time.deltaTime;
			if (ttl <= 0)
				mr.enabled = true;
		}
	}

	void SpinCoin()
	{
		if(carLoadingScreen)
			coin.transform.Rotate (new Vector3 (-1 * spinSpeed * Time.deltaTime, 0, 0));
		else
			coin.transform.Rotate (new Vector3 (0, spinSpeed * Time.deltaTime, 0));
	}

	public void CollectCoin(PlayerMovement pm)
	{
		if (mr.enabled) 
		{
			pm.coins++;
			mr.enabled = false;
			ttl = 5f;
		}
	}
}
