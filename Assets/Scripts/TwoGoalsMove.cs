using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoGoalsMove : MonoBehaviour {
    private Vector3 _posLeft = Vector3.zero;
    private Vector3 _posRight = Vector3.zero;

    private void Start() {
        // X pos
        const float xLeft = -3.5f;
        const float xRight = 3.5f;
        
        // Y pos
        var y = transform.position.y;

        // Z pos
        const float z = 21.9f;
        
        // vectors
        _posLeft = new Vector3(xLeft, y, z);
        _posRight = new Vector3(xRight, y, z);
    }

    public float speed = 0f;
    public bool goalFlag = false;
    
    private void Update() {
        // rotate head
        const float speedRotating = 100f;
        if(goalFlag)
            transform.Rotate(0, 0, speedRotating * Time.deltaTime);
        else 
            transform.Rotate(0, 0, -1 * speedRotating * Time.deltaTime);

        // move to target
        var targetPos = goalFlag ? _posLeft : _posRight;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        
        // change goal flag
        var distance = Vector2.Distance(targetPos, gameObject.transform.position);
        if (0.3f > distance) goalFlag = !goalFlag;
    }
}
