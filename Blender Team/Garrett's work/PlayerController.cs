using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//Public variables
	public float walkspeed;

	//Private variables
	Rigidbody rb;
	Vector3 moveDirection;

	void Awake()
	{
	rb = GetComponent<Rigidbody>();
	}

// Use this for initialization
void Start () {

	}

	// Update is called once per frame
	void Update ()
	{
    //Get directional input from the user
		float horizontalMovement = Input.GetAxisRaw("Horizontal");
		float verticalMovement = Input.GetAxisRaw("Vertical");

	moveDirection =	(horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;
	}
	void FixedUpdate()
	{
		//Call the Move function
		Move();
	}
}
