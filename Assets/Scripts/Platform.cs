using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    public Rigidbody Rigidbody {  get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
}
