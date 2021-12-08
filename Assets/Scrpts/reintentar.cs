using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reintentar : MonoBehaviour
{

    public GameObject menuMuerteUI;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void volverAinicio()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
