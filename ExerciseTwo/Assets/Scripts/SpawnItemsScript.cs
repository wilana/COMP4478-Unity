using UnityEngine;

public class SpawnItemsScript : MonoBehaviour
{
	// variables
	public GameObject spawnItem;
	public float spawnTime = 1.0f;
	public float spawnDelay;

	public Vector2 screenBounds;

	// Start is called before the first frame update
	void Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
		// Start calling the method to spawn objects after spawnTime, with a spawnDelay time between
		InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SpawnObject()
	{
		Vector3 position = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2, 0);
		Instantiate(spawnItem, position, transform.rotation);
	}

}
