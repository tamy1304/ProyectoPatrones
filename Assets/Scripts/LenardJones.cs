using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LenardJones : MonoBehaviour
{
    public Transform objetivo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 r= objetivo.position - transform.position;

        float A = 700;
        float B = 250;
        float n = 3;
        float m = 2;
        float d = r.magnitude / 5;
        float U = -A / Mathf.Pow(d, n) + B / Mathf.Pow(d, m);
        
        if (U<-10)
            U = -10;
        if (U >10) 
            U = 10;

        transform.LookAt(objetivo);

        transform.Translate(Vector3.forward * U * Time.deltaTime);

        Debug.Log(U);
    }
}
