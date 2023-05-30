using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
   public GameObject cam;
   public GameObject end;
   
   public void zoom()
   {
    transform.position = Vector3.Slerp(cam.transform.position,end.transform.position,2f);
   }

}
