using UnityEngine;
using System.Collections;

public class AIWall : MonoBehaviour {

	public float speed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x, transform.position.y - speed * Time.deltaTime);

		if (transform.position.y < -10) 
		{
			Destroy (gameObject);
		}
	}
}
