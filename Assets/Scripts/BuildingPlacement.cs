using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour {
    private PlaceableBuilding placeableBuilding;
    private Transform currentBuilding;


    private bool hasPlaced;
    public LayerMask buildingsMask;
    private PlaceableBuilding placeableBuildingOld;
    Color colr;
    // Use this for initialization
    void Start () {
     

    }

    // Update is called once per frame
    void Update () {
        Vector3 m = Input.mousePosition;
        m = new Vector3(m.x, m.y, transform.position.y);
        Vector3 p = Camera.main.ScreenToWorldPoint(m);
      
        if (currentBuilding != null && !hasPlaced)
        {
           //currentBuilding.position = new Vector3(p.x, 0, p.z);

            currentBuilding.position = new Vector3(p.x, currentBuilding.position.y, p.z);
            // Change color when the position isnt legal
            if (currentBuilding.GetChild(0).gameObject.GetComponent<Renderer>() != null)

            {

          
                if (IsLegalPosition())
            {

                currentBuilding.GetChild(0).gameObject.GetComponent<Renderer>().material.color = colr;
            }
            else
            {
                currentBuilding.GetChild(0).gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            }
            // currentBuilding.transform.GetChild(0).gameObject.GetComponent<Collider>().isTrigger = true;
            if (Input.GetMouseButton(0))
     
            {
                if (IsLegalPosition())
                {

                    //   currentBuilding.transform.GetChild(0).gameObject.GetComponent<Collider>().isTrigger = false;
             
                    hasPlaced = true;
                    Cursor.visible = true;
                }

            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
               
                Destroy(currentBuilding.gameObject);
                Cursor.visible = true;
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
   
            {


                RaycastHit hit = new RaycastHit();
                Ray ray = new Ray(new Vector3(p.x, 100, p.z), Vector3.down);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, buildingsMask))
                {
                 

                    if (placeableBuildingOld != null)
                    {
                        placeableBuildingOld.SetSelected(false);

                    }
                    if (hit.collider.gameObject.GetComponent<PlaceableBuilding>()!=null)
                            {

                        hit.collider.gameObject.GetComponent<PlaceableBuilding>().SetSelected(true);
                            placeableBuildingOld = hit.collider.gameObject.GetComponent<PlaceableBuilding>();
                        }
                  
                }
                else
                {
                    if (placeableBuildingOld != null)
                    {
                        placeableBuildingOld.SetSelected(false);

                    }
                }
            }
        }
        
     
    }
 
    bool IsLegalPosition()
    {
        if(placeableBuilding.colliders.Count>0)
        {
            return false;
        }
        return true;
    }
    public void SetItem(GameObject b)
    {
        if (currentBuilding != null && !hasPlaced)
        {
           Destroy(currentBuilding.gameObject);
        }
        hasPlaced = false;
        currentBuilding = ((GameObject)Instantiate(b)).transform;
        placeableBuilding = currentBuilding.GetComponent<PlaceableBuilding>();
        if(currentBuilding.GetChild(0).gameObject.GetComponent<Renderer>()!=null)
        colr = currentBuilding.GetChild(0).gameObject.GetComponent<Renderer>().material.color;

        Cursor.visible = false;
        
    }
}
