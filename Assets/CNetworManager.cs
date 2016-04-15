using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
namespace SnakeGame
{
    public class CNetworManager : NetworkManager
    {

        private static CNetworManager instance;

        void Awake()
        {
            instance = this;
        }

        public static CNetworManager Instance
        {
            get {
                return instance;
            }
        }


        #region parentProperty
        //
        // Summary:
        //     ///
        //     The name of the current network scene.
        //     ///
        //public static string networkSceneName;

        //
        // Summary:
        //     ///
        //     The NetworkManager singleton object.
        //     ///
        //public static NetworkManager singleton;

        //
        // Summary:
        //     ///
        //     The current NetworkClient being used by the manager.
        //     ///
        //public NetworkClient client;

        //
        // Summary:
        //     ///
        //     True if the NetworkServer or NetworkClient isactive.
        //     ///
        //public bool isNetworkActive;

        //
        // Summary:
        //     ///
        //     The list of matches that are available to join.
        //     ///
        //public List<MatchDesc> matches;

        //
        // Summary:
        //     ///
        //     A MatchInfo instance that will be used when StartServer() or StartClient() are
        //     called.
        //     ///
        //public MatchInfo matchInfo;

        //
        // Summary:
        //     ///
        //     The UMatch matchmaker object.
        //     ///
        //public NetworkMatch matchMaker;

        //
        // Summary:
        //     ///
        //     The name of the current match.
        //     ///
        //public string matchName;

        //
        // Summary:
        //     ///
        //     The maximum number of players in the current match.
        //     ///
        //public uint matchSize;


        // public NetworkManager();

        //
        // Summary:
        //     ///
        //     A flag to control whether or not player objects are automatically created on
        //     connect, and on scene change.
        //     ///
        //public bool autoCreatePlayer { get; set; }

        //
        // Summary:
        //     ///
        //     The Quality-of-Service channels to use for the network transport layer.
        //     ///
        //public List<QosType> channels { get; }

        //
        // Summary:
        //     ///
        //     This is true if the client loaded a new scene when connecting to the server.
        //     ///
        //public bool clientLoadedScene { get; set; }

        //
        // Summary:
        //     ///
        //     The custom network configuration to use.
        //     ///
        //public ConnectionConfig connectionConfig { get; }

        //
        // Summary:
        //     ///
        //     Flag to enable custom network configuration.
        //     ///
        //public bool customConfig { get; set; }

        //
        // Summary:
        //     ///
        //     A flag to control whether the NetworkManager object is destroyed when the scene
        //     changes.
        //     ///
        //public bool dontDestroyOnLoad { get; set; }

        //
        // Summary:
        //     ///
        //     The transport layer global configuration to be used.
        //     ///
        //public GlobalConfig globalConfig { get; }

        //
        // Summary:
        //     ///
        //     The log level specifically to user for network log messages.
        //     ///
        //public LogFilter.FilterLevel logLevel { get; set; }

        //
        // Summary:
        //     ///
        //     The hostname of the matchmaking server.
        //     ///
        //public string matchHost { get; set; }

        //
        // Summary:
        //     ///
        //     The port of the matchmaking service.
        //     ///
        //public int matchPort { get; set; }

        //
        // Summary:
        //     ///
        //     The maximum number of concurrent network connections to support.
        //     ///
        //public int maxConnections { get; set; }

        //
        // Summary:
        //     ///
        //     The maximum delay before sending packets on connections.
        //     ///
        //public float maxDelay { get; set; }

        //
        // Summary:
        //     ///
        //     The migration manager being used with the NetworkManager.
        //     ///
        //public NetworkMigrationManager migrationManager { get; }

        //
        // Summary:
        //     ///
        //     The network address currently in use.
        //     ///
        //public string networkAddress { get; set; }

        //
        // Summary:
        //     ///
        //     The network port currently in use.
        //     ///
        //public int networkPort { get; set; }


        //
        // Summary:
        //     ///
        //     NumPlayers is the number of active player objects across all connections on the
        //     server.
        //     ///
        //public int numPlayers { get; }

        //
        // Summary:
        //     ///
        //     The scene to switch to when offline.
        //     ///
        //public string offlineScene { get; set; }

        //
        // Summary:
        //     ///
        //     The scene to switch to when online.
        //     ///
        //public string onlineScene { get; set; }

        //
        // Summary:
        //     ///
        //     The percentage of incoming and outgoing packets to be dropped for clients.
        //     ///
        //public float packetLossPercentage { get; set; }

        //
        // Summary:
        //     ///
        //     The default prefab to be used to create player objects on the server.
        //     ///
        //public GameObject playerPrefab { get; set; }

        //
        // Summary:
        //     ///
        //     The current method of spawning players used by the NetworkManager.
        //     ///
        //public PlayerSpawnMethod playerSpawnMethod { get; set; }

