using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public int ID;
    public GameObject interactItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int getId(){
        return ID;
    }

    public void disable(){
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
