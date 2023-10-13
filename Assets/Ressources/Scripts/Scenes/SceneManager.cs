using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private static SceneManager _instance;
    [SerializeField] private List<GameObject> scenePrefabs;
    private GameObject currentScene;
    [SerializeField] private GameObject player;

    public static SceneManager Instance()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<SceneManager>();
            if (_instance == null)
            {
                GameObject go = new GameObject("SceneManager");
                _instance = go.AddComponent<SceneManager>();
            }
        }

        return _instance;
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        LoadScene("TrolleyDilemma");
    }

    public void LoadScene(string sceneName)
    {
        foreach (GameObject scenePrefab in scenePrefabs)
        {
            if (scenePrefab.name == sceneName)
            {
                Destroy(currentScene);
                currentScene = Instantiate(scenePrefab);
            }
        }
        player.transform.position = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
    }

}
