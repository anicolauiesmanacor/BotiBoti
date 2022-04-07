using System;
using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
    private float vel;

    private void Start() {
        vel = 1f;
    }

    void Update () {
        transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime * vel);
    }
}