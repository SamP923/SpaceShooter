using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour {

	public bool gameOver = true;

	public GameObject playerPrefab;

	public UIManager uiManagerScript;

	public SpawnManager spawnManagerScript;

	void Start() {
		uiManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();
		uiManagerScript.ShowTitle();
		spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
	}

	// Update is called once per frame
	void Update()
	{
		if(gameOver==true){
			uiManagerScript.ShowTitle();
			spawnManagerScript.canSpawn = false;
			if(Input.GetKeyDown(KeyCode.Space)){
				Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
				uiManagerScript.HideTitle();
				gameOver = false;
				uiManagerScript.score = -1;
				uiManagerScript.UpdateScore();
				spawnManagerScript.StartSpawning();
			}
		}
		else{
			uiManagerScript.HideTitle();
		}
	}
}
