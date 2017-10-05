using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite2DPlacement : MonoBehaviour {
    public LayerMask layerMask;
    public static bool isSelected;
    RaycastHit2D hit;
    
    // Use this for initialization
    void Start () {
        isSelected = false;

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButton(0))
        {



            if (Camera.main.orthographic)
            {

                if (!isSelected)
                {

                    hit = Physics2D.Raycast(GetWorldPositionOnPlane(Input.mousePosition, transform.position.z), Vector2.zero);
                }

                if (hit != false)
                {


                    if (hit.collider.name == gameObject.name)
                    {


                        Vector3 m = Input.mousePosition;
                        m = new Vector3(m.x, m.y, transform.position.y);
                        Vector3 p = Camera.main.ScreenToWorldPoint(m);


                        transform.position = new Vector3(p.x, p.y);
                        isSelected = true;
                    }
                    else
                    {
                        isSelected = false;
                    }




                }
            }
            else
            {
                if (!isSelected)
                {

                
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    hit = Physics2D.Raycast(ray.origin, ray.direction);
            }
                if (hit != false)
                {
                    if (hit.collider.name == gameObject.name)
                {
              
                    Vector3 m = Input.mousePosition;
                        m.z = 10;
                    Vector3 p = Camera.main.ScreenToWorldPoint(m);


                    transform.position = p;
                        isSelected = true;
                    }
              

            }
                     else
                     {
                isSelected = false;
            }
           
        }
        }
        else
        {
            isSelected = false;
        }

    }
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
