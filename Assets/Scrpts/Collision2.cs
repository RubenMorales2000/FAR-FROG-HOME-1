using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collision2 : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private Image imagenProgreso;

    public int vidas = 3;
    public int comida = 0;
    public GameObject jugador;
    public GameObject menuMuerteUI;
    public int x = 10;
    public int y = 10;
    public int z = 10;
    static bool muerto = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vidas == 0)
        {
            if (!muerto)
            {
                muerto = true;
                SoundManagerPlayer.PlaySounds("death");
                System.Threading.Thread.Sleep(1000);
                menuMuerteUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {  
        if(collision.collider.tag != "suelo"){
            string c = collision.collider.tag;
            if(c == "comida"){
                comida++;
                Debug.Log(comida);
                Destroy(collision.collider.gameObject);

                imagenProgreso.fillAmount = (float)0.1 * (float)comida;
                x = Convert.ToInt32(x * 1.1);
                y = Convert.ToInt32(y * 1.1);
                z = Convert.ToInt32(z * 1.1);
                jugador.transform.localScale = new Vector3(x,y,z);
                SoundManagerPlayer.PlaySounds("collision");
            }
            if(c == "enemigo"){
                vidas--;
                Debug.Log(vidas);
                Destroy(collision.collider.gameObject);
            }
        
        
        
        }
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
