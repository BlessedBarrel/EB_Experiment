using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Drop : MonoBehaviour
{
    GameManager gm;
    public void initial(GameManager game)
    {
        gm=game;
    }
    /*Item pos is (2,3,10) --> world to screen point (200,300 100)pixels
    then we find offset, where we click mouse inside object position is (220,320,120)pixels and object pos is (200,300,100)
    minus then we get (20,20,20). Now in last drag function, we take the mouse pos every frame as obj gets dragged and - it from the offset
    This allows us to  */
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
private void OnMouseEnter() {
    Debug.Log("Inside mouse enter");
    if (gm)
    Debug.Log("Inside if gm on mouse enter");
    Cursor.SetCursor(gm.handCursor, gm.cursorOffset,gm.cursorMode);
    }
private void OnMouseExit() {
    if (gm)
     Cursor.SetCursor(null, Vector2.zero, gm.cursorMode);
}

 }