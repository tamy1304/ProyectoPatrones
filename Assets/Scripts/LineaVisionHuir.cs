using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineaVisionHuir : MonoBehaviour
{
    public float velocidad = 5;
    public Transform objetivo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 punto = objetivo.position - transform.position;
        Vector3 vision = transform.position - punto;

        vision.y = objetivo.position.y;
        transform.LookAt(vision);

        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }
}
