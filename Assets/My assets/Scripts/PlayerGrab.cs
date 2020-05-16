using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGrab : MonoBehaviour
{
    public GameObject[] items;
    public GameObject[] itemIcons;
    public GameObject itemSelector;
    public int handItem;

    public GameObject hands;
    
    public float power;

    bool handsBussy = false;
    Collider ballCol;
    Rigidbody ballRb;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        // ballCol = ball.GetComponent<SphereCollider>();
        // ballRb = ball.GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            if(hands.GetComponent<Grab>().canGrab)
            {
                Debug.Log("but");
                hands.GetComponent<Grab>().canGrab = false;
                //Debug.Log(hands.GetComponent<Grab>().getLastItem());
                Item item = hands.GetComponent<Grab>().getLastObject();
                item.disable();
                itemIcons[item.getId()].SetActive(true);
                handItem = item.getId();
                return;
            }else if(hands.GetComponent<Grab>().canInteract){
                hands.GetComponent<Grab>().canInteract = false;
                Item item = hands.GetComponent<Grab>().getLastObject().GetComponent<Item>();
                Debug.Log(item.getId());
                // Compare if the user select the correct item
                if(handItem == item.interactItem.GetComponent<Item>().getId()){
                    if(item.getId() == 2){
                        itemIcons[1].SetActive(true);
                        handItem = 4;
                    }

                    if(item.getId() == 3){
                        itemIcons[1].SetActive(false);
                        item.GetComponent<Collider>().isTrigger = false;
                        item.interactItem.SetActive(true);
                        handItem = 5;
                        return;
                    }

                    if(item.getId() == 4){
                        item.gameObject.SetActive(false);
                        itemIcons[2].SetActive(false);
                        itemIcons[3].SetActive(true);
                        return;
                    }

                    if(item.getId() == 6){
                        itemIcons[3].SetActive(false);
                        SceneManager.LoadScene(2);
                        return;
                    }



                    itemIcons[item.interactItem.GetComponent<Item>().getId()].SetActive(false);
                    itemIcons[item.getId()].SetActive(true);
                }
            }
        }
        //     if(handsBussy){
        //         this.GetComponent<PlayerGrab>().enabled = false;
        //         ball.transform.SetParent(null);
        //         ballCol.isTrigger = false;
        //         ballRb.useGravity = true;
                
        //         ballRb.velocity = cam.transform.rotation * Vector3.forward * power;
        //         handsBussy = false;
        //     }else if(){
        //         ball.transform.SetParent(hands.transform);
        //         ball.transform.localPosition = hands.transform.localPosition;
        //         ball.transform.localPosition = new Vector3(-0.63f,0.08f,0.37f);
        //         ballRb.velocity = Vector3.zero;
        //         ballCol.isTrigger = true;
        //         ballRb.useGravity = false;
        //         handsBussy = true;
        //     }
        // }
    }
}
