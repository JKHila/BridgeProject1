﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Handler : MonoBehaviour {

	// Use this for initialization
	private int score=0;
	private float time=180;
	private bool isBtnOn = false;
	private bool isMoved = false;
	private GameObject tpObj;
	private Vector3 tpPos;
	private Vector2 initMousePos;
	public float minY = 50, maxY = 50,minX = 50, maxX = 50;

	//public GameObject drillBtn;
	//Map Obj
	public GameObject spawn;
	public GameObject WarriorSpawn;
	public GameObject background;
	//Moving Obj
	public GameObject Slime;
	public GameObject Warrior;
	//Item Obj
	public GameObject upDrill;
	public GameObject Cusion;
	public GameObject Wall;
	//Dummy Obj
	public GameObject dummyCusion;
	public GameObject dummyWall;
	public GameObject dummyjumping;
	//UI Obj;
	public Text scoreText;
	public Text timeText;
	public GameObject clearPnl;
	//etc.
	public SpriteRenderer slimeSpawnSr;
	public SpriteRenderer WarriorSpawnSr;
	public Sprite[] slimeSpawnSp;
	public Sprite[] warriorSpawnSp;
	public GameObject slimes;

	void checkClear(){
		if (score >= 5) {
			clearPnl.SetActive (true);
		}
	}
	void createDummy(GameObject obj){
		isBtnOn = true;
		tpPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		tpObj = (GameObject)Instantiate (obj, (Vector2)tpPos, transform.rotation);
		tpObj.transform.SetParent (slimes.transform);
		tpObj.SetActive (true);
	}
	void checkTouch(){
		if(Input.GetMouseButtonDown(0) == true)
		{
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			if (hit) {
				string tmp = hit.transform.gameObject.name;
				switch(tmp) {
				case "DrillIcon":
					createDummy (upDrill);
					break;
				case "CushionIcon":
					createDummy (dummyCusion);
					break;
				case "WallIcon":
					createDummy (dummyWall);
					break;
				case "JumpingIcon":
					createDummy (dummyjumping);
					break;
				default:
					if (Time.timeScale != 0) {
						initMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
						isMoved = true;
					}
					break;
				}
			} else {
				if (Time.timeScale != 0) {
					initMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					isMoved = true;
				}
			}
		}
		else if(Input.GetMouseButtonUp(0))
		{
			//마우스 뗌.
			if (isBtnOn) {
				isBtnOn = false;
				string temp = tpObj.gameObject.tag;
				switch (temp) {
				case"drill": 
					tpObj.GetComponent<CircleCollider2D> ().enabled = true;
					break;
				case "cushion":
					tpObj.SetActive (false);
					Instantiate (Cusion, (Vector2)tpPos, transform.rotation);
					break;
				case "Wall":
					tpObj.SetActive (false);
					Instantiate (Wall, (Vector2)tpPos, transform.rotation);
					break;
				case "Jumping":
					tpObj.GetComponent<BoxCollider2D> ().enabled = true;
					break;
				default:
					isMoved = false;
					break;
				}
			}
		}
		else if(Input.GetMouseButton(0))
		{
			if (isBtnOn) {
				tpPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				tpObj.transform.position = (Vector2)tpPos; //마우스 누르고 있음.
			} else {
				if(Time.timeScale !=0 && isMoved)
				{
					Vector2 worldpoint;
					worldpoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					Vector2 diffPos = (worldpoint - initMousePos)*Time.deltaTime*20;
				
					transform.position = new Vector3 (Mathf.Clamp((transform.position.x - diffPos.x),minX,maxX),Mathf.Clamp ((transform.position.y - diffPos.y),minY,maxY),-23);
					initMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				}

			}

		}
		/*
		 if(0 < Input.touchCount) 
		   {
		    for(int t = 0; t < 1; ++t)  //멀티 터치를 막아놨음. t < 1 의 뒷부분의 숫자가 최대 멀티터치 숫자임.
		    {
		     if(Input.GetTouch(t).phase == TouchPhase.Began)
		     {
		      //터치 시작.
		     }
		     else if(Input.GetTouch(t).phase == TouchPhase.Ended)
		     {
		      //터치 끝.
		     }
		     else if(Input.GetTouch(t).phase == TouchPhase.Moved || Input.GetTouch(t).phase == TouchPhase.Stationary) 
		     {
		//터치 중, 터치후 이동중.
		     }
		    }
		   }
		 * /
		/*for (int i = 0; i < Input.touchCount; ++i) {  //touch check
			if (Input.GetTouch (i).phase == TouchPhase.Began && isdrillOn) {
				Instantiate (upDrill, Input.GetTouch (i).position, transform.rotation);
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (i).position), Vector2.zero);
				if (hit) {
					isdrillOn = false;
					Destroy (hit.collider.gameObject);
				}
			} else if (Input.GetTouch (i).phase == TouchPhase.Moved && isdrillOn) {
				upDrill.transform.position = Input.GetTouch (i).position;
			} else if (Input.GetTouch (i).phase == TouchPhase.Ended && isdrillOn) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (i).position), Vector2.zero);
				if (hit) {
					isdrillOn = false;
					Destroy (hit.collider.gameObject);
				}
			}
		}*/
	}
	void checkEndGame(){
		if (Input.GetKeyDown (KeyCode.Escape)) { //Quit game
			Application.Quit();
		}
	}
	void checkTime(){
		time -= Time.deltaTime;
		timeText.text = (int)time / 60 + ":";
		if ((int)time % 60 > 9) {
			timeText.text += (int)time % 60;
		} else {
			timeText.text += "0" + (int)time % 60;
		}
	}
	IEnumerator warriorSpawnAni(){
		for (int i = 0; i < 16; i++) {
			WarriorSpawnSr.sprite = warriorSpawnSp [i];
			yield return new WaitForSeconds (0.1f);
			if (i == 8) {
				GameObject tmp2 = (GameObject)Instantiate (Warrior, new Vector2 (WarriorSpawn.transform.position.x, WarriorSpawn.transform.position.y), this.transform.rotation);
				tmp2.transform.SetParent (slimes.transform);
			}
		}

	}
	public void addScore(){
		score++;
		scoreText.text = score.ToString(); 
	}

	IEnumerator CreateSlime(){
		for (int i = 0; i < 5; i++) {
			//float a = Random.Range (-1.0f, 1.0f);
			GameObject tmp = (GameObject)Instantiate (Slime, new Vector2 (spawn.transform.position.x, spawn.transform.position.y), this.transform.rotation);
			tmp.transform.SetParent (slimes.transform);
			tmp.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 10,ForceMode2D.Impulse);
			yield return new WaitForSeconds (3.0f);
		}
		yield return new WaitForSeconds (1.0f);
		StartCoroutine (warriorSpawnAni());
	}
	
	void Start () {
		WarriorSpawnSr = WarriorSpawn.GetComponent<SpriteRenderer> ();
		slimeSpawnSr = spawn.GetComponent<SpriteRenderer> ();
		StartCoroutine (CreateSlime ());
	}
	// Update is called once per frame
	void Update () {
		checkTime ();
		checkEndGame ();
		checkTouch ();
		checkClear ();
	}

}
