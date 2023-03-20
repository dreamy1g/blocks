using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class BuildSystem : MonoBehaviour
{
    private BlockSystem blockSys;
    private GridManager gridSys;
    private GameManager gameSys;
    private LevelBuilder levelSys;
    private lv2 level2Sys;
    private lv3 level3Sys;
    private lv4 level4Sys;
    private lv5 level5Sys;
    private lv6 level6Sys;
    private PlayerSpawner playerSpawnSys;
    private PlayerItem playerItemSys;

    private int currentBlockID = 0;
    private Block currentBlock;

    private int selectableBlocksTotal;

    private GameObject blockTemplate;
    private SpriteRenderer currentRend;

    public bool buildModeOn = false;
    private bool buildBlocked = false;

    [SerializeField]
    private float blockSizeMod;

    [SerializeField]
    private LayerMask noBuildLayer;

    [SerializeField]
    private LayerMask allBlocksLayer;

    public bool score = false;

    private Vector2[] posBlock;

    Vector2 Vec;

    PhotonView view;

    public GameObject[] prefabs;

    public static bool PlanIsOpened = false;
    public GameObject planUI;





    private void Start()
    {
        view = GetComponent<PhotonView>();
        
    }

    private void Awake()
    {
        blockSys = GetComponent<BlockSystem>();
        gridSys = GetComponent<GridManager>();
        gameSys = GetComponent<GameManager>();
        levelSys = GetComponent<LevelBuilder>();
        level2Sys = GetComponent<lv2>();
        level3Sys = GetComponent<lv3>();
        level4Sys = GetComponent<lv4>();
        level5Sys = GetComponent<lv5>();
        level6Sys = GetComponent<lv6>();
        playerSpawnSys = GetComponent<PlayerSpawner>();
        playerItemSys = GetComponent<PlayerItem>();
        posBlock = new Vector2[120];
        Vec = new Vector2(-160, -160);
        for (int i = 0; i < 120; i++)
        {
  
            posBlock[i].Set(-160, -160);
        }

    }

    private void Update()
    {
        
        

      if (playerSpawnSys.playerPrefabs[0].transform.name == playerSpawnSys.playerToSpawn.name)
      {

            if (Input.GetKeyDown("e"))
            {
                buildModeOn = !buildModeOn;

                if (blockTemplate != null)
                {
                    Destroy(blockTemplate);
                }

                if (currentBlock == null)
                {
                    if (blockSys.allBlocks[currentBlockID] != null)
                    {
                        currentBlock = blockSys.allBlocks[currentBlockID];
                    }
                }

                if (buildModeOn)
                {
                    blockTemplate = new GameObject("CurrentBlockTemplate");
                    currentRend = blockTemplate.AddComponent<SpriteRenderer>();
                    currentRend.sprite = currentBlock.blockSprite;
                }
            }
       }

        if (buildModeOn && blockTemplate != null)
        {
            float newPosX = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x / blockSizeMod) * blockSizeMod;
            float newPosY = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).y / blockSizeMod) * blockSizeMod;
            blockTemplate.transform.position = new Vector2(newPosX, newPosY);

            RaycastHit2D rayHit = new RaycastHit2D();

            if (currentBlock.isSolid == true)
            {
                rayHit = Physics2D.Raycast(blockTemplate.transform.position, Vector2.zero, Mathf.Infinity, noBuildLayer);
            }
            

            if (rayHit.collider != null)
            {
                buildBlocked = true;
            }
            else
            {
                buildBlocked = false;
            }


            if (buildBlocked)
            {
                currentRend.color = new Color(1f, 0f, 0f, 1f);
            }
            else
            {
                currentRend.color = new Color(1f, 1f, 1f, 1f);
            }

            float mouseWheel = Input.GetAxis("Mouse ScrollWheel");

            if (mouseWheel != 0)
            {
                selectableBlocksTotal = blockSys.allBlocks.Length - 1;

                if (mouseWheel > 0)
                {
                    currentBlockID--;

                    if (currentBlockID < 0)
                    {
                        currentBlockID = selectableBlocksTotal;
                    }
                }
                else if (mouseWheel < 0)
                {
                    currentBlockID++;

                    if (currentBlockID > selectableBlocksTotal)
                    {
                        currentBlockID = 0;
                    }
                }

                currentBlock = blockSys.allBlocks[currentBlockID];
                currentRend.sprite = currentBlock.blockSprite;
            }
            
                if (Input.GetMouseButtonDown(0) && buildBlocked == false)
                {

                    PhotonNetwork.Instantiate(prefabs[0].name, new Vector2(newPosX, newPosY), Quaternion.identity, 0);
                    FindObjectOfType<AudioManager>().Play("Block");
                /*
                                    GameObject newBlock = new GameObject(currentBlock.blockName);
                                    newBlock.transform.position = blockTemplate.transform.position;
                                    SpriteRenderer newRend = newBlock.AddComponent<SpriteRenderer>();
                                    newRend.sprite = currentBlock.blockSprite;
                                    if (currentBlock.isSolid == true)
                                    {
                                        newBlock.AddComponent<BoxCollider2D>();
                                        newBlock.layer = 10;
                                        newBlock.AddComponent<PhotonView>();
                                        newBlock.AddComponent<PhotonTransformViewClassic>();
                                        newRend.sortingOrder = -10;

                                    }
                    
               */

                    float vecx = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x / blockSizeMod) * blockSizeMod;
                    float vecy = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).y / blockSizeMod) * blockSizeMod;

                    for (int i = 0; i < posBlock.Length; i++)
                    {
                        if (posBlock[i] == Vec)
                        {
                            posBlock[i] = new Vector2(vecx, vecy);
                            break;
                        }

                    }

                }

        
        }

        if (playerSpawnSys.playerPrefabs[0].transform.name == playerSpawnSys.playerToSpawn.name)
        {
            if (Input.GetKeyDown("r"))
            {
                Scene currentScene = SceneManager.GetActiveScene();
                string sceneName = currentScene.name;


                Vector2 Vecmin;
                Vecmin = new Vector2(0, 12);
                int count = 0;
                int count1 = 0;


                if (sceneName == "level1")
                {


                    for (int i = 0; i < posBlock.Length; i++)
                    {

                        for (int j = 0; j < levelSys.tabBuild.Length; j++)
                        {
                            if (posBlock[i] == levelSys.tabBuild[j] + Vecmin)
                            {

                                count++;

                            }

                        }

                        if (posBlock[i] != Vec)
                        {
                            count1++;
                        }

                    }

                    if (count == levelSys.tabBuild.Length && count1 == levelSys.tabBuild.Length)
                    {
                        score = true;
                        Debug.Log("wygrales");
                        Debug.Log(count);
                        Debug.Log(count1);
                    }
                    else
                    {
                        score = false;
                        Debug.Log("Przegrales");
                        Debug.Log(count);
                        Debug.Log(count1);

                    }

                }

                if (sceneName == "level2")
                {


                    for (int i = 0; i < posBlock.Length; i++)
                    {

                        for (int j = 0; j < level2Sys.tabBuild.Length; j++)
                        {
                            if (posBlock[i] == level2Sys.tabBuild[j] + Vecmin)
                            {

                                count++;

                            }

                        }

                        if (posBlock[i] != Vec)
                        {
                            count1++;
                        }

                    }

                    if (count == level2Sys.tabBuild.Length && count1 == level2Sys.tabBuild.Length)
                    {
                        score = true;
                        Debug.Log("wygrales");
                        Debug.Log(count);
                        Debug.Log(count1);
                    }
                    else
                    {
                        score = false;
                        Debug.Log("Przegrales");
                        Debug.Log(count);
                        Debug.Log(count1);

                    }

                }

                if (sceneName == "level3")
                {


                    for (int i = 0; i < posBlock.Length; i++)
                    {

                        for (int j = 0; j < level3Sys.tabBuild.Length; j++)
                        {
                            if (posBlock[i] == level3Sys.tabBuild[j] + Vecmin)
                            {

                                count++;

                            }

                        }

                        if (posBlock[i] != Vec)
                        {
                            count1++;
                        }

                    }

                    if (count == level3Sys.tabBuild.Length && count1 == level3Sys.tabBuild.Length)
                    {
                        score = true;
                        Debug.Log("wygrales");
                        Debug.Log(count);
                        Debug.Log(count1);
                    }
                    else
                    {
                        score = false;
                        Debug.Log("Przegrales");
                        Debug.Log(count);
                        Debug.Log(count1);

                    }

                }

                if (sceneName == "level4")
                {


                    for (int i = 0; i < posBlock.Length; i++)
                    {

                        for (int j = 0; j < level4Sys.tabBuild.Length; j++)
                        {
                            if (posBlock[i] == level4Sys.tabBuild[j] + Vecmin)
                            {

                                count++;

                            }

                        }

                        if (posBlock[i] != Vec)
                        {
                            count1++;
                        }

                    }

                    if (count == level4Sys.tabBuild.Length && count1 == level4Sys.tabBuild.Length)
                    {
                        score = true;
                        Debug.Log("wygrales");
                        Debug.Log(count);
                        Debug.Log(count1);
                    }
                    else
                    {
                        score = false;
                        Debug.Log("Przegrales");
                        Debug.Log(count);
                        Debug.Log(count1);

                    }

                }

                if (sceneName == "level5")
                {


                    for (int i = 0; i < posBlock.Length; i++)
                    {

                        for (int j = 0; j < level5Sys.tabBuild.Length; j++)
                        {
                            if (posBlock[i] == level5Sys.tabBuild[j] + Vecmin)
                            {

                                count++;

                            }

                        }

                        if (posBlock[i] != Vec)
                        {
                            count1++;
                        }

                    }

                    if (count == level5Sys.tabBuild.Length && count1 == level5Sys.tabBuild.Length)
                    {
                        score = true;
                        Debug.Log("wygrales");
                        Debug.Log(count);
                        Debug.Log(count1);
                    }
                    else
                    {
                        score = false;
                        Debug.Log("Przegrales");
                        Debug.Log(count);
                        Debug.Log(count1);

                    }

                }

                if (sceneName == "level6")
                {


                    for (int i = 0; i < posBlock.Length; i++)
                    {

                        for (int j = 0; j < level6Sys.tabBuild.Length; j++)
                        {
                            if (posBlock[i] == level6Sys.tabBuild[j] + Vecmin)
                            {

                                count++;

                            }

                        }

                        if (posBlock[i] != Vec)
                        {
                            count1++;
                        }

                    }

                    if (count == level6Sys.tabBuild.Length && count1 == level6Sys.tabBuild.Length)
                    {
                        score = true;
                        Debug.Log("wygrales");
                        Debug.Log(count);
                        Debug.Log(count1);
                    }
                    else
                    {
                        score = false;
                        Debug.Log("Przegrales");
                        Debug.Log(count);
                        Debug.Log(count1);

                    }

                }

            }

        }

        if (playerSpawnSys.playerPrefabs[1].transform.name == playerSpawnSys.playerToSpawn.name)
        {
            if (Input.GetKeyDown("e"))
            {
                if (PlanIsOpened)
                {
                    planClose();
                }
                else
                {
                    FindObjectOfType<AudioManager>().Play("Plan");
                    planOpen();
                }
            }
        }


        if (Input.GetMouseButtonDown(1) && blockTemplate != null)
            {
                RaycastHit2D destroyHit = Physics2D.Raycast(blockTemplate.transform.position, Vector2.zero, Mathf.Infinity, allBlocksLayer);
                
                    

                if (destroyHit.collider !=null)
                {
               
                PhotonNetwork.Destroy(destroyHit.collider.gameObject);

                float vecx = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x / blockSizeMod) * blockSizeMod;
                float vecy = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).y / blockSizeMod) * blockSizeMod;
                Vector2 destroyer = new Vector2(vecx, vecy);

                for(int i=0; i<posBlock.Length; i++)
                {

                    if(posBlock[i]==destroyer)
                     {
                        posBlock[i] = Vec;
                     }

                 
                }
            }
            }

            
        }

    public void planClose()
    {

        planUI.SetActive(false);
        PlanIsOpened = false;
    }

    void planOpen()
    {
        planUI.SetActive(true);
        PlanIsOpened = true;
    }


}
