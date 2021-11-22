using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollision : MonoBehaviour
{
     public GameObject player;
     public int vidas = 3;

     void Start()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {  
        if(collision.collider.tag == "obstaculo"){
            vidas--;
        }    
    }

    void Update() {
     
        if(player.transform.position.y < -10){
          SceneManager.LoadScene ("MUERTE");
        }
        if(vidas == 0){ SceneManager.LoadScene ("MUERTE");Debug.Log("Has muerto");}

        Debug.Log(vidas);

    }

}