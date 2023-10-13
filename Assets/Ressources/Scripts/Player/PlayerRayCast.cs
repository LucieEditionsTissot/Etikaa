using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    [SerializeField] float rayDistance = 10f;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        //shoot a raycast where the player is looking
        if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out hit, rayDistance))
        {
            Debug.DrawRay(Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)).origin, Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)).direction * rayDistance, Color.red);
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Debug.Log(hit.collider.gameObject.name);
                if(hit.collider.gameObject.tag == "Interactable")
                {
                    hit.collider.gameObject.GetComponent<Interactable>()?.Interact();
                }
            }
        }
        
    }
}