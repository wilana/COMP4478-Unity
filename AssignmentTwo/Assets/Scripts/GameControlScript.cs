using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControlScript : MonoBehaviour
{
	// Card Generations variables
	public GameObject CardArea;

	public float xSpace;
	public float ySpace;

	public float firstX;
	public float firstY;

	public List<GameObject> cardList;

	// Card flip/match variables

	public List<Image> cardsFlipped;

	public int totalMatchesFound = 0;
	public int attempts = 0;

	public float flipWaitTime = 1.0f;


	// UI variables
	public TMP_Text AttemptTmpText;

	// Game Over Variables
	public GameObject GameOverPanel;
	public TMP_Text GameOverAttemptTmpText;


	// Start is called before the first frame update
	void Start()
	{
		GameOverPanel.SetActive(false);

		cardList.AddRange(cardList);

		cardList = cardList.OrderBy(i => Guid.NewGuid()).ToList();

		float x = firstX;
		float y = firstY;

		int n = 0;
		for (int row = 0; row < 4; row++)
		{
			for (int col = 0; col < 4; col++)
			{
				var newCard = Instantiate(cardList[n], new Vector3(x, y, 0), Quaternion.identity);
				newCard.transform.SetParent(CardArea.transform, false);

				x = x + xSpace;
				n++;
			}

			y = y + ySpace;
			x = firstX;
		}


	}

	void Update()
	{

		if (cardsFlipped.Count == 2)
		{

			StartCoroutine(CheckMatch());

			cardsFlipped.Clear();

		}

		if (totalMatchesFound == cardList.Count / 2)
		{
			// change this value so this loop doesn't keep running
			totalMatchesFound = 0;
			AttemptTmpText.text = "";
			GameOverPanel.SetActive(true);
			GameOverAttemptTmpText.text = attempts + " incorrect attempts";
		}

	}


	IEnumerator CheckMatch()
	{

		Image image1 = cardsFlipped[0];
		Image image2 = cardsFlipped[1];

		Debug.Log("Checking cards");

		if (image1.sprite == image2.sprite)
		{
			Debug.Log("Match Found!");
			totalMatchesFound++;

			image1.GetComponent<CardScript>().matched = true;
			image2.GetComponent<CardScript>().matched = true;

		}
		else
		{
			Debug.Log("Not a match...");

			yield return new WaitForSeconds(flipWaitTime);

			attempts++;
			AttemptTmpText.text = "Incorrect Attempts: " + attempts;

			image1.GetComponent<CardScript>().matched = false;
			image2.GetComponent<CardScript>().matched = false;
			image1.GetComponent<CardScript>().FlipCard();
			image2.GetComponent<CardScript>().FlipCard();

		}


	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}


}
