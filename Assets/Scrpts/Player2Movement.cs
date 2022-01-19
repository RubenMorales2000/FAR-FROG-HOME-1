using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _jumpForce = 300;
    [SerializeField] private int stamina = 40;
    bool isGrounded = true;
    static bool onCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          var vel = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed;
        vel.y = _rb.velocity.y;
        _rb.velocity = vel;
    
    if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true ){
            
                _rb.AddForce(Vector3.up * _jumpForce);
                SoundManagerPlayer.PlaySounds("playerJump");
            
        }
    }

    void OnCollisionEnter(Collision collision){
    
        isGrounded = true;
        
    }   


    void OnCollisionExit(Collision collision){
   
        isGrounded = false;
        
    }
}
