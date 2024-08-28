using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intercepcion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objetivo;
    public GameObject prediccion;
    public float velocidad = 5;

    private Vector3 velRelativa;
    private Vector3 miVelocidad;
    private Vector3 velObjetivo;
    private Vector3 miPostAnterior;
    private Vector3 objPosAnterior;
    private Vector3 distanciaRelativa;
    private float tiempoIntercepcion;
    private Vector3 posFutura;
    private Vector3 posPrediccion;
    void Start()
    {
        miPostAnterior = transform.position;
        objPosAnterior = objetivo.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Calculamos el vector de ls IA
        miVelocidad = (transform.position - miPostAnterior) / Time.deltaTime;
        miPostAnterior = transform.position;

        //Calculamos el vector velocidd del objetivo
        velObjetivo = (objetivo.transform.position - objPosAnterior) / Time.deltaTime;
        objPosAnterior = objetivo.transform.position;

        //Calculamos la velocidad relativa entre los dos
        velRelativa = velObjetivo - miVelocidad;

        //Calculamos la distancia relativa
        distanciaRelativa = objetivo.transform.position - transform.position;

        //Calculamos el tiempo de intercepcion 
        tiempoIntercepcion = distanciaRelativa.magnitude / velRelativa.magnitude;

        //Calculamos el punto dond el objetivo estara en el futuro 
        posFutura = objetivo.transform.position + (velObjetivo * tiempoIntercepcion);

        posPrediccion = new Vector3(posFutura.x, transform.position.y, posFutura.z);

        transform.LookAt(posPrediccion);
        prediccion.transform.position = posPrediccion;

        //Nos movemos hacia el objetivo 
        transform.Translate(Time.deltaTime * velocidad * Vector3.forward);
    }
}
