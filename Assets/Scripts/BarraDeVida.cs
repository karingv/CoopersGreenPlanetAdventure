using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>()      ;
        
    }
      
    public void cambiarVidaMaxima(float vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
    }

    public void cambiarVidaActual(float cantidadVida)
    {
        slider.value = cantidadVida;
    }

    public void inicializarBarraDeVida(float cantidadVida)
    {
        cambiarVidaMaxima(cantidadVida);
        cambiarVidaActual(cantidadVida);

    }

}
