using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Restart"))
        {
            MenuManager.Instance().LoadToScene(1);
        }
    }
}