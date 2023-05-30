using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Detect : MonoBehaviour
{
    Game_Manager gm; // game manager type object 
    public void setup(Game_Manager game){ // We set our gm to the Game Manager object, so every wire with (Collision_Detect cl= Wires[i].AddComponent<Collision_Detect>();) Collision detect
        gm=game;} //will have access to this Collision detect. so when we detect collision so jo wire bhi karay tho they can call to Starting functino of game mangaer using OnTriggerEnter.
// We only have 1 active object in script so one object at a time when collider will call this function aur starting mein we have switch
//udar se we see which index has collided and index mein active object hota so that active object will run the Case 1-2-3 etc..
    private void OnTriggerEnter(Collider other) {
        Debug.Log("WireDetect Script");
        Debug.Log("Collided with " + other.name );
        gm.Starting(other);
    }
}
