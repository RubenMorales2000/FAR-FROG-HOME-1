using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraProgreso : MonoBehaviour
{
    [Header ("Referencias UI")] 
    [SerializeField] private Image imagenProgreso;
    [SerializeField] private Text nivelActual;

    [SerializeField] private Transform player;
    [SerializeField] private Transform liniaEnd;

    private Vector3 liniaEndPos;

    private float distanciaTotal;


    // Start is called before the first frame update
    void Start()
    {
        liniaEndPos = liniaEnd.position;
        distanciaTotal = getDistance();

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x >= liniaEndPos.x)
        {
            float newDistancia = getDistance();
            float valorProgreso = Mathf.InverseLerp(distanciaTotal, 0f, newDistancia);

            UpdateProgreso(valorProgreso);
        }

    }

    private float getDistance()
    {
        return Vector3.Distance(player.position, liniaEnd.position);
    }

    private void UpdateProgreso(float valor)
    {
        imagenProgreso.fillAmount = valor;
    }
}