        //
        // Summary:
        //     ///
        //     Controls whether the program runs when it is in the background.
        //     ///
        //public bool runInBackground { get; set; }

        //
        // Summary:
        //     ///
        //     Flag for using the script CRC check between server and clients.
        //     ///
        //public bool scriptCRCCheck { get; set; }

        //
        // Summary:
        //     ///
        //     Allows you to specify an EndPoint object instead of setting networkAddress and
        //     networkPort (required for some platforms such as Xbox One).
        //     ///
        //public EndPoint secureTunnelEndpoint { get; set; }

        //
        // Summary:
        //     ///
        //     A flag to control sending the network information about every peer to all members
        //     of a match.
        //     ///
        //[Obsolete("moved to NetworkMigrationManager")]
        //public bool sendPeerInfo { get; set; }

        //
        // Summary:
        //     ///
        //     The IP address to bind the server to.
        //     ///
        //public string serverBindAddress { get; set; }

        //
        // Summary:
        //     ///
        //     Flag to tell the server whether to bind to a specific IP address.
        //     ///
        //public bool serverBindToIP { get; set; }

        //
        // Summary:
        //     ///
        //     The delay in milliseconds to be added to incoming and outgoing packets for clients.
        //     ///
        //public int simulatedLatency { get; set; }

        //
        // Summary:
        //     ///
        //     List of prefabs that will be registered with the spawning system.
        //     ///
        //public List<GameObject> spawnPrefabs { get; }

        //
        // Summary:
        //     ///
        //     The list of currently registered player start positions for the current scene.
        //     ///
        //public List<Transform> startPositions { get; }

        //
        // Summary:
        //     ///
        //     Flag that control whether clients started by this NetworkManager will use simulated
        //     latency and packet loss.
        //     ///
        //public bool useSimulator { get; set; }

        //
        // Summary:
        //     ///
        //     This makes the NetworkServer listen for WebSockets connections instead of normal
        //     transport layer connections.
        //     ///
        //public bool useWebSockets { get; set; }


        //
        // Summary:
        //     ///
        //     Registers the transform of a game object as a player spawn location.
        //     ///
        //
        // Parameters:
        //   start:
        //     Transform to register.
        //public static void RegisterStartPosition(Transform start);

        //
        // Summary:
        //     ///
        //     Shuts down the NetworkManager completely and destroy the singleton.
        //     ///
        //public static void Shutdown();

        //
        // Summary:
        //     ///
        //     Unregisters the transform of a game object as a player spawn location.
        //     ///
        //
        // Parameters:
        //   start:
        //public static void UnRegisterStartPosition(Transform start);

        //
        // Summary:
        //     ///
        //     This finds a spawn position based on NetworkStartPosition objects in the scene.
        //     ///
        //
        // Returns:
        //     ///
        //     Returns the transform to spawn a player at, or null.
        //     ///
        //public Transform GetStartPosition();

        //
        // Summary:
        //     ///
        //     This checks if the NetworkManager has a client and that it is connected to a
        //     server.
        //     ///
        //
        // Returns:
        //     ///
        //     True if the NetworkManagers client is connected to a server.
        //     ///
        //public bool IsClientConnected();


        //
        // Summary:
        //     ///
        //     This is invoked when a match is joined.
        //     ///
        //
        // Parameters:
        //   matchInfo:
        //public void OnMatchJoined(JoinMatchResponse matchInfo);

        //
        // Summary:
        //     ///
        //     This starts a network client. It uses the networkAddress and networkPort properties
        //     as the address to connect to.
        //     ///
        //
        // Returns:
        //     ///
        //     The client object created.
        //     ///
        //public NetworkClient StartClient();
        //public NetworkClient StartClient(MatchInfo matchInfo);
        //public NetworkClient StartClient(MatchInfo info, ConnectionConfig config);
        //
        // Summary:
        //     ///
        //     This starts a network "host" - a server and client in the same application.
        //     ///
        //
        // Returns:
        //     ///
        //     The client object created - this is a "local client".
        //     ///
        //public virtual NetworkClient StartHost();
        //public virtual NetworkClient StartHost(MatchInfo info);
        //public virtual NetworkClient StartHost(ConnectionConfig config, int maxConnections);
        //
        // Summary:
        //     ///
        //     This starts a new server.
        //     ///
        //
        // Returns:
        //     ///
        //     True is the server was started.
        //     ///
        // public bool StartServer();
        // public bool StartServer(MatchInfo info);
        //public bool StartServer(ConnectionConfig config, int maxConnections);
        //
        // Summary:
        //     ///
        //     Stops the client that the manager is using.
        //     ///
        //public void StopClient();
        //
        // Summary:
        //     ///
        //     This stops both the client and the server that the manager is using.
        //     ///
        //public void StopHost();
        //
        // Summary:
        //     ///
        //     Stops the matchmaker that the NetworkManager is using.
        //     ///
        // public void StopMatchMaker();
        //
        // Summary:
        //     ///
        //     Stops the server that the manager is using.
        //     ///
        //public void StopServer();
        //
        // Summary:
        //     ///
        //     This allows the NetworkManager to use a client object created externally to the
        //     NetworkManager instead of using StartClient().
        //     ///
        //
        // Parameters:
        //   externalClient:
        //     The NetworkClient object to use.
        //public void UseExternalClient(NetworkClient externalClient);
        #endregion

