using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Systems.Singleton;
using UnityEngine;

public class CameraShake : Singleton<CameraShake>
{
    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(CoShake(duration, magnitude));
    }

    private IEnumerator CoShake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
    }
}