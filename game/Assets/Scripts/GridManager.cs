using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private int width;
    [SerializeField]
    private int height;

    [SerializeField]
    private Tile tilePrefab;


    [SerializeField]
    private Transform cam;
    [SerializeField]
    private Transform cam2;

    private Dictionary<Vector2, Tile> tiles;
    private Dictionary<Vector2, Tile> tiles2;


    PhotonView view;



    private void Awake()
    {

    }

    void Start()
    {
        GenerateGrid();
        view = GetComponent<PhotonView>();
    }

    void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();
        tiles2 = new Dictionary<Vector2, Tile>();
        

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                var spawnedTile2 = Instantiate(tilePrefab, new Vector3(x, y - 12), Quaternion.identity);
                spawnedTile2.name = $"Tile {x} {y}";


                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
                spawnedTile2.Init(isOffset);

                tiles[new Vector2(x, y)] = spawnedTile;
                tiles2[new Vector2(x, y - 12)] = spawnedTile2;


            }
        }

        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
        cam2.transform.position = new Vector3((float)width / 2 - 0.5f, (float)(height - 24) / 2 - 0.5f, -10);


    }




}
