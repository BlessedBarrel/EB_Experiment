using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapOpen : MonoBehaviour
{
    public Animator anim;
 private void OnMouseDown() {
    anim.Play("CapOpen");
    }

   public void Close(){
      StartCoroutine("Wait");
   }

   IEnumerator Wait()
   {
      yield return new WaitForSeconds(1);
      anim.Play("CapClose");
   }

}
