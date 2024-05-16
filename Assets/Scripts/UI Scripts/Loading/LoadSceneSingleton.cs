using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneSingleton : MonoBehaviour
{
    public static LoadSceneSingleton _instance;
    public static LoadSceneSingleton Instance { get { return _instance; } }

    [SerializeField] private string sceneName;

    public string SceneName => sceneName;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;

            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetSceneName(string sceneName)
    {
        this.sceneName = sceneName;
    }
}
