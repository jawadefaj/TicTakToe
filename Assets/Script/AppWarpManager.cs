using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.message;
using com.shephertz.app42.gaming.multiplayer.client.transformer;
using AssemblyCSharp;
using SimpleJSON;
using System;


public class AppWarpManager : MonoBehaviour {

	public static AppWarpManager instance;

	//settings for japan server
	public static string apiKey = "7431396dfb7a31abfa1c9f96b672ef1af9e28c10ce86bcd70ddf0735ccd37af9";
	public static string secretKey = "3e8d5e22eec44c8777419d191be7cb818894a85727bb2e2d4c63c7ca11af83d3";
	
	//settings for local AppWarpS2 Server
	//public static string apiKey_s2 ="d3d1f421-98b4-4202-a";
	//public static string address="127.0.0.1";
	//public static int port= 12346;

	//settings for EC@ AppWarpS2 Server
	public static string apiKey_s2 ="3a018aeb-6bc3-4b92-8";
	public static string address="54.186.177.108";
	public static int port= 12346;

	public bool isConnected=false;
	internal int responseToGet=0;
	internal int frndsInfoToCollect=0;
	AppWarpListener listen = new AppWarpListener();
	
	//saved commands
	internal List<string> savedMsgd = new List<string>();

	//switch
	private bool canReset=true;

	void Awake()
	{
		if(instance==null)
			AppWarpManager.instance=this;
		else
			Destroy (this);
	}

	void Start () {

		//bind all events

		//to connect with usa server
		//WarpClient.initialize(apiKey_us,secretKey_us);

		//to connect with Japan server
		//WarpClient.initialize(apiKey,secretKey);

		//to connect to appwarps2 server on my pc
		//WarpClient.initialize (apiKey_s2,address,port);
		WarpClient.initialize (apiKey, secretKey);

		WarpClient.setRecoveryAllowance (0); //max recovery time set
		WarpClient.GetInstance().AddConnectionRequestListener(listen);
		WarpClient.GetInstance().AddChatRequestListener(listen);
		WarpClient.GetInstance().AddLobbyRequestListener(listen);
		WarpClient.GetInstance().AddNotificationListener(listen);
		WarpClient.GetInstance().AddRoomRequestListener(listen);
		WarpClient.GetInstance().AddUpdateRequestListener(listen);
		WarpClient.GetInstance().AddZoneRequestListener(listen);

		//connect
		WarpClient.GetInstance ().Connect ("jawad");


	}

	void Update()
	{
		WarpClient.GetInstance ().Update ();


	}

	public static void MoveAfterMove(int a, int b)
	{
		if (GameControl.Move && GameControl.Board[a, b]==-1)
		{
			//GameControl.Board [a, b] = 1;
			//GameControl.Move = false;
			WarpClient.GetInstance().SendChat("**"+a+""+b+""+"1");

		}
		/*else if( GameControl.Move==false && GameControl.Board[a, b]==-1)
		{
			//GameControl.Board[a, b]=0;
			//GameControl.Move = true;
			WarpClient.GetInstance().SendChat("**"+a+""+b+""+"0");

		}*/
	}

	void OnGUI()
	{
		if(Debug.isDebugBuild)
		{
			GUI.contentColor = Color.white ;
			GUI.skin.label.fontSize=20;
			GUI.Label(new Rect(10,10,500,300), listen.getDebug ());
			GUI.Label(new Rect(600,10,500,300), "Connection Status "+ WarpClient.GetInstance ().GetConnectionState());
			//string text = "<b>Hello</b><color=red>World</color>";
			//GUI.Label (new Rect(20,20,100,100),text);


		}

	}

	byte[] GetBytes(string str)
	{
		byte[] bytes = new byte[str.Length * sizeof(char)];
		System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
		return bytes;
	}

}
