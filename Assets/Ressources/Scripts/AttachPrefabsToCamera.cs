using UnityEngine;

public class AttachPrefabsToCamera : MonoBehaviour
{
    public GameObject prefab1; // Alpagito 1
    public Vector3 positionOffset1 = new Vector3(0.52f, -1.43f, 2.01f); // Position de l'offset Alpagito 1
    public Quaternion rotationOffset1 = Quaternion.identity; // Rotation de l'offset Alpagito 1

    public GameObject prefab2; // Alpagito 2
    public Vector3 positionOffset2 = new Vector3(1.21f, -1.43f, 2.01f); // Position de l'offset Alpagito 2
    public Quaternion rotationOffset2 = Quaternion.identity; // Rotation de l'offset Alpagito 1

    public Camera mainCamera;
    private GameObject attachedPrefab1; // Point d'attache Alpagito 1
    private GameObject attachedPrefab2; // Point d'attache Alpagito 2

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {
        if (prefab1 != null && mainCamera != null)
        {
            attachedPrefab1 = Instantiate(prefab1, CalculatePosition(positionOffset1), rotationOffset1);
            attachedPrefab1.transform.parent = mainCamera.transform;
        }

        if (prefab2 != null && mainCamera != null)
        {
            attachedPrefab2 = Instantiate(prefab2, CalculatePosition(positionOffset2), rotationOffset2);
            attachedPrefab2.transform.parent = mainCamera.transform;
        }
    }

    void Update()
    {
        if (attachedPrefab1 != null && mainCamera != null)
        {
            attachedPrefab1.transform.position = CalculatePosition(positionOffset1);
        }
        if (attachedPrefab2 != null && mainCamera != null)
        {
            attachedPrefab2.transform.position = CalculatePosition(positionOffset2);
        }

    }

    Vector3 CalculatePosition(Vector3 positionOffset)
    {
        Vector3 position = mainCamera.transform.position + mainCamera.transform.forward * positionOffset.z;
        position += mainCamera.transform.right * positionOffset.x;
        position += mainCamera.transform.up * positionOffset.y;
        return position;
    }
}
