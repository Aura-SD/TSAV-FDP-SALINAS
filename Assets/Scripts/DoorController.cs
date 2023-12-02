using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float anguloMaximoApertura = 90f; // Ángulo máximo de apertura de la puerta
    public float velocidadApertura = 2f; // Velocidad de apertura de la puerta
    public float distanciaMaxima = 3f; // Distancia máxima para interactuar con la puerta

    private bool abierta = false;
    private Quaternion rotacionInicial;
    private Quaternion rotacionAbierta;

    void Start()
    {
        rotacionInicial = transform.rotation;
        rotacionAbierta = rotacionInicial * Quaternion.Euler(0, anguloMaximoApertura, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanciaMaxima))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    if (abierta)
                        CerrarPuerta();
                    else
                        AbrirPuerta();
                }
            }
        }
    }

    void AbrirPuerta()
    {
        abierta = true;
    }

    void CerrarPuerta()
    {
        abierta = false;
    }

    void FixedUpdate()
    {
        if (abierta)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacionAbierta, Time.fixedDeltaTime * velocidadApertura);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacionInicial, Time.fixedDeltaTime * velocidadApertura);
        }
    }
}