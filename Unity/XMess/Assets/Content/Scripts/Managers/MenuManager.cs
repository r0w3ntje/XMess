using System.Collections;
using System.Collections.Generic;
using Systems.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : Singleton<MenuManager>
{
    public void LoadToScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}