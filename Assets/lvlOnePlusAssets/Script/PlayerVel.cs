using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVel : MonoBehaviour
{
    
    public Rigidbody player;
    public float speed;
    void Start()
    {
    }

        void Update()
    {
        player.velocity = new Vector3(player.velocity.x, player.velocity.y, speed);
    }
}
