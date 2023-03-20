using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    
    public GameObject[] playerPrefabs = null;
    public Transform[] spawnPoints;
    public GameObject playerToSpawn = null;

    private PlayerItem playerItemSys;




    private void Start()
    {

        playerItemSys = GetComponent<PlayerItem>();

        int randomNumber = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomNumber];
        

        if (PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"] == null)
        {
            playerToSpawn = playerPrefabs[0];
        }
        else
        {
            playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        }
        

       // PhotonNetwork.
            Instantiate(playerToSpawn, spawnPoint.position, Quaternion.identity);

        if (PhotonNetwork.IsMasterClient)
            {
                
            }
        else if (playerPrefabs[0].transform.name == playerToSpawn.name)
            {
                PhotonNetwork.SetMasterClient(PhotonNetwork.MasterClient.GetNext());
            }
            
        
    }


}
