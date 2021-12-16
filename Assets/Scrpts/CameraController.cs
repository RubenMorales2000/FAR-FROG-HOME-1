using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Rigidbody rb;  


    private Vector3 offset;           

    
    void Start () 
    {
       
        offset = transform.position - rb.transform.position;
    }

  
    void LateUpdate () 
    {
        
        transform.position = rb.transform.position + offset;
    }
}