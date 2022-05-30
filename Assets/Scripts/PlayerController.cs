using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move((Vector3.forward * speed) * Time.deltaTime);
    }
}