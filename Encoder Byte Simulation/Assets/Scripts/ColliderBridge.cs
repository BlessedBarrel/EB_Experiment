using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBridge : MonoBehaviour
{
    GameManager GM;

    public void Initialize(GameManager g) {
        GM= g;
    }
    void OnTriggerEnter(Collider other) // When triggered so Call Simluation Managers OnTriggerEnter
    {
        Debug.Log("Collided with " + other.gameObject.name);
        GM.OnTriggerEnteer(other);
    }

}