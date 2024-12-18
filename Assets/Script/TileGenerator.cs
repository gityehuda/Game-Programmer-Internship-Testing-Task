using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [Header("Tile Settings")]
    public GameObject[] tilePrefab;
    private int gridWidth = 8;
    private int gridLength = 8;
    private float tileSize = 1.0f;
    private int index;
    public GameObject treeSpawmer;

    [Header("Offset")]
    public Vector3 gridOrigin = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        GenerateTile();
    }

    void GenerateTile()
    {
        if(tilePrefab == null)
        {
            Debug.LogError("Tile Prefab is not assigned");
            return;
        }

        for(int x = 0; x < gridWidth; x++)
        {
            for(int z = 0; z < gridLength; z++)
            {
                Vector3 position = gridOrigin + new Vector3(x * tileSize, 0, z * tileSize);
                index = Random.Range(0, tilePrefab.Length-1);
                GameObject tile = Instantiate(tilePrefab[index], position, Quaternion.identity, transform);
            }
        }
        treeSpawmer.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
