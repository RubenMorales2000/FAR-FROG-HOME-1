using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollision : MonoBehaviour
{
    public GameObject menuMuerteUI;
    public GameObject player;
     public int vidas = 3;
    static bool invulnerability = false;
     void Start()
    {
        menuMuerteUI.SetActive(false);
    }
    
    void OnCollisionEnter(Collision collision)
    {  
       Debug.Log(collision.collider.name);
        string c = collision.collider.name;
        if(c.Contains("pC") || c.Contains("colli")){
           
            if (!invulnerability) {
                Thread thred = new Thread(new ThreadStart(InvulnerabilitySet));
                invulnerability = true;
                thred.Start();
                if (vidas > 1) { 
                    SoundManagerPlayer.PlaySounds("collision");
                }
                vidas--;
            }
        }
    }

    void Update() {
     
        if(player.transform.position.y < -10){
          SceneManager.LoadScene ("MUERTE");
        }
        if(player.transform.position.x < -2103){
          Debug.Log("NIVEL SUPERADO")  ;
          SceneManager.LoadScene ("2DO NIVEL");
        }
        if(vidas == 0){
            SoundManagerPlayer.PlaySounds("death");
            System.Threading.Thread.Sleep(1000);
            menuMuerteUI.SetActive(true);

        }
        if(player.transform.position.z > 400){
          SceneManager.LoadScene ("2DO NIVEL");
        }


        

    }
    public static void InvulnerabilitySet()
    {
        Thread.Sleep(1000);
        invulnerability = false;
    }

    public void volverAinicio()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

}