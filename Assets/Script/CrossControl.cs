using UnityEngine;
using System.Collections;

public class CrossControl : MonoBehaviour {
	public GameObject Cross1;
	public GameObject Cross2;
	public GameObject Cross3;
	public GameObject Cross4;
	public GameObject Cross5;
	public GameObject Cross6;
	public GameObject Cross7;
	public GameObject Cross8;
	public GameObject Cross9;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameControl.MouseClicked) 
		{
			for(int i=0; i < 3; i++)
			{
				for(int j=0;j < 3; j++)
				{
					if(GameControl.Board[i ,j]==1)
					{
						if(i==0)
						{
							if(j==0)
							{
								Cross1.SetActive(true);
							}
							else if(j==1)
							{
								Cross2.SetActive(true);
							}
							else
							{
								Cross3.SetActive(true);
							}
						}
						else if(i==1)
						{
							if(j==0)
							{
								Cross4.SetActive(true);
							}
							else if(j==1)
							{
								Cross5.SetActive(true);
							}
							else
							{
								Cross6.SetActive(true);
							}
						}
						else
						{
							if(j==0)
							{
								Cross7.SetActive(true);
							}
							else if(j==1)
							{
								Cross8.SetActive(true);
							}
							else
							{
								Cross9.SetActive(true);
							}
						}
					}
				}
			}
		}
	}
}
