using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public float interactionRange = 3f; // Rango de interaccion
    public KeyCode interactionKey = KeyCode.E; // Tecla de interaccion
    public Collider conditionalColliderToActivate; // Collider a activar
    public Collider conditionalColliderToDeactivate; // Collider a desactivar

    private void Update()
    {
        if (Input.GetKeyDown(interactionKey) && IsPlayerInInteractionRange())
        {
            DestroyKey();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PerformRaycast();
        }

    }

    private bool IsPlayerInInteractionRange()
    {
        Vector3 playerPosition = Camera.main.transform.position;
        Vector3 bearPosition = transform.position;

        float distance = Vector2.Distance(new Vector2(playerPosition.x, playerPosition.z), new Vector2(bearPosition.x, bearPosition.z));

        return distance <= interactionRange;
    }

    private void DestroyKey()
    {
        Destroy(gameObject);

        if (conditionalColliderToActivate != null)
        {
            conditionalColliderToActivate.enabled = true;
        }

        if (conditionalColliderToDeactivate != null)
        {
            conditionalColliderToDeactivate.enabled = false;
        }
    }

    void PerformRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("llavecita uwu");
        }
    }
}

