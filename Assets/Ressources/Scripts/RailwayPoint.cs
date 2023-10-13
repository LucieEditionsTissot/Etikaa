using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailwayPoint : MonoBehaviour
{

    public GameObject railwayPoint;

    public delegate void RailwayPointChanged (bool newStatus);
    public event RailwayPointChanged OnRailwayPointChanged;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the e key is pressed, send event
        if (Input.GetKeyDown(KeyCode.E))
        {
            EventManager.TriggerEvent("RailwayPoint");
        }
    }
}
