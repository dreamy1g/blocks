using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BlockSystem : MonoBehaviour
{

  [SerializeField] 
  private Sprite[] blockSprites;
  [SerializeField] 
  private string[] blockNames;
  [SerializeField]
  private GameObject[] blockPrefabs;


    public Block[] allBlocks;


    PhotonView view;


    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    private void Awake()
    {
        allBlocks = new Block[blockSprites.Length];


        int newBlockID = 0;

        for(int i = 0; i <blockSprites.Length; i++)
        {
            allBlocks[newBlockID] = new Block(newBlockID, blockNames[i], blockSprites[i], true, blockPrefabs[i]);
            Debug.Log("Block: allBlocks[" + newBlockID + "] = " + blockSprites[i]);
            newBlockID++;
        }
    }
}

public class Block
{
    public int blockID;
    public string blockName;
    public Sprite blockSprite;
    public bool isSolid;
    public GameObject blockPrefab;


    public Block(int id, string name, Sprite sprite, bool meSolid,GameObject prefab)
    {
        blockID = id;
        blockName = name;
        blockSprite = sprite;
        isSolid = meSolid;
        blockPrefab = prefab;
    }
}
