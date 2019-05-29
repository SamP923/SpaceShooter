using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	// Use this for initialization
	public UIManager uiManagerScript;

	void Start () {
		//float randomX = Random.Range(-13f,13f);
		//transform.position = new Vector3(randomX,10f,0);
		uiManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * Time.deltaTime * 3);

		if (uiManagerScript.titleScreen.activeInHierarchy == true) {
			Destroy (gameObject);
		}
		if(transform.position.y < -7){
			Destroy(gameObject);
		}

	}
}
