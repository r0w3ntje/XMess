using System.Collections;
using System.Collections.Generic;
using Systems.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : Singleton<MenuManager>
{
    private void Awake()
    {
        DontDestroyOnLoad(transform);
    }

    public void LoadToScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}