using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    private BlockSystem blockSys;
    private BuildSystem buildSys;
    private GridManager gridSys;
    private LevelBuilder levelSys;

    PhotonView view;


    public GameObject completeLevelUI;
    

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }


    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        blockSys = GetComponent<BlockSystem>();
        buildSys = GetComponent<BuildSystem>();
        gridSys = GetComponent<GridManager>();
        levelSys = GetComponent<LevelBuilder>();

    }

    

    public void CompleteLevel()
    {
        
        if (buildSys.score == true)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                Debug.Log("winek");

                completeLevelUI.SetActive(true);
            }
            else
            {
               PhotonNetwork.Instantiate(completeLevelUI.name, new Vector2(0, 0), Quaternion.identity);
            }
         

        }
    }

    private void Update()
    {
        CompleteLevel();
    }

}
   
 
