using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour {
    private GameObject _body = null;

    private void Start() {
        var gnome = GameObject.Find("Gnome");
        var body = gnome.transform.Find("body").gameObject;
        _body = body;
    }

    private void Update() {
        var positionVector = _body.transform.position;
        const float z = 1.5f;
        transform.position = new Vector3(positionVector.x, positionVector.y, z);
    }
}
