using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class lv6 : MonoBehaviour
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
        tabBuild = new Vector2[38];
        tabBuild[0].Set(3, -12);
        tabBuild[1].Set(8, -12);
        tabBuild[2].Set(3, -11);
        tabBuild[3].Set(5, -11);
        tabBuild[4].Set(8, -11);
        tabBuild[5].Set(10, -11);
        tabBuild[6].Set(3, -10);
        tabBuild[7].Set(5, -10);
        tabBuild[8].Set(8, -10);
        tabBuild[9].Set(10, -10);
        tabBuild[10].Set(3, -9);
        tabBuild[11].Set(4, -9);
        tabBuild[12].Set(5, -9);
        tabBuild[13].Set(6, -9);
        tabBuild[14].Set(7, -9);
        tabBuild[15].Set(8, -9);
        tabBuild[16].Set(9, -9);
        tabBuild[17].Set(10, -9);
        tabBuild[18].Set(2, -8);
        tabBuild[19].Set(3, -8);
        tabBuild[20].Set(4, -8);
        tabBuild[21].Set(5, -8);
        tabBuild[22].Set(6, -8);
        tabBuild[23].Set(7, -8);
        tabBuild[24].Set(8, -8);
        tabBuild[25].Set(9, -8);
        tabBuild[26].Set(10, -8);
        tabBuild[27].Set(1, -7);
        tabBuild[28].Set(2, -7);
        tabBuild[29].Set(5, -7);
        tabBuild[30].Set(6, -7);
        tabBuild[31].Set(7, -7);
        tabBuild[32].Set(8, -7);
        tabBuild[33].Set(1, -6);
        tabBuild[34].Set(2, -6);
        tabBuild[35].Set(6, -6);
        tabBuild[36].Set(7, -6);
        tabBuild[37].Set(2, -5);

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
