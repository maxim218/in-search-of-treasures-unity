using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {
    private void Start() {
        StartCoroutine( KillBullet() );
    }
    
    private IEnumerator KillBullet() {
        const float waitTime = 3f;
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
    
    private void Update() {
        const float speedMove = 2.3f;
        transform.Translate(0, speedMove * Time.deltaTime, 0);
    }
}
