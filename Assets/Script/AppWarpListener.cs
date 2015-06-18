
using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.message;
using com.shephertz.app42.gaming.multiplayer.client.transformer;
using SimpleJSON;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace AssemblyCSharp
{

	public class AppWarpListener : ConnectionRequestListener, LobbyRequestListener, ZoneRequestListener, RoomRequestListener, ChatRequestListener, UpdateRequestListener, NotifyListener
	{
		public int state = 0;
		string debug = "";
		public string roomID;  /* for getting room ids*/ 
		private void Log(string msg)
		{
			debug = msg + "\n" + debug;

			if (debug.Length > 1000)
			debug = debug.Substring (0, 1000);
		}
		
		public string getDebug()
		{
			return debug;
		}

		public bool doDisconnect  = false;
		private bool alternateTry = false;
		//ConnectionRequestListener
		public void onConnectDone(ConnectEvent eventObj)
		{
			if (eventObj.getResult () == 0) {
				WarpClient.GetInstance ().SubscribeLobby ();
			} else
				Log ("On Connect Done "+eventObj.getResult ().ToString());
		}



		public void onInitUDPDone(byte res)
		{
		}
		
		public void onLog(String message){
			Log (message);
		}
		
		public void onDisconnectDone(ConnectEvent eventObj)
		{

		}
		
		//LobbyRequestListener
		public void onJoinLobbyDone (LobbyEvent eventObj)
		{

		}
		
		public void onLeaveLobbyDone (LobbyEvent eventObj)
		{
			Log ("onLeaveLobbyDone : " + eventObj.getResult());
		}
		
		public void onSubscribeLobbyDone (LobbyEvent eventObj)
		{
			if (eventObj.getResult () == 0) {
				WarpClient.GetInstance ().GetAllRooms ();
			} else
				Log (eventObj.getResult ().ToString());
		}
		
		public void onUnSubscribeLobbyDone (LobbyEvent eventObj)
		{
			Log ("onUnSubscribeLobbyDone : " + eventObj.getResult());
		}
		
		public void onGetLiveLobbyInfoDone (LiveRoomInfoEvent eventObj)
		{
			Log ("onGetLiveLobbyInfoDone : " + eventObj.getResult());
		}
		
		//ZoneRequestListener
		public void onDeleteRoomDone (RoomEvent eventObj)
		{
			Log ("onDeleteRoomDone : " + eventObj.getResult());
		}


		public void onGetAllRoomsDone (AllRoomsEvent eventObj)
		{
			string[] roomIDs = eventObj.getRoomIds ();

			foreach (string s in roomIDs)
			{
				Log ("id : " + s);
				WarpClient.GetInstance().JoinRoom(s);

			}
		}
		
		public void onCreateRoomDone (RoomEvent eventObj)
		{

		}
		
		public void onGetOnlineUsersDone (AllUsersEvent eventObj)
		{
			Log ("onGetOnlineUsersDone : " + eventObj.getUserNames ()[0]);
			
		}


		public void onGetLiveUserInfoDone (LiveUserInfoEvent eventObj)
		{


		}
		
		public void onSetCustomUserDataDone (LiveUserInfoEvent eventObj)
		{
			Log ("onSetCustomUserDataDone : " + eventObj.getResult());
		}
		
		public void onGetMatchedRoomsDone(MatchedRoomsEvent eventObj)
		{

		}		
		//RoomRequestListener
		public void onSubscribeRoomDone (RoomEvent eventObj)
		{
			WarpClient.GetInstance().SendChat("chat");
		}
		
		public void onUnSubscribeRoomDone (RoomEvent eventObj)
		{

		}
		
		public void onJoinRoomDone (RoomEvent eventObj)
		{
			Log ("On join room done " + eventObj.getResult ());
			WarpClient.GetInstance ().SubscribeRoom (eventObj.getData ().getId());

		}
		
		public void onLockPropertiesDone(byte result)
		{
			Log ("onLockPropertiesDone : " + result);
		}
		
		public void onUnlockPropertiesDone(byte result)
		{
			Log ("onUnlockPropertiesDone : " + result);
		}
		
		public void onLeaveRoomDone (RoomEvent eventObj)
		{

		}


		public void onGetLiveRoomInfoDone (LiveRoomInfoEvent eventObj)
		{

		}
		
		public void onSetCustomRoomDataDone (LiveRoomInfoEvent eventObj)
		{
			Log ("onSetCustomRoomDataDone : " + eventObj.getResult());
		}
		
		public void onUpdatePropertyDone(LiveRoomInfoEvent eventObj)
		{

		}

		//ChatRequestListener
		public void onSendChatDone (byte result)
		{
			//Log ("on send chat done " + result.ToString ());

		}
		void onSendMoveDone(byte result)
		{

		}
		void onStartGameDone(byte result)
		{

		}
		
		public void onSendPrivateChatDone(byte result)
		{
			Log ("onSendPrivateChatDone : " + result);

		}

		void onStopGameDone(byte result)
		{

		}

		void onSetNextTurnDone(byte result)
		{

		}

		void onGetMoveHistoryDone(byte result, MoveEvent[] history)
		{

		}


		//UpdateRequestListener
		public void onSendUpdateDone (byte result)
		{
			Log ("onSend.UpdateDone : " + result);
		}
		public void onSendPrivateUpdateDone (byte result)
		{
			Log ("onSendPrivateUpdateDone : " + result);
			Log ("onSendPrivateUpdateDone : " + result);
		}
		//NotifyListener
		public void onRoomCreated (RoomData eventObj)
		{
			Log ("onRoomCreated "+ eventObj.getId()+ " " +eventObj.getRoomOwner ());	
		}
		public void onPrivateUpdateReceived (string sender, byte[] update, bool fromUdp)
		{
			Log ("onPrivateUpdate");
		}
		public void onRoomDestroyed (RoomData eventObj)
		{
			Log ("onRoomDestroyed");

		}
		
		public void onUserLeftRoom (RoomData eventObj, string username)
		{

		}
		
		public void onUserJoinedRoom (RoomData eventObj, string username)
		{
			Log ("User Joined " + eventObj.getName ());
			Log ("user name " + username);

		}
		
		public void onUserLeftLobby (LobbyData eventObj, string username)
		{
			Log ("onUserLeftLobby : " + username);
		}
		
		public void onUserJoinedLobby (LobbyData eventObj, string username)
		{
			Log ("onUserJoinedLobby : " + username);
		}
		
		public void onUserChangeRoomProperty(RoomData roomData, string sender, System.Collections.Generic.Dictionary < String, Object> properties, Dictionary<String, String> lockedPropertiesTable)
		{

		}
		
		public void onPrivateChatReceived(string sender, string message)
		{
			Log ("onPrivateChatReceived : " + sender+message);



		}
		
		public void onMoveCompleted(MoveEvent move)
		{

		}
		
		public void onChatReceived (ChatEvent eventObj)
		{


				Log (eventObj.getSender () + " sended " + eventObj.getMessage ());
				string Message = eventObj.getMessage ();
				if (Message [0] == '*' && Message [1] == '*') {
					char x = Message [2];
					char y = Message [3];
					char z = Message [4];
					int X = int.Parse (x.ToString ());
					int Y = int.Parse (y.ToString ());
					int Z = int.Parse (z.ToString ());
					Log (X + "  " + Y + "  " + Z);
					//GameControl.Board [X, Y] = Z;
					if (Z == 1) {
						GameControl.Board [X, Y] = Z;
						GameControl.Move = false;
					} else if (Z == 0) {
						GameControl.Board [X, Y] = Z;
						GameControl.Move = true;
					}

			}

		}
		
		public void onUpdatePeersReceived (UpdateEvent eventObj)
		{
			Log ("onUpdatePeersReceived");

		}
		
	
		
		public void sendMsg(string msg)
		{

		}
		
		public void onUserPaused(String locid, Boolean isLobby, String username)
		{
		
		}
		
		public void onUserResumed(String locid, Boolean isLobby, String username)
		{

		}
		
		public void onGameStarted(string started, string id, string nextTurn)
		{

		}
		
		public void onGameStopped(String a , String b)
		{

		}

		string GetString(byte[] bytes)
		{
			char[] chars = new char[bytes.Length / sizeof(char)];
			System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
			return new string(chars);
		}

		public void onNextTurnRequest(string s)
		{

		}
		/*public void onInvokeZoneRPCDone(RPCEvent rEvent)
		{

		}

		public void onInvokeRoomRPCDone(RPCEvent rEvent)
		{

		}

		public void onDeleteRoomDone(RPCEvent rEvent)
		{

		}*/
		
	}
}

