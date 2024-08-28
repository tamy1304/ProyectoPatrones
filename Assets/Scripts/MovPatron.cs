using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public struct SMovimiento
{
    public float rotacion;
    public float tiempo;
    public float velocidad;
    public float velRotacion;

    public SMovimiento(float pRotacion, float pTiempo, float pVelocidad, float pVelRotacion)
    {
        rotacion = pRotacion;
        tiempo = pTiempo;
        velocidad = pVelocidad;
        velRotacion = pVelRotacion;
    }
}

public class MovPatron : MonoBehaviour
{
    private int cantidadPasos;
    private List<SMovimiento> patron = new List<SMovimiento>();
    private float Tiempo = 0;
    private int indice = 0;
    private Vector3 direccion;
    private bool movimientoCompleto = true;
    public TMP_Text mensajeVictoria; 
    public Button[] botones; 

    void Start()
    {
        SetBotonesInteractivos(true); 
    }

    void FixedUpdate()
    {
        if (cantidadPasos == 0 || movimientoCompleto) return; 

        Tiempo += Time.deltaTime;
        if (Tiempo > patron[indice].tiempo)
        {
            Tiempo = 0;
            indice++;
            if (indice >= cantidadPasos)
            {
                movimientoCompleto = true; 
                SetBotonesInteractivos(false); 
                if (EsPatron213())
                {
                    mensajeVictoria.text = "¡Has llegado a la meta! ¡Has ganado el juego!";
                }
                else
                {
                    mensajeVictoria.text = "Aún no llegas a la meta, reinicia e inténtalo de nuevo.";
                }
                return;
            }
        }

        direccion = Quaternion.AngleAxis(patron[indice].rotacion, Vector3.up) * transform.forward;
        Quaternion rotOjetivo = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotOjetivo, patron[indice].velRotacion * Time.deltaTime);
        transform.Translate(transform.forward * patron[indice].velocidad * Time.deltaTime);
    }

    public void Patron123()
    {
        IniciarPatron();
        patron.Add(new SMovimiento(30, 2, 5, 3)); // Patrón 1
        patron.Add(new SMovimiento(-30, 2, 5, 2)); // Patrón 2
        patron.Add(new SMovimiento(0, 3, 5, 0)); // Patrón 3
        FinalizarPatron();
    }

    public void Patron132()
    {
        IniciarPatron();
        patron.Add(new SMovimiento(30, 2, 5, 3)); // Patrón 1
        patron.Add(new SMovimiento(0, 3, 5, 0)); // Patrón 3
        patron.Add(new SMovimiento(-30, 2, 5, 2)); // Patrón 2
        FinalizarPatron();
    }

    public void Patron231()
    {
        IniciarPatron();
        patron.Add(new SMovimiento(-30, 2, 5, 2)); // Patrón 2
        patron.Add(new SMovimiento(0, 3, 5, 0)); // Patrón 3
        patron.Add(new SMovimiento(30, 2, 5, 3)); // Patrón 1
        FinalizarPatron();
    }

    public void Patron213()
    {
        IniciarPatron();
        patron.Add(new SMovimiento(-30, 2, 5, 2)); // Patrón 2
        patron.Add(new SMovimiento(30, 2, 5, 3)); // Patrón 1
        patron.Add(new SMovimiento(0, 3, 5, 0)); // Patrón 3
        FinalizarPatron();
    }

    public void Patron321()
    {
        IniciarPatron();
        patron.Add(new SMovimiento(0, 3, 5, 0)); // Patrón 3
        patron.Add(new SMovimiento(-30, 2, 5, 2)); // Patrón 2
        patron.Add(new SMovimiento(30, 2, 5, 3)); // Patrón 1
        FinalizarPatron();
    }

    public void Patron312()
    {
        IniciarPatron();
        patron.Add(new SMovimiento(0, 3, 5, 0)); // Patrón 3
        patron.Add(new SMovimiento(30, 2, 5, 3)); // Patrón 1
        patron.Add(new SMovimiento(-30, 2, 5, 2)); // Patrón 2
        FinalizarPatron();
    }

    private void IniciarPatron()
    {
        if (movimientoCompleto)
        {
            patron.Clear();
            cantidadPasos = 0;
            indice = 0;
            movimientoCompleto = false;
            mensajeVictoria.text = ""; 
            SetBotonesInteractivos(false); 
        }
    }

    private void FinalizarPatron()
    {
        cantidadPasos = patron.Count;
        indice = 0;
    }

    private bool EsPatron213()
    {
        return patron.Count == 3 &&
               patron[0].rotacion == -30 && patron[1].rotacion == 30 && patron[2].rotacion == 0;
    }

    public void Reiniciar()
    {
        transform.position = new Vector3(0, 0.639999986f, 0);
        transform.rotation = Quaternion.identity;
        movimientoCompleto = true;
        patron.Clear();
        cantidadPasos = 0;
        indice = 0;
        mensajeVictoria.text = ""; 
        SetBotonesInteractivos(true); 
    }

    private void SetBotonesInteractivos(bool estado)
    {
        foreach (Button boton in botones)
        {
            boton.interactable = estado;
        }
    }
}
