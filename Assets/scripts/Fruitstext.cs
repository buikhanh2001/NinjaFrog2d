using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fruitstext : MonoBehaviour
{
    public TextMeshProUGUI Scoretext;
    private float puntos;
    private TextMeshProUGUI textMesh;
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {

        /*puntos += Time.deltaTime*/;
        textMesh.text = puntos.ToString("0");
        Scoretext.text = "Score : " + puntos.ToString();
        
    }
    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }
}
