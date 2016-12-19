using UnityEngine;
using System.Collections;

public class aienemy : MonoBehaviour {

	public float speed;

	public GameObject bullet;
	public float shoottimer;
	public float shootspeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x, transform.position.y - speed * Time.deltaTime);

		Shoot ();

		if (transform.position.y < -10) 
		{
			Destroy (gameObject);
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
