using UnityEngine;
using System.Collections;
using com.shephertz.app42.gaming.multiplayer.client.message;

public class GameControl : MonoBehaviour {
	public static int[,] Board= new int[3,3];
	public static bool Move;
	public static bool MouseClicked;



	int count;
	// Use this for initialization
	void Start () {

		MouseClicked = true;
		Move = false;
		count = 0;
		for (int i = 0; i < 3; i++) 
		{
			for(int j = 0; j < 3; j++)
			{
				Board[i,j]=-1;
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) 
		{
			MouseClicked = true;

			Ray Mouse= Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 mouseposition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x,Input.mousePosition.y,0));
			int mouseY = (int)(Mathf.Floor((float)((mouseposition.x+3.33)/2.23)));
			int mouseX=(int)(Mathf.Floor((float)(-(mouseposition.y-5.0f)/2.5)));

			//Debug.Log(mouseX+"\t\t"+mouseY );
			if(mouseX<3)
			{
				AppWarpManager.MoveAfterMove(mouseX, mouseY);
			}
			if((Board[0,0]==0 && Board[0,1]==0 && Board[0,2]==0) ||
			   (Board[1,0]==0 && Board[1,1]==0 && Board[1,2]==0) ||
			   (Board[2,0]==0 && Board[2,1]==0 && Board[2,2]==0) ||
			   (Board[0,0]==0 && Board[1,0]==0 && Board[2,0]==0) ||
			   (Board[0,1]==0 && Board[1,1]==0 && Board[2,1]==0) ||
			   (Board[0,2]==0 && Board[1,2]==0 && Board[2,2]==0) ||
			   (Board[0,0]==0 && Board[1,1]==0 && Board[2,2]==0) ||
			   (Board[0,2]==0 && Board[1,1]==0 && Board[2,0]==0))
			{
				Debug.Log("Dounout wins");
			}
			else if((Board[0,0]==1 && Board[0,1]==1 && Board[0,2]==1) ||
			        (Board[1,0]==1 && Board[1,1]==1 && Board[1,2]==1) ||
			        (Board[2,0]==1 && Board[2,1]==1 && Board[2,2]==1) ||
			        (Board[0,0]==1 && Board[1,0]==1 && Board[2,0]==1) ||
			        (Board[0,1]==1 && Board[1,1]==1 && Board[2,1]==1) ||
			        (Board[0,2]==1 && Board[1,2]==1 && Board[2,2]==1) ||
			        (Board[0,0]==1 && Board[1,1]==1 && Board[2,2]==1) ||
			        (Board[0,2]==1 && Board[1,1]==1 && Board[2,0]==1))
			{
				Debug.Log("Cross wins");
			}

		}

		//Debug.Log (Board [2, 2]);
		
	}


}
