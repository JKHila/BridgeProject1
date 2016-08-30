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
	private string goal;
	private bool isCleared = false;
	private ArrayList itemList = new ArrayList();

	public Stage(usingitem[] usi,int n,string goal){
        numOfItem = n;
		foreach (usingitem tp in usi) {
			itemList.Add (tp);
		}
		this.goal = goal;
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
	public string getGoalString(){
		return goal;
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
		},4,"튜토리얼을 완료하세요!"),
		new Stage(new usingitem[1]{new usingitem("drill")},2,"드릴 아이템을 사용하여 슬라임을 구출하세요!"),
		new Stage(new usingitem[1]{new usingitem("jumping")},2,"점프대 아이템을 사용하여 슬라임을 구출하세요!"),
		new Stage(new usingitem[1]{new usingitem("cushion")},2,"베개 아이템을 사용하여 슬라임을 구출하세요!"),
		new Stage(new usingitem[2]{
			new usingitem("wall"),
			new usingitem("cushion")
        },3,"벽 아이템을 사용하여 슬라임을 구출하세요!"),
		new Stage(new usingitem[3]
		{
			new usingitem("drill"),
			new usingitem("cushion"),
			new usingitem("jumping")
		},4,"여러 아이템을 사용하여 슬라임을 구촐하세요!"),
		new Stage(new usingitem[2]{
			new usingitem("drill"),
			new usingitem("jumping")
		},2,"용사를 피해 슬라임을 구출하세요!"),
		new Stage(new usingitem[4]{
			new usingitem("drill"),
			new usingitem("cushion"),
			new usingitem("wall"),
			new usingitem("jumping")
		},5,"용사를 피해 슬라임을 구출하세요!"),
		new Stage(new usingitem[4]{
			new usingitem("drill"),
			new usingitem("cushion"),
			new usingitem("wall"),
			new usingitem("jumping")
		},7,"용사를 피해 슬라임을 구출하세요!"),
		new Stage(new usingitem[3]{
			new usingitem("drill"),
			new usingitem("cushion"),
			new usingitem("jumping")
		},8,"용사를 피해 슬라임을 구출하세요!")
	};



	public static void setCurStage(int n){
		curStageNum = n;
	}
}
