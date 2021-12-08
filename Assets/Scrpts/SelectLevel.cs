using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public GameObject SelectLevelUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void go2Level1()
    {
       SceneManager.LoadScene("1ER NIVEL");

    }

    public void go2Level2()
    {
        SceneManager.LoadScene("2DO NIVEL");
    }

    public void go2Level3()
    {
        SceneManager.LoadScene("3ER NIVEL");
    }

    public void goBack()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
