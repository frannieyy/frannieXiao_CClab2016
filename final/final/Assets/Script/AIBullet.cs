using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AIBullet : MonoBehaviour {

	public float maxPos;
	public float speed;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position += transform.up * speed * Time.deltaTime;

		if (transform.position.y > maxPos) 
		{
			Destroy (gameObject);
		}
		if (transform.position.y < -maxPos) 
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (tag == "playerbullet" && coll.tag == "enemy") 
		{
			Destroy (coll.gameObject);
			Destroy (gameObject);

//			AIMain.UpdateScore ();
			GameObject.FindWithTag("score").GetComponent<score>().ScoreUpdate();


		}
	}
}
