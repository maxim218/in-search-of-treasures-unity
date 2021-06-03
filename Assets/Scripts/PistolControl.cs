using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolControl : MonoBehaviour {
    private GameObject _targetObj = null;
    
    private void Start() {
        // target body
        var gnome = GameObject.Find("Gnome");
        var body = gnome.transform.Find("body").gameObject;
        _targetObj = body;
        // run fire
        StartCoroutine( AsyncFire() );
    }

    public GameObject bulletPrefab = null;
    
    private IEnumerator AsyncFire() {
        while (true) {
            // wait
            yield return new WaitForSeconds(1);
            // bullet
            GameObject bullet = Instantiate(bulletPrefab) as GameObject;
            bullet.transform.position = transform.TransformPoint(Vector3.up * 1.2f);
            bullet.transform.up = gameObject.transform.up;
        }
    }
    
    private void Update() {
        // look to goal
        Vector2 posA = _targetObj.transform.position;
        Vector2 posB = gameObject.transform.position;
        Vector2 posDelta = posA - posB;
        transform.up = posDelta;
    }
}
