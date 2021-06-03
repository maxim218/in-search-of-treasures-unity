using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceControl : MonoBehaviour {
    private Rigidbody2D _rigidbody2D = null;

    private void Start() {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }
    
    public float forceValue = 0f;
    public int vectorOfForce = 0;

    public void ForceParamsSet(float forceValueParam, int vectorOfForceParam) {
        forceValue = forceValueParam;
        vectorOfForce = vectorOfForceParam;
    }
    
    private void FixedUpdate() {
        var forceVector = Vector2.zero;
        switch (vectorOfForce) {
            case 1:
                forceVector = new Vector2(forceValue, 0);
                break;
            case -1:
                forceVector = new Vector2(-1 * forceValue, 0);
                break;
        }
        _rigidbody2D.AddForce(forceVector);
    }
}
