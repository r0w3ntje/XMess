using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float offset;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gunPoint;

    private void Update()
    {
        Shoot();
        //GunRotation();
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SoundManager.Instance().PlayGunShot();
            GameObject go = Instantiate(bullet, gunPoint.position, Quaternion.identity);
            go.GetComponent<Bullet>().xDirection = Player.Instance().transform.localScale.x;
        }
    }

    //private void GunRotation()
    //{
    //    Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    //    float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    //}
}