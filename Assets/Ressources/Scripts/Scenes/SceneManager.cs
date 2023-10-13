using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    //singleton

    private static SceneManager _instance;

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

}
