using System.Collections;
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
    public GameObject food;
    public GameObject menuMuerteUI;


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

            imagenProgreso.fillAmount = (float)0.1 * (float)comida;

            }
        if(c == "obstaculo"){
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
