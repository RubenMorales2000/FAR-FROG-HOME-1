using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class BarradeVida : MonoBehaviour
{
    public Image Vida1;
    public Image Vida2;
    public Image Vida3;
    
    public float VidaACt;
    static bool invulnerability = false;

    // Update is called once per frame
    void Update()
    {
       if (VidaACt== 2){}
    }
     void OnCollisionEnter(Collision collision)
    {  
      
        string c = collision.collider.name;
        if(c.Contains("pC") || c.Contains("colli")){
           
            if (!invulnerability) {
                Thread thred = new Thread(new ThreadStart(InvulnerabilitySet));
                invulnerability = true;
                thred.Start();
               
                VidaACt--;
            }
        }
    }
     public static void InvulnerabilitySet()
    {
        Thread.Sleep(1000);
        invulnerability = false;
    }
}
