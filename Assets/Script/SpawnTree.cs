using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class SpawnTree : MonoBehaviour
{
    public GameObject[] dirtTile;
    public GameObject tree;

    // Start is called before the first frame update
    void Start()
    {
        dirtTile = GameObject.FindGameObjectsWithTag("Dirt");
        StartCoroutine(TreeSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TreeSpawn()
    {
        for(int i = 0; i < dirtTile.Length; i++)
        {
           
            if(dirtTile[i].GetComponent<CheckTile>().isOccupied == false)
            {
                Instantiate(tree, dirtTile[i].transform.position + new Vector3(0, 0.2f, 0), dirtTile[i].transform.rotation);
                dirtTile[i].GetComponent<CheckTile>().isOccupied = true;
                yield return new WaitForSeconds(1f);
            }
           
        }
        Debug.Log("Tree is finished planting");
        yield return null;
    }
}
