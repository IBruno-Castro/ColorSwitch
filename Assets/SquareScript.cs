using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareScript : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public LogicManager logicScript;
    public AudioClip collisionSound;
    public AudioSource audioSource;
    public int velocidade = 5;
    public float jumpStrength = 3;
    public bool isGrounded;
    public float counterJump = 0.5f;
    public bool isJumping;

    public float gravity = 7;
    // Start is called before the first frame update
    void Start()
    {  
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!logicScript.GetGameOver()){
            //get the Input from Horizontal axis
            float horizontalInput = Input.GetAxis("Horizontal");

            //update the position
            transform.position = transform.position + new Vector3(horizontalInput * velocidade * Time.deltaTime,0, 0);

            if(horizontalInput > 0){
                transform.localScale = new Vector3(1,1,1);
            } else if(horizontalInput < 0){
                transform.localScale = new Vector3(-1,1,1);
            }

            if(isJumping){
                Jump();
            }

            Gravity();

            if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
                isJumping = true;
            }
            if(Input.GetKey(KeyCode.Space) && !isGrounded){
                counterJump -= Time.deltaTime;
            }
            if(Input.GetKeyUp(KeyCode.Space) || counterJump < 0){
                isJumping = false;
            }
        }
    }

    void Jump(){
        if(counterJump > 0){
            rigidBody2D.velocity = Vector2.up * jumpStrength;
        } else {
            isJumping = false;
        }
    }

    void Gravity(){
        if(!isJumping && !isGrounded){
            rigidBody2D.velocity = Vector2.down * gravity;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Floor"){
            isGrounded = true;
            counterJump = 0.5f;
        }
        
        if(other.gameObject.tag == "Score"){
            logicScript.IncreaseScore();
            audioSource.PlayOneShot(collisionSound);
        }

        if(other.gameObject.tag == "Death"){
            logicScript.SetGameOver(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Floor"){
            isGrounded = false;
        }
    }

}
