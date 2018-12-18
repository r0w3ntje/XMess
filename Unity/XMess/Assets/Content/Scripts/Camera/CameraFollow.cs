using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private bool followX, followY, followZ;

    private Vector3 startCameraPos;

    private void Start()
    {
        startCameraPos = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(followX ? target.position.x : startCameraPos.x, followY ? target.position.y : startCameraPos.y, followZ ? target.position.z : startCameraPos.z);
    }
}