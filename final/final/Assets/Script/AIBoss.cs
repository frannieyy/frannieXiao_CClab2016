using UnityEngine;
using System.Collections;

public class AIBoss : MonoBehaviour {

	public float speed;

	public GameObject bullet;
	public float shoottimer;
	public float shootspeed;

	public bool isMoveLeft;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (transform.position.y > 1.6) {
			transform.position = new Vector2 (transform.position.x, transform.position.y - speed * Time.deltaTime);

		} else {
			if (isMoveLeft == true) {
				MoveLeft ();
			} else 
			{
				MoveRight ();
			}
			Shoot ();
		}

		if (transform.position.y < -10) 
		{
			Destroy (gameObject);
		}
	}

	void MoveLeft()
	{
		transform.position = new Vector2 (transform.position.x - speed * Time.deltaTime, transform.position.y);
		if (transform.position.x < -5.5) 
		{
			isMoveLeft = false;
		}
	}

	void MoveRight()
	{
		transform.position = new Vector2 (transform.position.x + speed * Time.deltaTime, transform.position.y);
		if (transform.position.x > 5.5) 
		{
			isMoveLeft = true;
		}
	}

	void Shoot()
	{
		if (shoottimer == 0) 
		{
			Instantiate (bullet, new Vector2 (transform.position.x, transform.position.y - 1), Quaternion.Euler(new Vector3(0, 0, 180)));
		}
		shoottimer += Time.deltaTime * shootspeed;
		if (shoottimer > 1) 
		{
			shoottimer = 0;
		}

	}


}
