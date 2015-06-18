using UnityEngine;
using System.Collections;

public class ZeroControl : MonoBehaviour {
	public GameObject Zero1;
	public GameObject Zero2;
	public GameObject Zero3;
	public GameObject Zero4;
	public GameObject Zero5;
	public GameObject Zero6;
	public GameObject Zero7;
	public GameObject Zero8;
	public GameObject Zero9;
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
					if(GameControl.Board[i ,j]==0)
					{
						if(i==0)
						{
							if(j==0)
							{
								Zero1.SetActive(true);
							}
							else if(j==1)
							{
								Zero2.SetActive(true);
							}
							else
							{
								Zero3.SetActive(true);
							}
						}
						else if(i==1)
						{
							if(j==0)
							{
								Zero4.SetActive(true);
							}
							else if(j==1)
							{
								Zero5.SetActive(true);
							}
							else
							{
								Zero6.SetActive(true);
							}
						}
						else
						{
							if(j==0)
							{
								Zero7.SetActive(true);
							}
							else if(j==1)
							{
								Zero8.SetActive(true);
							}
							else
							{
								Zero9.SetActive(true);
							}
						}
					}
				}
			}
		}
	
	}
}
