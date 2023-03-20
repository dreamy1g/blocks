using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntructionManager : MonoBehaviour
{
    private BlockSystem blockSys;
    private BuildSystem buildSys;
    private GridManager gridSys;
    private LevelBuilder levelSys;
    private PlayerSpawner playerSpawnSys;
    private PlayerItem playerItemSys;

    public GameObject ArchitectInstructionUI;
    public GameObject BuilderInstructionUI;

    private void Awake()
    {
        blockSys = GetComponent<BlockSystem>();
        buildSys = GetComponent<BuildSystem>();
        gridSys = GetComponent<GridManager>();
        levelSys = GetComponent<LevelBuilder>();
        playerSpawnSys = GetComponent<PlayerSpawner>();
        playerItemSys = GetComponent<PlayerItem>();
    }


    public void BuilderInstruction()
    {
        if (playerSpawnSys.playerPrefabs[0].transform.name == playerSpawnSys.playerToSpawn.name)
        {
            BuilderInstructionUI.SetActive(true);
        }

    }


    public void ArchitectInstruction()
    {
        if (playerSpawnSys.playerPrefabs[1].transform.name == playerSpawnSys.playerToSpawn.name)
        {
            ArchitectInstructionUI.SetActive(true);
        }

    }



    private void Update()
    {
        BuilderInstruction();
        ArchitectInstruction();
    }

}
