﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    void FixedUpdate()
    {
        transform.LookAt(target);
    }
}
