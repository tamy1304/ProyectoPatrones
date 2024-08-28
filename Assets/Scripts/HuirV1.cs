using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuirV1 : MonoBehaviour
{
    public float velocidad = 5;
    public Transform objetivo;

    private float x = 0;
    private float y = 0;
    private float z = 0;

    void Start()
    {
        y = transform.position.y;
    }


    void Update()
    {
        x = transform.position.x;
        z = transform.position.z;

        if (objetivo.position.x > x)
            x -= velocidad * Time.deltaTime;
            x += velocidad * Time.deltaTime;
        if (objetivo.position.z > z)
            z -= velocidad * Time.deltaTime;
        if (objetivo.position.z < z)
            z += velocidad * Time.deltaTime;

        transform.position = new Vector3(x, y, z);


    }
}
