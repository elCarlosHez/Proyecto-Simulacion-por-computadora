using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{

    public bool canGrab;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Ball")){
            canGrab = true;
        }
    }

    public void OnTriggerExit(Collider other){
        canGrab = false;
    }
}
