using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public float maxXpos;
	public float maxYpos;

	public float speed;

	public GameObject bullet;
	public bool startshoot;
	public float shoottimer;
	public float shootspeed;



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//keyboard control
		if (Input.GetKey (KeyCode.LeftArrow) && transform.position.x > -maxXpos) {
			transform.position = new Vector2 (transform.position.x - speed * Time.deltaTime, transform.position.y);
		}
		if (Input.GetKey (KeyCode.RightArrow) && transform.position.x < maxXpos) {
			transform.position = new Vector2 (transform.position.x + speed * Time.deltaTime, transform.position.y);
		}
		if (Input.GetKey (KeyCode.UpArrow) && transform.position.y < maxYpos) {
			transform.position = new Vector2 (transform.position.x, transform.position.y + speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.DownArrow) && transform.position.y > -maxYpos) {
			transform.position = new Vector2 (transform.position.x, transform.position.y - speed * Time.deltaTime);
		}

		if (Input.GetButtonDown ("Fire1")) 
		{
			startshoot = true;
		} 
		else if (Input.GetButtonUp ("Fire1")) 
		{
			startshoot = false;
			shoottimer = 0;
		}

		if (startshoot == true) 
		{
			Shoot ();
		}
	}


	void Shoot()
	{
		if (shoottimer == 0) 
		{
			Instantiate (bullet, new Vector2 (transform.position.x, transform.position.y + 1), Quaternion.identity);
		}
		shoottimer += Time.deltaTime * shootspeed;
		if (shoottimer > 1) 
		{
			shoottimer = 0;
		}
			
	}
		
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "enemy" || coll.tag == "enemybullet") 
		{
			Destroy (coll.gameObject);
			Destroy (gameObject);
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
