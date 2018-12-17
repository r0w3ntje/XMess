using System.Collections;
using System.Collections.Generic;
using Systems.Singleton;
using UnityEngine;

public class Controls : Singleton<Controls>
{
    public KeyCode left, right, jump, shoot, activateSuperPickup;
}