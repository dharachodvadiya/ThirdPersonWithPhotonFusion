using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, INetworkRunnerCallbacks
{
    public static Spawner instance;
    public GameObject playerPrefab;
    public Player myPlayer;

    public GamePlayManager gamePlayManager;

    private void OnEnable()
    {
         instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        gamePlayManager = FindAnyObjectByType<GamePlayManager>();
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        if(player == runner.LocalPlayer)
        {
            runner.Spawn(playerPrefab, Utils.GetRandomSpawnPoint(), Quaternion.identity, player);
            gamePlayManager.DisableLoading();
        }
           
       
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
      
    }

    public void OnConnectedToServer(NetworkRunner runner) { Debug.Log("OnConnectedToServer"); }
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player) { }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) {
        SceneChangeManager.Instance.LoadNextScreen(SceneChangeManager.EnumScene.Menu.ToString());
        Debug.Log("OnShutdown");
    }
    public void OnDisconnectedFromServer(NetworkRunner runner) { Debug.Log("OnDisconnectedFromServer"); }
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { Debug.Log("OnConnectRequest"); }
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { Debug.Log("OnConnectFailed"); }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) { }
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data) { }
    public void OnSceneLoadDone(NetworkRunner runner) { }
    public void OnSceneLoadStart(NetworkRunner runner) { }

}
