using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour, Interactable
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

    public Transform MovingLever;
    public int InactiveLeverAngle = 30;
    public int ActiveLeverAngle = -30;

    private static LeverController _instance;
    public static LeverController Instance {
        get {
            if (LeverController._instance == null) {
                LeverController._instance = FindObjectOfType<LeverController>();
            }

            return LeverController._instance;
        }
    }

    public void Interact() {
        Debug.Log("Interact");
        this.IsRailwayPointActive = !this.IsRailwayPointActive;

        if (this.IsRailwayPointActive) {
            this.MovingLever.localRotation = Quaternion.Euler(ActiveLeverAngle, 0, 0);
        } else {
            this.MovingLever.localRotation = Quaternion.Euler(InactiveLeverAngle, 0, 0);
        }
    }
}
