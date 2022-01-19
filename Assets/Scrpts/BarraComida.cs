using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraComida : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private Image imagenProgreso;
    [SerializeField] private Text nivelActual;

    // Start is called before the first frame update
    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "1ER NIVEL":
                nivelActual.text = "Lv.1";
                break;
            case "2DO NIVEL":
                nivelActual.text = "Lv.2";
                break;
            case "3ER NIVEL":
                nivelActual.text = "Lv.3";
                break;

        }
        imagenProgreso.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {

       
    }


}
