/**  
 * Zgan 2017
 * 
 * 
 * 
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIPlacement : MonoBehaviour,
    IDragHandler
 
{

       public void OnDrag(PointerEventData eventData)
     
    {
     ;
        if(Input.GetMouseButton(0))
        {
           
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(this.transform as RectTransform, Input.mousePosition, Camera.main, out pos);
           
            transform.position = this.transform.TransformPoint(pos);
        }
    }

 
}
