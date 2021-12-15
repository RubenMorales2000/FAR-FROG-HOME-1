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
    static bool muerto = false;
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
            menuMuerteUI.SetActive(true);
        }
        if(player.transform.position.x < -2103){
          Debug.Log("NIVEL SUPERADO")  ;
          SceneManager.LoadScene ("2DO NIVEL");
        }
        if(vidas == 0){
            if (!muerto) {
                muerto = true;
                SoundManagerPlayer.PlaySounds("death");
                System.Threading.Thread.Sleep(1000);
                menuMuerteUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        if(player.transform.position.z > 400){
          SceneManager.LoadScene ("2DO NIVEL");
        }


        

    }
    void OnTriggerEnter(Collider other)
    {
        if (!invulnerability)
        {
            Thread thred = new Thread(new ThreadStart(InvulnerabilitySet));
            invulnerability = true;
            thred.Start();
            if (vidas > 1)
            {
                SoundManagerPlayer.PlaySounds("collision");
            }
            vidas--;
        }
    }
        public static void InvulnerabilitySet()
    {
        Thread.Sleep(1000);
        invulnerability = false;
    }

    public void volverAinicio()
    {
        SceneManager.LoadScene("MENU PRINCIPAL");
    }

    public void reintentar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;

    }

}