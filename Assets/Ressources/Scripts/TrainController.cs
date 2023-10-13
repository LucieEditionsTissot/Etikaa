using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    
    private RailwayPointController _railwayPointController;
    public Transform[] FirstPath;
    public Transform[] RailwayPointInactivePath;
    public Transform[] RailwayPointActivePath;
    private Transform[] _nextPath;
    private Transform[] _finalPath = null;

    private int currentPointIndex = 0;
    public float TrainSpeed = 1.0f;
    
    private static TrainController _instance;
    public static TrainController Instance {
        get {
            if (TrainController._instance == null) {
                TrainController._instance = FindObjectOfType<TrainController>();
            }

            return TrainController._instance;
        }
    }

    private void Awake() {
        this._nextPath = this.RailwayPointInactivePath;
    }

    private void Start() {
        this._railwayPointController = RailwayPointController.Instance;

        this._railwayPointController.OnRailwayPointChanged += this._changeTrainRailway;
    }

    private void Update() {
        // Déplace le train vers le prochain point du chemin
        if (currentPointIndex < FirstPath.Length)
        {
            Transform targetPoint = FirstPath[currentPointIndex];
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPoint.position, TrainSpeed * Time.deltaTime);

            if (this.transform.position == targetPoint.position)
            {
                currentPointIndex++;
            }
        } else {
            if (_finalPath == null) {
                _finalPath = this._nextPath;
            }

            if (currentPointIndex - FirstPath.Length < _finalPath.Length) {
                Transform targetPoint = this._finalPath[currentPointIndex - FirstPath.Length];
                this.transform.position = Vector3.MoveTowards(this.transform.position, targetPoint.position, TrainSpeed * Time.deltaTime);

                if (this.transform.position == targetPoint.position)
                {
                    currentPointIndex++;
                }
            }

        }
    }

    private void _changeTrainRailway(bool newStatus) {
        if (newStatus) {
            this._nextPath = this.RailwayPointActivePath;
        } else {
            this._nextPath = this.RailwayPointInactivePath;
        }
    }
}
