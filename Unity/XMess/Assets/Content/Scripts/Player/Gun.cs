using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float offset;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gunPoint;

    [SerializeField] private float shootDelay;
    private Coroutine coShootRoutine;

    private void Update()
    {
        GunRotation();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetButton("Fire1") && coShootRoutine == null)
        {
<<<<<<< HEAD
            SoundManager.Instance().PlayGunShot();
            GameObject go = Instantiate(bullet, gunPoint.position, Quaternion.identity);
            go.GetComponent<Bullet>().xDirection = Player.Instance().transform.localScale.x;
=======
            coShootRoutine = StartCoroutine(CoShoot());
>>>>>>> 5c766dc28fd482e3f62be6aa72266039fe1c5723
        }
    }

    private IEnumerator CoShoot()
    {
        GameObject go = Instantiate(bullet, gunPoint.position, transform.rotation);
        //go.transform.rotation = Quaternion.Euler(new Vector3(go.transform.rotation.x, go.transform.rotation.y, go.transform.rotation.z + Random.Range(-5f, 5f)));
        go.GetComponent<Bullet>().xDirection = Player.Instance().transform.localScale.x;
        yield return new WaitForSeconds(shootDelay);
        coShootRoutine = null;
    }

    private void GunRotation()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
}