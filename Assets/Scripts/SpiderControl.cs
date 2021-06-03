using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderControl : MonoBehaviour {
    private GameObject _targetObj = null;
    
    private void Start() {
        var gnome = GameObject.Find("Gnome");
        var body = gnome.transform.Find("body").gameObject;
        _targetObj = body;
    }

    public float speedMove = 0f;
    
    private void Update() {
        // get X pos
        var spiderPos = transform.position.x;
        var bodyPos = _targetObj.transform.position.x;
        
        // compare and move
        if (spiderPos < bodyPos) 
            transform.Translate(speedMove * Time.deltaTime, 0, 0);
        else
            transform.Translate(-1 * speedMove * Time.deltaTime, 0, 0);
    }
}
