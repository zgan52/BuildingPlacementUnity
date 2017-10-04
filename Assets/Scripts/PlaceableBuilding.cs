using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableBuilding : MonoBehaviour {
    [HideInInspector]
    public List<Collider> colliders = new List<Collider>();
   
    private bool isSelected;

    private void OnGUI()
    {
        //when selected Building
        if(isSelected)
        {
            GUI.Button(new Rect(100, 200, 100, 30), name);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Building")
        {
            colliders.Add(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Building")
        {
            colliders.Remove(other);
        }
    }
    public void SetSelected(bool s)
    {
        isSelected = s;
    }
   
}
