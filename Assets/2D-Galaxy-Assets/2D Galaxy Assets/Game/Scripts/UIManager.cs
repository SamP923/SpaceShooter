using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public Sprite[] lifeImages;

	public Image imageDisplay;

	public int score = 0;

	public Text scoreText;

	public GameObject titleScreen;


	public void UpdateLives(int lives){

		imageDisplay.sprite = lifeImages[lives];

	}

	public void UpdateScore(){
		score += 1;//score = score + 1;
		scoreText.text = "score: " + score;
	}

	public void ShowTitle(){
		titleScreen.SetActive(true);
	}

	public void HideTitle(){
		titleScreen.SetActive(false);
	}
}