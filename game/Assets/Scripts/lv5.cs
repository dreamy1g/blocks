using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class lv5 : MonoBehaviour
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
        tabBuild[0].Set(2, -12);
        tabBuild[1].Set(9, -12);
        tabBuild[2].Set(3, -11);
        tabBuild[3].Set(8, -11);
        tabBuild[4].Set(5, -10);
        tabBuild[5].Set(6, -10);
        tabBuild[6].Set(1, -9);
        tabBuild[7].Set(2, -9);
        tabBuild[8].Set(4, -9);
        tabBuild[9].Set(7, -9);
        tabBuild[10].Set(9, -9);
        tabBuild[11].Set(10, -9);
        tabBuild[12].Set(4, -8);
        tabBuild[13].Set(7, -8);
        tabBuild[14].Set(5, -7);
        tabBuild[15].Set(6, -7);
        tabBuild[16].Set(3, -6);
        tabBuild[17].Set(8, -6);
        tabBuild[18].Set(2, -5);
        tabBuild[19].Set(9, -5);

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