        /// <summary>
        /// Called on the client when connected to a server.
        /// </summary>
        /// <param name="conn">Connection to the server.</param>
        public override void OnClientConnect(NetworkConnection conn)
        {

        }

        public override void OnClientDisconnect(NetworkConnection conn)
        {

        }

        /// <summary>
        ///  Called on clients when a network error occurs.
        /// </summary>
        /// <param name="conn"> Connection to a server.</param>
        /// <param name="errorCode">Error code.</param>
        public override  void OnClientError(NetworkConnection conn, int errorCode)
        {

        }

        /// <summary>
        /// Called on clients when a servers tells the client it is no longer ready.
        /// </summary>
        /// <param name="conn">Connection to a server.</param>
        public override void OnClientNotReady(NetworkConnection conn)
        {

        }

        /// <summary>
        /// Called on clients when a scene has completed loaded, when the scene load was     initiated by the server.
        /// </summary>
        /// <param name="conn">The network connection that the scene change message arrived on.</param>
        public override void OnClientSceneChanged(NetworkConnection conn)
        {

        }

        /// <summary>
        /// Called on the server when a client adds a new player with ClientScene.AddPlayer.
        /// </summary>
        /// <param name="conn">Connection from client.</param>
        /// <param name="playerControllerId"> Id of the new player.</param>
        ///  <param name="extraMessageReader">  An extra message object passed for the new player.</param>
        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
        {

        }

        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
        {

        }

        /// <summary>
        /// Called on the server when a new client connects.
        /// </summary>
        /// <param name="conn"> Connection from client.</param>
        public override void OnServerConnect(NetworkConnection conn)
        {
            Debug.Log("OnServerConnect");
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {

        }

        /// <summary>
        /// Called on the server when a network error occurs for a client connection.
        /// </summary>
        /// <param name="conn">Connection from client.</param>
        /// <param name="errorCode"></param>
        public override void OnServerError(NetworkConnection conn, int errorCode)
        {

        }

        /// <summary>
        /// Called on the server when a client is ready.
        /// </summary>
        /// <param name="conn"> Connection from client.</param>
        public override void OnServerReady(NetworkConnection conn)
        {

        }

        /// <summary>
        ///  Called on the server when a client removes a player.
        /// </summary>
        /// <param name="conn">The connection to remove the player from.</param>
        /// <param name="player"> The player controller to remove.</param>
        public override void OnServerRemovePlayer(NetworkConnection conn, PlayerController player)
        {

        }

        /// <summary>
        /// Called on the server when a scene is completed loaded, when the scene load was initiated by the server with ServerChangeScene().
        /// </summary>
        /// <param name="sceneName">The name of the new scene.</param>
        public override void OnServerSceneChanged(string sceneName)
        {

        }

        /// <summary>
        /// This is a hook that is invoked when the client is started.
        /// </summary>
        /// <param name="client"></param>
        public override void OnStartClient(NetworkClient client)
        {

        }
        //
        // Summary:
        //     ///
        //     This hook is invoked when a host is started.
        //     ///
        public override void OnStartHost()
        {

        }
        //
        // Summary:
        //     ///
        //     This hook is invoked when a server is started - including when a host is started.
        //     ///
        public override void OnStartServer()
        {
            ClitherServer.getInstance().run();
            //ClitherServer
        }
        //
        // Summary:
        //     ///
        //     This hook is called when a client is stopped.
        //     ///
        public override void OnStopClient()
        {

        }
        //
        // Summary:
        //     ///
        //     This hook is called when a host is stopped.
        //     ///
        public override void OnStopHost()
        {

        }
        //
        // Summary:
        //     ///
        //     This hook is called when a server is stopped - including when a host is stopped.
        //     ///
        public override void OnStopServer()
        {

        }

        /// <summary>
        /// This causes the server to switch scenes and sets the networkSceneName.
        /// </summary>
        /// <param name="newSceneName">The name of the scene to change to. The server will change scene immediately, and a message will be sent to connected clients to ask them to change scene also.</param>
        public override void ServerChangeScene(string newSceneName)
        {

        }

    }
}

