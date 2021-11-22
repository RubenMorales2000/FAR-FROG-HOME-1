using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class WallMovement : MonoBehaviour
{

    public Transform pos1,pos2;
    public float speed;
    public Transform startPos;

    Vector3 nextpos;

    void Start(){
        nextpos = startPos.position;
    }

    

    void Update() {

       if(transform.position == pos1.position){ nextpos = pos2.position;}
       
       if(transform.position == pos2.position){ nextpos = pos1.position;}

       transform.position = Vector3.MoveTowards(transform.position, nextpos, speed*Time.deltaTime);
    }

    
    
} 