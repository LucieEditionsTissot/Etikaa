using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioKurtSceneScript : MonoBehaviour
{
    private GameObject player;
    
    private void Start() {
        this.player = GameObject.FindGameObjectWithTag("Player");

        // freeze player except rotation y
        Rigidbody rb = this.player.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
}
