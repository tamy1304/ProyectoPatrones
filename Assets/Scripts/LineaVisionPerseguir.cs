using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineaVisionPerseguir : MonoBehaviour
{
    public float velocidad = 5;
    public Transform objetivo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(objetivo);
        transform.Translate(Vector3.forward* velocidad * Time.deltaTime);
    }
}
