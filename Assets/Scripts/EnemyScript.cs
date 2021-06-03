using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public float hitDistance = 0f;
    
    private GameObject _body = null;
    private GnomeDead _script = null;
    
    private void Start() {
        var gnome = GameObject.Find("Gnome");
        _script = gnome.GetComponent<GnomeDead>();
        var body = gnome.transform.Find("body").gameObject;
        _body = body;
    }

    private void ControlHitting() {
        Vector2 posA = gameObject.transform.position;
        Vector2 posB = _body.transform.position;
        var distance = Vector2.Distance(posA, posB);
        if (distance < hitDistance) _script.KillGnome();
    }

    private void Update() {
        ControlHitting();
    }

    private void FixedUpdate() {
        ControlHitting();
    }
}
