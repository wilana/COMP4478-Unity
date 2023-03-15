using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	// Variables
	public Vector2 speed = new Vector2(5, 5);
	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;

	// Start is called before the first frame update
	void Start()
	{
		// get the rigid body component
		rigidbodyComponent = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void Update()
	{

	}

	void FixedUpdate()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		movement = new Vector2(speed.x * inputX, speed.y * inputY);
		//move the game object
		rigidbodyComponent.velocity = movement;
	}
}
