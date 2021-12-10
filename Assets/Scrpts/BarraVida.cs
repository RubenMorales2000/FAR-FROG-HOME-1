using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class BarraVida : MonoBehaviour
{
    
     public Image Vida1;
    public Image Vida2;
    public Image Vida3;
    
    public float VidaACt;
    static bool invulnerability = false;

    // Update is called once per frame
    void Update()
    {
        if(VidaACt == 2){Vida3.GetComponent<Image>().color = new Color32(255,255,225,100);}
        if(VidaACt == 1){Vida1.GetComponent<Image>().color = new Color32(255,255,225,100);}
        if(VidaACt == 0){Vida2.GetComponent<Image>().color = new Color32(255,255,225,100);}
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
    void OnTriggerEnter(Collider other)
    {
        if (!invulnerability)
        {
            Thread thred = new Thread(new ThreadStart(InvulnerabilitySet));
            invulnerability = true;
            thred.Start();
            VidaACt--;
        }
    }
    public static void InvulnerabilitySet()
    {
        Thread.Sleep(1000);
        invulnerability = false;
    }
}