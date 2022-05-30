using System.Collections;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private Transform followCam;
    private Vector3 startOffset;

    // Start is called before the first frame update
    void Start()
    {
        followCam = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - followCam.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followCam.position + startOffset;
    }
}
