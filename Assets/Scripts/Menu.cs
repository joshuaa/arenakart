using UnityEngine;
using System.Collections;
 
public class Menu : MonoBehaviour
{
    public Menu instance;
    private GameObject mm;
 
    public string CurrentMenu;
 
    public string MatchName = "";
    public string MatchPassword = "";
    public int MatchMaxPlayers = 32;
 
    private Vector2 ScrollLobby = Vector2.zero;
    private string iptemp = "127.0.0.1";
 
    void Start()
    {
        mm = GameObject.FindWithTag("MultiplayerManager");
        instance = this;
        CurrentMenu = "Main";
        MatchName = "HeyHeyWelcome " + Random.Range(0, 5000);
		Screen.lockCursor = false;
    }

    void Update()
    {
        if (CurrentMenu == "Main")
        {
            transform.position = new Vector3(0,1,-10);
        }
        else if (CurrentMenu == "Online")
        {
            transform.position = new Vector3(0,11,-10);
        }
        else
        {
            transform.position = new Vector3(0,100,-10);
        }
    }
 
    void FixedUpdate()
    {
        instance = this;
    }
 
    void OnGUI()
    {
        if (CurrentMenu == "Main")
            Menu_Main();
        if (CurrentMenu == "Online")
            Menu_Online();
        if (CurrentMenu == "Host")
            Menu_Host();
        if (CurrentMenu == "Options")
            Menu_Options();
        if (CurrentMenu == "Kart")
            Menu_Kart();
    }
 
    public void NavigateTo(string nextmenu)
    {
        CurrentMenu = nextmenu;
    }
 
    private void Menu_Main()
    {
        if (GUI.Button(new Rect(Screen.width/10, Screen.height/10, (8*Screen.width)/10, Screen.height/4), "Play Online"))
        {
            NavigateTo("Online");
        }
        if (GUI.Button(new Rect(Screen.width/10, (4*Screen.height)/10, (8*Screen.width)/10, Screen.height/4), "Host Local"))
        {
            NavigateTo("Host");
        }
        if (GUI.Button(new Rect(Screen.width/10, (7*Screen.height)/10, (8*Screen.width)/10, Screen.height/4), "Options"))
        {
            NavigateTo("Options");
        }
    }

    private void Menu_Online()
    {
        if (GUI.Button(new Rect(0.5f*Screen.width/20, (3.5f*Screen.height)/10, (3f*Screen.width)/10, Screen.height/8), "Character"))
        {
            NavigateTo("Online");
        }
        if (GUI.Button(new Rect(0.5f*Screen.width/20, (5.25f*Screen.height)/10, (3f*Screen.width)/10, Screen.height/8), "Kart"))
        {
            NavigateTo("Kart");
        }

        if (GUI.Button(new Rect(0.5f*Screen.width/20, (7*Screen.height)/10, (3f*Screen.width)/10, Screen.height/4), "Back"))
        {
            NavigateTo("Main");
        }
        if (GUI.Button(new Rect((13.5f*Screen.width)/20, (7*Screen.height)/10, (3f*Screen.width)/10, Screen.height/4), "Join"))
        {
            //Network.Connect(iptemp, 2550);
            Application.LoadLevel("Main");
        }
        if (GUI.Button(new Rect((7f*Screen.width)/20, (7*Screen.height)/10, (3f*Screen.width)/10, Screen.height/4), "Refresh"))
        {
            MasterServer.RequestHostList("ArenaKart");
        }

        //iptemp = GUI.TextField(new Rect((5.5f*Screen.width)/10, (9*Screen.height)/10, Screen.width/10, Screen.height/20), iptemp);
 
        GUILayout.BeginArea(new Rect((7f*Screen.width)/20, Screen.height/20, (3.75f*Screen.width)/6, (3*Screen.height)/5), "Server List", "Box");
        GUILayout.Space(20);
        foreach (HostData match in MasterServer.PollHostList())
        {
            GUILayout.BeginHorizontal("Box");
            GUILayout.Label(match.gameName);
            
 
            GUILayout.EndHorizontal();
        }
 
        GUILayout.EndArea();
    }

    private void Menu_Kart()
    {
        if (GUI.Button(new Rect(0.5f*Screen.width/20, (7*Screen.height)/10, (3f*Screen.width)/10, Screen.height/4), "Back"))
        {
            NavigateTo("Online");
        }
        if (GUI.Button(new Rect((7f*Screen.width)/20, (7*Screen.height)/10, (3f*Screen.width)/10, Screen.height/4), "Tricycle"))
        {
            mm.GetComponent<MultiplayerManager>().thisKart = "tricycle";
        }
        if (GUI.Button(new Rect((7f*Screen.width)/20, (4*Screen.height)/10, (3f*Screen.width)/10, Screen.height/4), "Dirtbike"))
        {
            mm.GetComponent<MultiplayerManager>().thisKart = "dirtbike";
        }
        if (GUI.Button(new Rect((7f*Screen.width)/20, (Screen.height)/10, (3f*Screen.width)/10, Screen.height/4), "Arena Kart"))
        {
            mm.GetComponent<MultiplayerManager>().thisKart = "kart";
        }
        if (GUI.Button(new Rect((13.5f*Screen.width)/20, (Screen.height)/10, (3f*Screen.width)/10, Screen.height/4), "--no vehicle--"))
        {
            mm.GetComponent<MultiplayerManager>().thisKart = "kart";
        }
        if (GUI.Button(new Rect((13.5f*Screen.width)/20, (4*Screen.height)/10, (3f*Screen.width)/10, Screen.height/4), "--no vehicle--"))
        {
            mm.GetComponent<MultiplayerManager>().thisKart = "kart";
        }
        if (GUI.Button(new Rect((13.5f*Screen.width)/20, (7*Screen.height)/10, (3f*Screen.width)/10, Screen.height/4), "--no vehicle--"))
        {
            mm.GetComponent<MultiplayerManager>().thisKart = "kart";
        }
    }

