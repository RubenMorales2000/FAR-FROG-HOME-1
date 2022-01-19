using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision2 : MonoBehaviour
{
    public int vidas = 3;
    public int comida = 0;
    public GameObject food;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {  
        if(collision.collider.tag != "suelo"){
        string c = collision.collider.tag;
        if(c == "comida"){
            comida++;
            Debug.Log(comida);
            Destroy(collision.collider.gameObject);
        }
        if(c == "obstaculo"){
            vidas--;
            Debug.Log(vidas);
            Destroy(collision.collider.gameObject);
        }
        
        
        
        }
    }   
}
