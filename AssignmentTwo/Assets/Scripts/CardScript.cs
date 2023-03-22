using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CardScript : MonoBehaviour, IPointerClickHandler
{
	public Image card;

	public GameObject gameController;
	// Variables
	public Sprite animal;
	public Sprite back;

	public bool frontUp;
	public bool matched;


	public void Start()
	{
		card = gameObject.GetComponent<Image>();
		gameController = GameObject.Find("GameControl");

		frontUp = false;

		matched = false;
	}



	public void FlipCard()
	{
		// if the back is showing, flip to front
		if (!frontUp)
		{
			card.sprite = animal;
			gameController.GetComponent<GameControlScript>().cardsFlipped.Add(card);
			frontUp = true;
		}
		else
		{
			//the front is showing so flip back over
			card.sprite = back;
			gameController.GetComponent<GameControlScript>().cardsFlipped.Remove(card);
			frontUp = false;
		}

		Debug.Log("UPDATE: there are " + gameController.GetComponent<GameControlScript>().cardsFlipped.Count + " flipped cards");
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (matched) return;
		if (frontUp || gameController.GetComponent<GameControlScript>().cardsFlipped.Count < 2)
		{
			FlipCard();
		}
	}
}
