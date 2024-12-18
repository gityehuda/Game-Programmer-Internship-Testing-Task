using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour
{
    public GameObject dirt;
    public GameObject desert;
    public GameObject house;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(dirt.gameObject.tag == getClickedObject(out RaycastHit hit).gameObject.tag) 
            {
                GameObject go = getClickedObject(out hit);
                if(go.GetComponent<CheckTile>().isOccupied == false)
                {
                    Debug.Log(go.gameObject.name);
                    Instantiate(house, go.transform.position + new Vector3(0, 0.2f, 0), go.transform.rotation);
                    score += 10;
                    go.GetComponent<CheckTile>().isOccupied = true;
                }
                return;
            }
            
            if(desert.gameObject.tag == getClickedObject(out hit).gameObject.tag)
            {
                GameObject go = getClickedObject(out hit);
                Debug.Log(go.gameObject.name);
                Instantiate(house, go.transform.position + new Vector3(0, 0.2f, 0), go.transform.rotation);
                score += 2;
            }
        }

        if(Input.GetMouseButtonUp(0))
        {

        }
    }

    GameObject getClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10 , out hit)) 
        {
            if(!isPointerOverUIObject())
            {
                target = hit.collider.gameObject;
            }
        }
        return target;
    }
   
    private bool isPointerOverUIObject()
    {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);   
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);
        return results.Count > 0;
    }
}
