using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsMouseOverCollider())
        {
            SceneManager.LoadScene(3);
        }

    }

    bool IsMouseOverCollider()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        return Physics.Raycast(ray, out hit) && hit.collider != null && hit.collider.gameObject == gameObject;
    }

}
