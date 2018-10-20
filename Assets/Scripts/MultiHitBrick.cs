using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiHitBrick : MonoBehaviour {

	public int hitsNeeded = 3;
	public GameObject floatingTextPrefab;
	public int scoreValue = 20;

	private int hitsTaken;

	public float colorChangeDelay = 0.5f;
	float currentDelay = 0f;
	bool colorChangeCollision = false;

	void OnCollisionEnter (Collision collisionInfo)
	{
		hitsTaken += 1;
		ShowFloatingText ();
		ScoreManager.score += scoreValue;
		Debug.Log ("Collision occurued, hitsTaken:" + hitsTaken);
		colorChangeCollision = true;
		currentDelay = Time.deltaTime + colorChangeDelay;

		if (hitsTaken >= hitsNeeded) {
			GM.instance.DestroyBrick (); 
			Destroy (gameObject);
		}
	}

	void checkColorChange()
	{
		if (colorChangeCollision) {
			transform.GetComponent<Renderer> ().material.color = Color.white;
			if (Time.time > currentDelay) {
				transform.GetComponent<Renderer> ().material.color = Color.blue;
			}
		}
	}

	void ShowFloatingText ()
	{
		var go = Instantiate (floatingTextPrefab, transform.position, Quaternion.identity, transform);
		go.GetComponent<TextMesh> ().text = scoreValue.ToString ();
	}

	void Update ()
	{
		checkColorChange ();
	}
}
