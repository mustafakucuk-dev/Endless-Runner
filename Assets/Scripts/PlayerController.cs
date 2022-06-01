using System.Text;
using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private float speed = 5.0f;
    private float horizontalSpeed = 1.0f;  
    private float acceleration = 0.001f;
    private Transform playertr;

    public GameObject scoreMenu;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playertr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        speed += acceleration;

        controller.Move((Vector3.forward * speed) * Time.deltaTime);
        var horizontalVector = Vector3.zero;
        horizontalVector.x = Input.GetAxisRaw("Horizontal");

        if(transform.position.x < 2.5f && horizontalVector.x > 0){
            
            controller.Move( horizontalVector * speed * horizontalSpeed * Time.deltaTime);
        }else if(transform.position.x > -2.5f && horizontalVector.x < 0){
            
            controller.Move( horizontalVector * speed* horizontalSpeed * Time.deltaTime);
        }
        
    }

    void OnTriggerEnter(Collider other){
        if(other.name.Contains("Hurdle")){
            Time.timeScale = 0;
            scoreText.text = scoreText.text + score.ToString();
            scoreMenu.SetActive(true);
        }
        else{
            score += 100;
            //Debug.Log(score);
        }
    }
    
}