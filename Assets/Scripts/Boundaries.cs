﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7f, 7f), Mathf.Clamp(transform.position.y, -2f, 2f), transform.position.z);

    }
}
