using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerJugador : MonoBehaviour
{
    public Transform objetivo;
    public float rangoVision = 50;
    public float rangoFOV = 30;
    public Vector3 jugadorDesdeIA;
    public float distanciaAJugador = 0;
    public float angulo = 0;

    void Start()
    {
        
    }

    void Update()
    {
        bool visto = false;
        distanciaAJugador = Vector3.SqrMagnitude(transform.position-objetivo.position);
        if(distanciaAJugador <= (rangoVision * rangoVision))
        {
            jugadorDesdeIA = objetivo.position - transform.position;
            angulo = Vector3.Angle(transform.forward, jugadorDesdeIA);
            if (angulo <= rangoFOV)
            {
                visto = true;
            }
        }
        if (visto)
        {
            Debug.Log("Veo al jugador");
        }
        else
        {
            Debug.Log("No lo veo");
        }
    }
}
