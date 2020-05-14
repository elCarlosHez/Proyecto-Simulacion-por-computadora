using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public GameObject ball;
    public GameObject hands;
    public float power;

    bool handsBussy = false;
    Collider ballCol;
    Rigidbody ballRb;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            if(handsBussy){
                this.GetComponent<PlayerGrab>().enabled = false;
                ball.transform.SetParent(null);
                ballCol.isTrigger = false;
                ballRb.useGravity = true;
                
                ballRb.velocity = cam.transform.rotation * Vector3.forward * power;
                handsBussy = false;
            }else if(hands.GetComponent<Grab>().canGrab){
                ball.transform.SetParent(hands.transform);
                ball.transform.localPosition = hands.transform.localPosition;
                ball.transform.localPosition = new Vector3(-0.63f,0.08f,0.37f);
                ballRb.velocity = Vector3.zero;
                ballCol.isTrigger = true;
                ballRb.useGravity = false;
                handsBussy = true;
            }
        }
    }
}
