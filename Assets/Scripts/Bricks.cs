using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

	public GameObject brickParticle;
	public GameObject floatingTextPrefab;
	public int scoreValue = 10;

	void OnCollisionEnter (Collision other) {
		ShowFloatingText ();
		ScoreManager.score += scoreValue;
		Instantiate (brickParticle, transform.position, Quaternion.identity);
		GM.instance.DestroyBrick ();
		Destroy (gameObject);
	}

	void ShowFloatingText ()
	{
		var go = Instantiate (floatingTextPrefab, transform.position, Quaternion.identity, transform);
		go.GetComponent<TextMesh> ().text = scoreValue.ToString ();
	}
}
