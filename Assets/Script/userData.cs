using System.Collections;
//enum ITEM{DRILL,CUSHION,WALL,JUMPING};
public class usingitem{
	private string itemName;
	//private int numOfItem;

	public usingitem clone(){
		usingitem temp = new usingitem ( this.itemName);
		return temp;
	}
	public usingitem(string s){
		itemName = s;
		//numOfItem = n;
	}
	public string getItemName(){
		return itemName;
	}
}
public class Stage{
	private int score = 0;
    private int numOfItem;
	private bool isCleared = false;
	private ArrayList itemList = new ArrayList();

	public Stage(usingitem[] usi,int n){
        numOfItem = n;
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
    public int getNumOfItem()
    {
        return numOfItem;
    }
	public bool isClear(){
		return isCleared;
	}
}

public static class userData{
	public static int totalScore;
	public static int clearedStage=-1;
	public static int curStageNum;
	public static int numOfItemKind = 4;


	public static Stage[] stage = new Stage[10]{
		new Stage(new usingitem[4]{
			new usingitem("drill"),
			new usingitem("cushion"),
			new usingitem("wall"),
			new usingitem("jumping")
		},4),
		new Stage(new usingitem[1]{new usingitem("drill")},2),
		new Stage(new usingitem[1]{new usingitem("jumping")},2),
		new Stage(new usingitem[1]{new usingitem("cushion")},2),
		new Stage(new usingitem[2]{
			new usingitem("wall"),
			new usingitem("cushion")
        },3),
		new Stage(new usingitem[3]
		{
			new usingitem("drill"),
			new usingitem("cushion"),
			new usingitem("jumping")
		},4),
		new Stage(new usingitem[2]{
			new usingitem("drill"),
			new usingitem("jumping")
		},2),
		new Stage(new usingitem[4]{
			new usingitem("drill"),
			new usingitem("cushion"),
			new usingitem("wall"),
			new usingitem("jumping")
		},5),
		new Stage(new usingitem[4]{
			new usingitem("drill"),
			new usingitem("cushion"),
			new usingitem("wall"),
			new usingitem("jumping")
		},7),
		new Stage(new usingitem[3]{
			new usingitem("drill"),
			new usingitem("cushion"),
			new usingitem("jumping")
		},8)
		
	};



	public static void setCurStage(int n){
		curStageNum = n;
	}
}
