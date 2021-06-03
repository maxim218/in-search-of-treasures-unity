using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControl : MonoBehaviour {
    public GameObject[] arr;

    private int _length = 0;
    private LineRenderer _lineRenderer = null;
    
    private void Start() {
        _length = arr.Length;
        _lineRenderer = gameObject.GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _length;
        // world
        _lineRenderer.useWorldSpace = true;
        // color
        _lineRenderer.startColor = Color.gray;
        _lineRenderer.endColor = Color.gray;
        // width
        _lineRenderer.startWidth = 0.05f;
        _lineRenderer.endWidth = 0.05f;
    }

    private void ControlLine() {
        const float zPos = 15f;
        for (var i = 0; i < _length; i++) {
            var pos = arr[i].transform.position;
            pos.z = zPos;
            _lineRenderer.SetPosition(i, pos);
        }
    }

    private void Update() {
        ControlLine();
    }

    private void FixedUpdate() {
        ControlLine();
    }
}
