using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
   public GameObject[] Wires; //Wire end points
   public GameObject[] Endpoint; // where it has to go
   [SerializeField] int index; //Keeps track of active objects
   public static Game_Manager ins; 

    private void Awake() { 
        for (int i = 0; i < Wires.Length; i++) //Add collision detect script on all wires
    {Collision_Detect cl= Wires[i].AddComponent<Collision_Detect>();
    cl.setup(this); } //Call Setup of Coll Detect and passing game manager object to it--> See Coll detect comments

    for (int i = 0; i < Endpoint.Length; i++)
    { Endpoint[i].GetComponent<Collider>().enabled = false; } //Setting colliders of objects false so we collider with only active objects
    
    for (int i = 0; i < Wires.Length; i++)
    { 
        Wires[i].GetComponent<Collider>().enabled = false;
    } }

    private void Start() {
    index=0;
    Wires[index].GetComponent<Collider>().enabled = true; //Set first objects collider on
    Endpoint[index].GetComponent<Collider>().enabled = true;
    }

    public void Starting(Collider other){
    switch(index)
    {
        case 0: 
        Debug.Log("Case 0");
        Wires[index].transform.position= Endpoint[index].transform.position; //When collide so move the wire to the endpoint
        Wires[index].GetComponent<Collider>().enabled= false; //Disable its collider if not needed anymore, so we dont collider with other objects and trigger collision or drag it accidently
        Endpoint[index].GetComponent<Collider>().enabled = false;
        Drag d= Wires[index].GetComponent<Drag>(); // We can also remove drag script to make sure we dont move the object again
        Destroy(d);
        StartCoroutine("Wait");
        break;

        case 1: 
        Debug.Log("Case 1");
        Wires[index].transform.position= Endpoint[index].transform.position;
        Wires[index].GetComponent<Collider>().enabled= false;
        Endpoint[index].GetComponent<Collider>().enabled = false;
        d= Wires[index].GetComponent<Drag>();
        Destroy(d);
        StartCoroutine("Wait");
        break;

        // case 2: 
        // Debug.Log("Case 2");
        // Wires[index].transform.position= Endpoint[index].transform.position;
        // Wires[index].GetComponent<Collider>().enabled= false;
        // Endpoint[index].GetComponent<Collider>().enabled = false;
        // d= Wires[index].GetComponent<Drag>();
        // Destroy(d);
        // StartCoroutine("Wait");
        // break;

        // case 3: 
        // Debug.Log("Case 3");
        // Wires[index].transform.position= Endpoint[index].transform.position;
        // Wires[index].GetComponent<Collider>().enabled= false;
        // Endpoint[index].GetComponent<Collider>().enabled = false;
        // d= Wires[index].GetComponent<Drag>();
        // Destroy(d);
        // StartCoroutine("Wait");
        // break;

        // case 4: 
        // Debug.Log("Case 4");
        // Wires[index].transform.position= Endpoint[index].transform.position;
        // Wires[index].GetComponent<Collider>().enabled= false;
        // Endpoint[index].GetComponent<Collider>().enabled = false;
        // d= Wires[index].GetComponent<Drag>();
        // Destroy(d);
        // StartCoroutine("Wait");
        // break;
} } 
IEnumerator Wait(){
    Debug.Log("In Wait");
    Debug.Log(Wires[index]);
    index++;
    Wires[index].GetComponent<Collider>().enabled= true; // Next items ke colliders on
    Endpoint[index].GetComponent<Collider>().enabled = true;
    yield return new WaitForSeconds(1f);
} 

}
