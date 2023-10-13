using UnityEngine;

public class BillboardPrefab : MonoBehaviour
{
    public Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (mainCamera != null)
        {
            Vector3 lookAtDirection = transform.position - mainCamera.transform.position;

            transform.rotation = Quaternion.LookRotation(lookAtDirection);
        }
    }
}
