using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 5.0f;
	public bool hit = false;
	public GameObject EnemyExplosionPrefab;
	public UIManager uiManagerScript;
	public AudioSource explosionSound;

	// Use this for initialization
	void Start () {
		uiManagerScript = GameObject.Find ("Canvas").GetComponent<UIManager> ();
		explosionSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * speed * Time.deltaTime);

		if (uiManagerScript.titleScreen.activeInHierarchy == true) {
			Destroy (gameObject);
		}

		if(transform.position.y < -8f || hit){
			Instantiate (EnemyExplosionPrefab, transform.position + new Vector3 (0, 0.146f, 0), Quaternion.identity);
			MoveToRandom();
			hit = false;
		}
			
	}

	//The OnTriggerEnter2D method detects when the Enemy is hit by a Laser of TripleLaser
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.name.Contains("laser") || other.name.Equals("TripleLaser(Clone)")){
			explosionSound.Play ();
			hit = true;
			uiManagerScript.UpdateScore ();
		}
	}

	//This method takes care of the random movement of the Enemy when it is hit
	public void MoveToRandom(){
		float randomX = Random.Range(-13f,13f);
		transform.position = new Vector3(randomX, 9.0f, 0);
	}


}
