using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float Y;
    public Canvas ending;
    public GameObject SpoonItem;
    public FunnelColor funnelcol;
    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public CapOpen cap;
    public Collider[] Colliders;
    public GameObject[] objects;
    public Animator[] animator; //add all Animators 
    float[] initialPos;
    int index;
    bool foo= false;

    [Header("Cursor")] // Select Curson
    public CursorMode cursorMode = CursorMode.Auto;// CursorMode.Auto means that the cursor will change depending on the platform. 
                                                   //For example, on Windows it will be an arrow, while on macOS it will be a pointing hand.
    public Vector2 cursorOffset;//Set the hotSpot field to the center of the texture, or wherever you want the "click" point of the cursor to be.
    public Texture2D handCursor;// Image of the cursor


    private void Awake() {
    for (int i = 0; i < objects.Length ; i++)  { 
        objects[i].GetComponent<Collider>().enabled = false; 
        Drag_Drop dg= objects[i].GetComponent<Drag_Drop>();
        dg.initial(this); 
        }

        for (int i = 0; i < objects.Length ; i++) { 
        var outline= objects[i].AddComponent<Outline>();
        objects[i].GetComponent<Outline>().enabled= false; 
        outline.OutlineColor = Color.green;
        outline.OutlineWidth = 6f;
        }


    for (int i = 0; i < Colliders.Length; i++){ 
        ColliderBridge cb = Colliders[i].gameObject.AddComponent<ColliderBridge>(); // Make colliderbridge class type object and Add ColliderBridge Script to Colliders,step1,step2...
            cb.Initialize(this);
        Colliders[i].enabled = false;  } 
    foreach (Animator an in animator ) { an.enabled = false; } //Off all animators

    }

    private void Start() { 
        //ps=gameObject.GetComponent<ParticleSystem>();
    initialPos= new float[objects.Length];
    index=0;
    objects[index].GetComponent<Collider>().enabled = true;
    objects[index].GetComponent<Outline>().enabled= true;
    Colliders[index].enabled = true;

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
    public void OnTriggerEnteer(Collider other) { 
        switch (index)
        {
            case 0: //Ignore case 0-1 ghalat mein kari
            if(foo == false)
            {
               
           // Debug.Log("case 0");
            animator[index].enabled = true;
            animator[index].Play("spoon");
            StartCoroutine("spoonitem");
            Colliders[index].enabled = false;
            cap.Close();
           // powder.enabled = true;
            StartCoroutine("Spoon");
            }
            if(foo==true){
            animator[0].enabled = true;
            animator[0].Play("ChinaDish");
            ps2.Play();
            StartCoroutine("droppingitem");
            Colliders[index+1].enabled = false;
            objects[index].GetComponent<Collider>().enabled = false;
            for (int i = 1 ; i < Colliders.Length -1 ; i++) { // Moving elements back
                //Debug.Log("Inside Loop");
                Colliders[i]=Colliders[i+1];}
          //  powder.enabled = false;

            StartCoroutine("NextStep");

            }
            break;

            case 1: // enable animator play ka animation
            //Note if u need to move object again nu if animator enabled nu u cant move it
            //Nu bya add it twice in inspector aur like case 1 ke aghe first movement ushu
            //then case 2 ke ba next movement warta uke.
            Debug.Log("3");
            animator[index].enabled= true;
            animator[index].Play("Mesh");
            Debug.Log("play mesh");
            Colliders[index].enabled=false;
            Debug.Log("Collider Disablke");
            Drag_Drop obj=objects[index].GetComponent<Drag_Drop>();
            Destroy(obj);
            Debug.Log("Mesh Done");
            objects[index].GetComponent<Collider>().enabled = false;
            StartCoroutine("NextStep");
            break;
            
            case 2:
            Debug.Log("4");
            animator[index].enabled= true;
            animator[index].Play("CD");
            Debug.Log("play CD");
            Colliders[index].enabled=false;
            Debug.Log("Collider Disablke");
            obj=objects[index].GetComponent<Drag_Drop>();
            Destroy(obj);
            Debug.Log("CD Done");
            objects[index].GetComponent<Collider>().enabled = false;
            StartCoroutine("NextStep");
            break;
            
            case 3:
             Debug.Log("5");
            animator[index].enabled= true;
            animator[index].Play("Funnel");
            Debug.Log("play funnel");
            Colliders[index].enabled=false;
            Debug.Log("Collider Disablke");
            obj=objects[index].GetComponent<Drag_Drop>();
            Destroy(obj);
            Debug.Log("funnel Done");
            objects[index].GetComponent<Collider>().enabled = false;
            StartCoroutine("NextStep");
            break;

            case 4:
             Debug.Log("6");
            animator[index].enabled= true;
            animator[index].Play("Cotton");
            Debug.Log("play Cotton");
            Colliders[index].enabled=false;
            Debug.Log("Collider Disablke");
            obj=objects[index].GetComponent<Drag_Drop>();
            Destroy(obj);
            Debug.Log("Cotton Done");
            StartCoroutine("NextStep");
            break;

            case 5:
             Debug.Log("7");
            animator[index].enabled= true;
            animator[index].Play("match");
            Debug.Log("play match");
            Colliders[index].enabled=false;
            StartCoroutine("Wait");
            Debug.Log("Collider Disablke");
            Debug.Log("match Done1");
            ps1.Play();
            Debug.Log("match Done2");
            funnelcol.ChangeColor();
            //zoom.zoom();
            StartCoroutine("Waitt");
            
            break;
            
            default: Debug.Log("Default"); break;
        }
    }
        IEnumerator NextStep(){ //Da ugora Ignore other Ienumerators
            objects[index].GetComponent<Outline>().enabled= false;
            index++;
            objects[index].GetComponent<Outline>().enabled= true;
             Debug.Log(index);
             Debug.Log(objects[index]);
            Debug.Log(Colliders[index]);
            yield return new WaitForSeconds(1.5f);
            objects[index].GetComponent<Collider>().enabled = true;
            Colliders[index].enabled = true;
}
    IEnumerator Wait()
    {
        Debug.Log("Wait");
        Debug.Log(objects[index]);
        yield return new WaitForSeconds(2);
        Destroy(objects[index]);
    }
    IEnumerator Waitt()
    {Debug.Log("active");
        yield return new WaitForSeconds(7);
    ending.gameObject.SetActive(true);
    Debug.Log("ACtive 2");
    }
    IEnumerator Spoon()
    {
    yield return new WaitForSeconds(2);
        foo=true;
        animator[0].enabled = false;
        Colliders[index+1].enabled = true;
    }
    IEnumerator spoonitem(){
        yield return new WaitForSeconds(1);
        SpoonItem.SetActive(true);
    }
    IEnumerator droppingitem(){
        yield return new WaitForSeconds(0.5f);
        //SpoonItem.transform.parent = objects[2].transform - Vector3(0,2,0);
        SpoonItem.transform.parent = objects[2].transform;
        SpoonItem.transform.position = new Vector3(-2.448f, 1.8f , -0.059f);

    }
}


