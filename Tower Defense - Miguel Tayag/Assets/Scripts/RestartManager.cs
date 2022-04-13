using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    public GameObject uiRoot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        uiRoot.SetActive(false);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}