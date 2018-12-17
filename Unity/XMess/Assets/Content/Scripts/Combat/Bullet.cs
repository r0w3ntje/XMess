using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float destroyAfterSeconds;

    [HideInInspector] public float xDirection;

    private void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    private void Update()
    {
        transform.Translate(new Vector3(xDirection, 0f, 0f) * speed * Time.deltaTime);
    }
}