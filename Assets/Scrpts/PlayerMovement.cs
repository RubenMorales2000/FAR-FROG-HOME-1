using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
 
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _jumpForce = 300;
    [SerializeField] private int stamina = 40;
    bool isGrounded = true;
    static bool onCooldown = false;
    void Start(){
        
    }

    

    void Update() {


        var vel = new Vector3(-4, 0, Input.GetAxis("Horizontal")) * _speed;
        vel.y = _rb.velocity.y;
        _rb.velocity = vel;
        
       
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true ){
            //if (!onCooldown)
            //{
            //    Thread thred = new Thread(new ThreadStart(SetCooldown));
            //    onCooldown = true;
            //    thred.Start();
            //    SoundManagerPlayer.PlaySounds("playerJump");
            //    _rb.AddForce(Vector3.up * _jumpForce);

            //}
            if (StaminaBar.instance.getStamina() > stamina)
            {
                StaminaBar.instance.UseStamina(stamina);
                _rb.AddForce(Vector3.up * _jumpForce);
            }
        }
    }

    void OnCollisionEnter(Collision collision){
    
        isGrounded = true;
        
    }   


    void OnCollisionExit(Collision collision){
   
        isGrounded = false;
        
    }

    void OnCollisionStay(Collision collision){
        if (collision.collider.name == "loopableCity" || collision.collider.name == "loopableCity(Clone)"){ isGrounded = true;}
        Debug.Log(collision.collider.name);
    }
    public static void SetCooldown()
    {
        Thread.Sleep(3000);
        onCooldown = false;
    }
} 