using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeDead : MonoBehaviour {
    private GameObject _head = null;
    private GameObject _leftHand = null;
    private GameObject _rightHand = null;
    
    private void Start() {
        _head = gameObject.transform.Find("head").gameObject;
        _leftHand = gameObject.transform.Find("hand_left").gameObject;
        _rightHand = gameObject.transform.Find("hand_right").gameObject;
    }
    
    private bool _isDead = false;

    public bool GetFlagDeath() {
        return _isDead;
    }
    
    public void KillGnome() {
        if (_isDead) return;
        UglyGnome();
        _isDead = true;
    }

    public GameObject bloodPrefab = null;
    
    private void UglyGnome() {
        Destroy(_head);
        Destroy(_leftHand);
        Destroy(_rightHand);
        var bloodObject = Instantiate(bloodPrefab) as GameObject;
        StartCoroutine( CountSecondsDead() );
    }

    private IEnumerator CountSecondsDead() {
        // wait
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
        // move scene
        const string sceneNameString = "DeadScene";
        gameObject.GetComponent<LevelLoaderScript>().MethodLevelLoad(sceneNameString);
    }
}
