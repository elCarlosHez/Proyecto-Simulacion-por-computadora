using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public bool canGrab;
    public bool canInteract;

    private int lastItem;
    private Item lastObject;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Item")){
            canGrab = true;
            lastObject = other.gameObject.GetComponent<Item>();
            // lastItem = other.gameObject.GetComponent<Item>().getId();
            // other.gameObject.GetComponent<Item>().disable();
            // Debug.Log(lastItem);
            //lastItem = itemScript;
        }

        if(other.gameObject.CompareTag("InteractItem")){
            canInteract = true;
            lastObject = other.gameObject.GetComponent<Item>();
        }
    }

    public Item getLastObject(){
        return lastObject;
    }

    public int getLastItem(){
        return lastItem;
    }

    public void OnTriggerExit(Collider other){
        canGrab = false;
    }
}
