using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Systems.Singleton;
using UnityEngine;

public class UserInterfaceManager : Singleton<UserInterfaceManager>
{
    public void PopEffect(Transform _transform)
    {
        StartCoroutine(Effect(_transform));
    }

    private IEnumerator Effect(Transform _transform)
    {
        float delay = 0.05f;

        _transform.DOScale(1.2f, delay);
        yield return new WaitForSeconds(delay);
        _transform.DOScale(1f, delay);
    }
}