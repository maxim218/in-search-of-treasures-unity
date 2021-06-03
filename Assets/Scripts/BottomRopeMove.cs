using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomRopeMove : MonoBehaviour {
    public GameObject cameraObject = null;
    public float speedDown = 0f;
    public float prohibitPos = 0f;
    
    private InpurControl _script = null;

    private void Start() {
        _script = cameraObject.GetComponent<InpurControl>();
    }

    private void Update() {
        // control key bottom
        var bottomMoveFlag = _script.GetFlagS();
        if (!bottomMoveFlag) return;
        
        // control position prohibit
        var currentPos = transform.position.y;
        if (currentPos < prohibitPos) return;
        
        // move element down
        transform.Translate(0, speedDown * Time.deltaTime, 0);
    }
}
