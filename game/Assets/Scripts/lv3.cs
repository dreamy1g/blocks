using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class lv3 : MonoBehaviour
{

    [SerializeField]
    private Square squarePrefab;

    private Dictionary<Vector2, Square> tiles3;

    public Vector2[] tabBuild;


    PhotonView view;


    private void Start()
    {
        view = GetComponent<PhotonView>();
        CreateLevel();
    }


    private void Awake()
    {
        tabBuild = new Vector2[20];
        tabBuild[0].Set(4, -12);
        tabBuild[1].Set(7, -12);
        tabBuild[2].Set(5, -11);
        tabBuild[3].Set(6, -11);
        tabBuild[4].Set(5, -10);
        tabBuild[5].Set(6, -10);
        tabBuild[6].Set(3, -10);
        tabBuild[7].Set(8, -10);
        tabBuild[8].Set(3, -9);
        tabBuild[9].Set(4, -9);
        tabBuild[10].Set(5, -9);
        tabBuild[11].Set(6, -9);
        tabBuild[12].Set(7, -9);
        tabBuild[13].Set(8, -9);
        tabBuild[14].Set(5, -8);
        tabBuild[15].Set(6, -8);
        tabBuild[16].Set(5, -7);
        tabBuild[17].Set(6, -7);
        tabBuild[18].Set(4, -6);
        tabBuild[19].Set(7, -6);

    }



    void CreateLevel()
    {
        tiles3 = new Dictionary<Vector2, Square>();


        for (int z = 0; z < tabBuild.Length; z++)
        {

            var spawnedTile3 = Instantiate(squarePrefab, new Vector3(tabBuild[z][0], tabBuild[z][1]), Quaternion.identity);
            spawnedTile3.name = "Square";


            spawnedTile3.Init(false);
            tiles3[new Vector2(tabBuild[z][0], tabBuild[z][1])] = spawnedTile3;

        }
    }


}
