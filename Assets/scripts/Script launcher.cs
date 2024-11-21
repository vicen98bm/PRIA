using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView playerPrefab;
    public Transform spawnPoint; 
    void Start()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }
    public override void OnConnectedToMaster()
    {  
        Debug.Log("Nos hemos conectado al Master");
    }
    public override void OnJoinedRoom()
    {
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
        player.GetComponent<PhotonView>().RPC("SetNameText", RpcTarget.AllBuffered, PlayerPrefs.GetString("PlayerName"));

        PlayerColor playerColor = player.GetComponent<PlayerColor>();
        if (playerColor != null)
        {
            playerColor.ChangeColor(); 
        }
    } 
}
