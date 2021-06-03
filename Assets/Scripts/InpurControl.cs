using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InpurControl : MonoBehaviour {
    private bool _a = false;
    private bool _d = false;
    private bool _s = false;

    private void MakeAllFalse() {
        _a = false;
        _d = false;
        _s = false;
    }

    public GameObject bodyObject = null;
    private ForceControl _forceControlScript = null;

    private GnomeDead _script = null;
    
    private void Start() {
        _forceControlScript = bodyObject.GetComponent<ForceControl>();
        _script = GameObject.Find("Gnome").GetComponent<GnomeDead>();
    }

    private void KeysDownUp() {
        // down
        if (Input.GetKeyDown(KeyCode.A)) _a = true;
        if (Input.GetKeyDown(KeyCode.D)) _d = true;
        if (Input.GetKeyDown(KeyCode.S)) _s = true;
        // up
        if (Input.GetKeyUp(KeyCode.A)) _a = false;
        if (Input.GetKeyUp(KeyCode.D)) _d = false;
        if (Input.GetKeyUp(KeyCode.S)) _s = false;
    }

    public bool GetFlagS() {
        return _s;
    }
    
    private void Update() {
        // keys down up
        KeysDownUp();
        
        // gnome dead - prohibit keys
        if (_script.GetFlagDeath() == true) MakeAllFalse();

        // exists control body
        if (!_forceControlScript) return;
        
        // constants
        const float forceValueConst = 600f;
        const int rightNumber = 1;
        const int leftNumber = -1;
        const int middleNumber = 0;
        
        // move left
        if (_a) {
            _forceControlScript.ForceParamsSet(forceValueConst, leftNumber);
            return;
        } 
        
        // move right
        if (_d) {
            _forceControlScript.ForceParamsSet(forceValueConst, rightNumber);
            return;
        } 
        
        // zero
        _forceControlScript.ForceParamsSet(forceValueConst, middleNumber);
    }
}
