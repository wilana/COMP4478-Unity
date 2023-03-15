using TMPro;
using UnityEngine;

public class CatchItemScript : MonoBehaviour
{
	public int Score;
	public TMP_Text ScoreText;
	public GameObject FishSpawnGameObject;
	public GameObject BombSpawnGameObject;

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Collision Detected!");

		// destroy the fish or bomb
		Destroy(other.gameObject);

		// fish was caught
		if (other.gameObject.tag == "Fish")
		{
			Score++;
			ScoreText.text = Score.ToString();
		}
		// Bomb was caught
		else
		{
			this.gameObject.SetActive(false);
			Time.timeScale = 0f;
			ScoreText.text = Score.ToString() + "\nGAME OVER!";
		}
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
