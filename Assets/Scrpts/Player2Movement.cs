using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _jumpForce = 300;
    [SerializeField] private int stamina = 40;
    [SerializeField] float turnSpeed = 20f;

    float m_Speed = 10.0f;
    bool isGrounded = true;
    static bool onCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            _rb.velocity = -transform.right * m_Speed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            _rb.velocity = transform.right * m_Speed;
        }



        //var vel = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed;
        //vel.y = _rb.velocity.y;
        //_rb.velocity = vel;

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {

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
