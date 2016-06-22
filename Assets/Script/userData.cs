using System.Collections;
//enum ITEM{DRILL,CUSHION,WALL,JUMPING};
public class usingitem{
	private string itemName;
	private int numOfItem;

	public usingitem clone(){
		usingitem temp = new usingitem ( this.itemName,this.numOfItem);
		return temp;
	}
	public usingitem(string s,int n){
		itemName = s;
		numOfItem = n;
	}
	public string getItemName(){
		return itemName;
	}
	public int getNumOfItem(){
		return numOfItem;
	}
	public void useItem(){
		numOfItem--;
	}
}
public class Stage{
	private int score = 0;
	private bool isCleared = false;
	private ArrayList itemList = new ArrayList();

	public Stage(usingitem[] usi){
		foreach (usingitem tp in usi) {
			itemList.Add (tp);
		}
	}
	public ArrayList getItemList(){
		return itemList;
	}
	public void setScore(int n){
		score = n;
	}
	public int getScore(){
		return score;
	}
	public bool isClear(){
		return isCleared;
	}
}

public static class userData{
	public static int totalScore;
	public static int clearedStage=3;
	public static int curStageNum;
	public static int numOfItemKind = 4;


	public static Stage[] stage = new Stage[5]{
		new Stage(new usingitem[1]{new usingitem("drill",2)}),
		new Stage(new usingitem[1]{new usingitem("jumping",2)}),
		new Stage(new usingitem[1]{new usingitem("cushion",2)}),
		new Stage(new usingitem[2]{
			new usingitem("wall",2),
			new usingitem("cushion",1)}),
		new Stage(new usingitem[3]{
			new usingitem("drill",1),
			new usingitem("jumping",1),
			new usingitem("cushion",1)
		})
	};



	public static void setCurStage(int n){
		curStageNum = n;
	}
}
