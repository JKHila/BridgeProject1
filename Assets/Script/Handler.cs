using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Handler : MonoBehaviour {

	// Use this for initialization
	private ArrayList itemList;
	private usingitem drillItem,cushionItem,wallItem,jumpingItem;
	private int numDie=0;
	private int score=0;
	private float time=60;
	private bool isBtnOn = false;
	private bool isMoved = false;
	private GameObject tpObj;
	private Vector3 tpPos;
	private Vector2 initMousePos;
	private int[] seqOfItem = new int[userData.numOfItemKind]; 

	//Camera Opt
	public float minY = 50, maxY = 50,minX = 50, maxX = 50;
	//Map Obj
	public GameObject spawn;
	public GameObject WarriorSpawn;
	public GameObject background;
	//Moving Obj
	public GameObject Slime;
	//Item Obj
	public GameObject upDrill;
	public GameObject Cusion;
	public GameObject Wall;
	//Dummy Obj
	public GameObject dummyCusion;
	public GameObject dummyWall;
	public GameObject dummyjumping;
	//UI Obj;
	public Text[] itemNumText = new Text[userData.numOfItemKind]; 
	public GameObject[] icon = new GameObject[userData.numOfItemKind];
	public Text scoreText;
	public Text timeText;
	public Text endScoreText;
	public Text ClearText;
	public Image[] scoreStar;
	public Sprite noStar;
	public GameObject clearPnl;
	//etc.
	public SpriteRenderer slimeSpawnSr;
	public Sprite[] slimeSpawnSp;
	public GameObject slimes;

	void checkClear(){
		if (score > userData.stage [userData.curStageNum].getScore ()) { 
			userData.stage [userData.curStageNum].setScore (score);
		}
		if (userData.curStageNum > userData.clearedStage)
			userData.clearedStage = userData.curStageNum;
		if (score+numDie >= 20) {
			endScoreText.text = "X " + score + "/20";
			if (score < 3) {
				ClearText.text = "FAIL!";
				scoreStar [0].sprite = noStar;	
				scoreStar [1].sprite = noStar;	
				scoreStar [2].sprite = noStar;	
			}
			else if (score < 10) {
				scoreStar [1].sprite = noStar;	
				scoreStar [2].sprite = noStar;	
			}
			else if(score >=10 && score <20)
				scoreStar [2].sprite = noStar;	
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
					if (drillItem.getNumOfItem() > 0)
						createDummy (upDrill);
					break;
				case "CushionIcon":
					if(cushionItem.getNumOfItem() > 0)
						createDummy (dummyCusion);
					break;
				case "WallIcon":
					if(wallItem.getNumOfItem() > 0)
					createDummy (dummyWall);
					break;
				case "JumpingIcon":
					if(jumpingItem.getNumOfItem() > 0)
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
					drillItem.useItem ();
					UpdateItemNum (seqOfItem[0], drillItem.getNumOfItem());
					break;
				case "cushion":
					tpObj.SetActive (false);
					Instantiate (Cusion, (Vector2)tpPos, transform.rotation);
					cushionItem.useItem ();
					UpdateItemNum (seqOfItem[1], cushionItem.getNumOfItem());
					break;
				case "Wall":
					tpObj.SetActive (false);
					Instantiate (Wall, (Vector2)tpPos, transform.rotation);
					wallItem.useItem ();
					UpdateItemNum (seqOfItem[2], wallItem.getNumOfItem());
					break;
				case "Jumping":
					tpObj.GetComponent<BoxCollider2D> ().enabled = true;
					jumpingItem.useItem ();
					UpdateItemNum (seqOfItem[3], jumpingItem.getNumOfItem());
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
	public void addDieCnt(){
		numDie++;
	}
	public void addScore(){
		score++;
		scoreText.text = score.ToString(); 
	}
	public void UpdateItemNum(int n,int numOfItem){ //남은 아이템 갯수
		itemNumText [n].text = numOfItem.ToString ();
	}
	
//시작처리
	IEnumerator CreateSlime(){
		for (int i = 0; i < 20; i++) {
			for (int j = 0; j < 6; j++) {
				slimeSpawnSr.sprite = slimeSpawnSp [j];
				yield return new WaitForSeconds (0.05f);
			}
			slimeSpawnSr.sprite = slimeSpawnSp [0];
			//float a = Random.Range (-1.0f, 1.0f);
			GameObject tmp = (GameObject)Instantiate (Slime, new Vector2 (spawn.transform.position.x+1.4f, spawn.transform.position.y-1.5f), this.transform.rotation);
			tmp.transform.SetParent (slimes.transform);
			//tmp.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 10,ForceMode2D.Impulse);
			yield return new WaitForSeconds (0.1f);
		}
	}

	void setItem(){
		float x = -2.75f, y = -0.23f;
		int i = 0;
		itemList = userData.stage [userData.curStageNum].getItemList ();
		foreach (usingitem usi in itemList) {
		string str = usi.getItemName();
			switch (str) {
			case "drill":
				icon [0].transform.localPosition = new Vector2 (x, y);
				seqOfItem [0] = i;
				itemNumText [i++].text = usi.getNumOfItem ().ToString ();
				drillItem = usi.clone ();
				break;
			case "cushion":
				icon [1].transform.localPosition = new Vector2 (x, y);
				seqOfItem [1] = i;
				itemNumText [i++].text = usi.getNumOfItem ().ToString ();
				cushionItem = usi.clone ();
				break;
			case "wall":
				icon [2].transform.localPosition = new Vector2 (x, y);
				seqOfItem [2] = i;
				itemNumText [i++].text = usi.getNumOfItem ().ToString ();
				wallItem = usi.clone ();
				break;
			case "jumping":
				icon [3].transform.localPosition = new Vector2 (x, y);
				seqOfItem [3] = i;
				itemNumText [i++].text = usi.getNumOfItem ().ToString ();
				jumpingItem = usi.clone ();
				break;
			}
			x += 2.28f;
		}
	}

	void Start () {
		setItem ();
		background = GameObject.Find ("Background");
		WarriorSpawn = GameObject.Find ("WarriorSpawn");
		spawn = GameObject.Find ("Spawn");
		slimes = GameObject.Find ("MovingObj");
		//WarriorSpawnSr = WarriorSpawn.GetComponent<SpriteRenderer> ();
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