    private void Menu_Host()
    {
        if (GUI.Button(new Rect(Screen.width/10, (7*Screen.height)/10, (4*Screen.width)/10, Screen.height/4), "Back"))
        {
            NavigateTo("Main");
        }
    }

    private void Menu_Options()
    {
        if (GUI.Button(new Rect(Screen.width/10, (7*Screen.height)/10, (4*Screen.width)/10, Screen.height/4), "Back"))
        {
            NavigateTo("Main");
        }
    }
 
    /*private void Menu_HostGame()
    {
        //Buttons Host Game
        if (GUI.Button(new Rect(10, 10, 200, 50), "Back"))
        {
            NavigateTo("Main");
        }
 
        if (GUI.Button(new Rect(10, 60, 200, 50), "Start Server"))
        {
            MultiplayerManager.instance.StartServer(MatchName, MatchPassword, MatchMaxPlayers);
        }
 
        if (GUI.Button(new Rect(10, 160, 200, 50), "Choose Map"))
        {
            NavigateTo("ChoMap");
        }
 
        GUI.Label(new Rect(220, 10, 130, 30), "Match Name");
        MatchName = GUI.TextField(new Rect(400, 10, 200, 30), MatchName);
 
        GUI.Label(new Rect(220, 50, 130, 30), "Match Password");
        MatchPassword = GUI.PasswordField(new Rect(400, 50, 200, 30), MatchPassword, '*');
 
        GUI.Label(new Rect(220, 90, 130, 30), "Match Max Players");
        GUI.Label(new Rect(400, 90, 200, 30), (MatchMaxPlayers + 1).ToString());
        MatchMaxPlayers = Mathf.Clamp(MatchMaxPlayers, 8, 31);
 
        if (GUI.Button(new Rect(425, 90, 30, 20), "+"))
            MatchMaxPlayers += 2;
        if (GUI.Button(new Rect(455, 90, 30, 20), "-"))
            MatchMaxPlayers -= 2;
 
        GUI.Label(new Rect(650, 10, 130, 30), MultiplayerManager.instance.CurrentMap.MapName);
    }
 
    private void Menu_Lobby()
    {
        ScrollLobby = GUILayout.BeginScrollView(ScrollLobby, GUILayout.MaxWidth(200));
 
        foreach (MPPlayer pl in MultiplayerManager.instance.PlayerList)
        {
            if (pl.PlayerNetwork == Network.player)
                GUI.color = Color.blue;
            GUILayout.Box(pl.PlayerName);
            GUI.color = Color.white;
        }
 
        GUILayout.EndScrollView();
 
        GUI.Box(new Rect(250, 10, 200, 40), MultiplayerManager.instance.CurrentMap.MapName);
 
        if (Network.isServer)
        {
            if (GUI.Button(new Rect(Screen.width - 200, Screen.height - 80, 200, 40), "Start Match"))
            {
                MultiplayerManager.instance.networkView.RPC("Client_LoadMultiplayerMap", RPCMode.AllBuffered, MultiplayerManager.instance.CurrentMap.MapLoadName, MultiplayerManager.instance.oldprefix + 1);
                MultiplayerManager.instance.oldprefix += 1;
                MultiplayerManager.instance.IsMatchStarted = true;
            }
        }
        if (GUI.Button(new Rect(Screen.width - 200, Screen.height - 40, 200, 40), "Disconnect"))
        {
            Network.Disconnect();
        }
    }
 
    private void Menu_ChooseMap()
    {
        if (GUI.Button(new Rect(10, 10, 200, 50), "Back"))
        {
            NavigateTo("Host");
        }
 
        GUI.Label(new Rect(220, 10, 130, 30), "Choose Map");
        GUILayout.BeginArea(new Rect(350, 10, 150, Screen.height));
 
        foreach(MapSetting map in MultiplayerManager.instance.MapList)
        {
            if (GUILayout.Button(map.MapName))
            {
                NavigateTo("Host");
                MultiplayerManager.instance.CurrentMap = map;
            }
        }
 
        GUILayout.EndArea();
    }
 
    void OnServerInitialized()
    {
        NavigateTo("Lobby");
    }
 
    void OnConnectedToServer()
    {
        NavigateTo("Lobby");
    }
 
    void OnDisconnectedFromServer(NetworkDisconnection info)
    {
        NavigateTo("Main");
    }*/
}