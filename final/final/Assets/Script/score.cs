using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {

	private  int totalScore =0;
	public  Text txt;
	private  GameObject scoreObject;


	// Use this for initialization
	void Start () {
		scoreObject = GameObject.FindWithTag("score");
		txt = scoreObject.GetComponent<Text>(); 
	}
	
	// Update is called once per frame
	public void ScoreUpdate () {
		totalScore += 20;
		Debug.Log("SHOT " + totalScore);
		//			GameObject.FindWithTag("score").GetComponent<Text>().text = "SCORE !: " + score++;
		txt.text = "Score : " + totalScore;
	}
		
}
