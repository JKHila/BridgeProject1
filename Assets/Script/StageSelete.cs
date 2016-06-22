using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StageSelete : MonoBehaviour {
	public GameObject[] btn = new GameObject[9];
	public Sprite[] sp = new Sprite[4];
	// Use this for initialization
	void Start () {
		
		for (int i = 0; i <= userData.clearedStage+1; i++) {
			int score = userData.stage [i].getScore();
			if (score < 3)
				btn [i].GetComponent<Image> ().sprite = sp [0];
			else if(score < 10)
				btn [i].GetComponent<Image> ().sprite = sp [1];
			else if(score >=10 && score <20)
				btn [i].GetComponent<Image> ().sprite = sp [2];
			else
				btn [i].GetComponent<Image> ().sprite = sp [3];
			btn [i].transform.FindChild ("Text").gameObject.SetActive (true);
			btn [i].GetComponent<Button> ().interactable = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
