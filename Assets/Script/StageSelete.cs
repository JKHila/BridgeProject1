using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StageSelete : MonoBehaviour {
	private int totalStar;
	public GameObject[] btn = new GameObject[9];
	public Sprite[] sp = new Sprite[4];
	public Image gauge;
	public Text starText;
	// Use this for initialization
	void Start () {
		showStage();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void showStage(){
		Debug.Log (PlayerPrefs.GetInt ("clearedStage"));
		for (int i = 0; i <= PlayerPrefs.GetInt("clearedStage")+1; i++) {
			string stageText = "Stage" + i + "Score";
			int score = PlayerPrefs.GetInt (stageText);
			if (score < 3)
				btn [i].GetComponent<Image> ().sprite = sp [0];
			else if(score < 10){
				btn [i].GetComponent<Image> ().sprite = sp [1];
				totalStar +=1;
			}
			else if(score >=10 && score <20){
				btn [i].GetComponent<Image> ().sprite = sp [2];
				totalStar +=2;
			}
			else {
				btn [i].GetComponent<Image> ().sprite = sp [3];
				totalStar +=3;	
			}
			btn [i].transform.FindChild ("Text").gameObject.SetActive (true);
			btn [i].GetComponent<Button> ().interactable = true;		
		}
		Debug.Log(totalStar);
		starText.text = totalStar + "/30";
		gauge.fillAmount = (float)(totalStar/30.0);
	}
}
