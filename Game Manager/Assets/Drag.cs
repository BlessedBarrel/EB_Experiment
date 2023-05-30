using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
   Vector3 mousePosition;
    //Getting Initial position of object in screen space (Pixels)
    public Vector3 GetMousePos() { 
        //Debug.Log( Camera.main.WorldToScreenPoint(transform.position) + "item pos" );
        return  Camera.main.WorldToScreenPoint(transform.position); // pos of item
        }
    //On MouseDown get to offset of the mouse pos and the object pos.
    private void OnMouseDown() { 
    mousePosition= Input.mousePosition - GetMousePos(); // Offset
   // Debug.Log(mousePosition +"offset"); 
   }
    //On dragging, Miinus the moving mouse pos every frame from the offset
    private void OnMouseDrag() {
    transform.position= Camera.main.ScreenToWorldPoint (Input.mousePosition - mousePosition); 
   // Debug.Log(Input.mousePosition + "mousePosition");
   // Debug.Log(Input.mousePosition - mousePosition + "Not converted");
   // Debug.Log(transform.position + "final") ;}
} 

}
