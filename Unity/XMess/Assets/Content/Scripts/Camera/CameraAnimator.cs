using System.Collections;
using System.Collections.Generic;
using Systems.Singleton;
using UnityEngine;

public class CameraAnimator : Singleton<CameraAnimator>
{
    public Animator cameraAnimator;

    public void Shake()
    {
        cameraAnimator.SetTrigger("Shake");
    }
}