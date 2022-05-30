using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private float speed = 5.0f;
    private float horizontalSpeed = 1.0f;  
    private Transform playertr;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playertr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        controller.Move((Vector3.forward * speed) * Time.deltaTime);
        var horizontalVector = Vector3.zero;
        horizontalVector.x = Input.GetAxisRaw("Horizontal");

        if(transform.position.x < 2.5f && horizontalVector.x > 0){
            
            controller.Move( horizontalVector * speed* horizontalSpeed * Time.deltaTime);
        }else if(transform.position.x > -2.5f && horizontalVector.x < 0){
            
            controller.Move( horizontalVector * speed* horizontalSpeed * Time.deltaTime);
        }
        
    }
    
}