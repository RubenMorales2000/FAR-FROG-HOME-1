using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _jumpForce = 300;
    bool isGrounded = true;

    void Start(){
        
    }

    

    void Update() {


        var vel = new Vector3(-5, 0, Input.GetAxis("Horizontal")) * _speed;
        vel.y = _rb.velocity.y;
        _rb.velocity = vel;
        
       
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true ){
            
             _rb.AddForce(Vector3.up * _jumpForce);
             
        }
    }

    void OnCollisionEnter(Collision collision){
    if (collision.collider.tag == "suelo"){
        isGrounded = true;
        }
    }   


    void OnCollisionExit(Collision collision){
    if (collision.collider.tag == "suelo"){
        isGrounded = false;
        }
    }
} 