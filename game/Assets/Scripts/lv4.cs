using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class lv4 : MonoBehaviour
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
        tabBuild = new Vector2[12];
        tabBuild[0].Set(4, -11);
        tabBuild[1].Set(5, -11);
        tabBuild[2].Set(6, -11);
        tabBuild[3].Set(7, -11);
        tabBuild[4].Set(3, -10);
        tabBuild[5].Set(8, -10);
        tabBuild[6].Set(3, -9);
        tabBuild[7].Set(5, -9);
        tabBuild[8].Set(6, -9);
        tabBuild[9].Set(8, -9);
        tabBuild[10].Set(4, -7);
        tabBuild[11].Set(7, -7);

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
