using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,20.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,10.0f);
    }
    
    private void FixedUpdate() {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,-20.0f);
    }
}
