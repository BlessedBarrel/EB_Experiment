using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CapOpen cap;
    public Collider[] box;
    public GameObject[] objects;
    public Animator[] animator;
    float[] initialPos;
    int index;
    private void Awake() {
    for (int i = 0; i < objects.Length ; i++)  { objects[i].GetComponent<Collider>().enabled = false; } 
    for (int i = 0; i < box.Length; i++){ 
        ColliderBridge cb = box[i].gameObject.AddComponent<ColliderBridge>(); // Make colliderbridge class type object and Add ColliderBridge Script to Colliders,step1,step2...
            cb.Initialize(this);
        box[i].enabled = false;  } 
    foreach (Animator an in animator ) { an.enabled = false; }

    }

    private void Start() { 
    initialPos= new float[objects.Length];
    index=0;
    objects[index].GetComponent<Collider>().enabled = true;
    box[index].enabled = true;

    for (int i = 0; i < initialPos.Length; i++)
        {
            initialPos[i] = objects[i].transform.localPosition.y; //Storing Y position of 1-6 items in Yclamp[1-6]
        } 
                         }

    private void Update() {
        if( objects[index].transform.position.y < initialPos[index] )
        {
            objects[index].transform.position= new Vector3(objects[index].transform.position.x
            ,initialPos[index] ,objects[index].transform.position.z);
        } }
    public void OnTriggerEnteer(Collider other) { //Collider Not Working
        switch (index)
        {
            case 0:
            Debug.Log("case 0");
            Drag_Drop obj=objects[index].GetComponent<Drag_Drop>();
            Destroy(obj);
            animator[index].enabled = true;
            animator[index].Play("spoon");
            cap.Close();
            index++;
            break;

            default: Debug.Log("Default"); break;
        }
    }
}


