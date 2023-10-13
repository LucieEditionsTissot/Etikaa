using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailwayPointController : MonoBehaviour
{
    public delegate void RailwayPointChanged (bool newStatus);
    public event RailwayPointChanged OnRailwayPointChanged;

    private bool _isRailwayPointActive = false;
    public bool IsRailwayPointActive {
        get { return _isRailwayPointActive; }
        set {
            _isRailwayPointActive = value;
            if (this.OnRailwayPointChanged != null)
                this.OnRailwayPointChanged.Invoke(_isRailwayPointActive);
        }
    }

    private static RailwayPointController _instance;
    public static RailwayPointController Instance {
        get {
            if (RailwayPointController._instance == null) {
                RailwayPointController._instance = FindObjectOfType<RailwayPointController>();
            }

            return RailwayPointController._instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.IsRailwayPointActive = !this.IsRailwayPointActive;
        }
    }
}
