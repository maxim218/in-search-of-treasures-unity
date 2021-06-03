using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyControl : MonoBehaviour {
    private GameObject _targetObj = null;
    
    private void Start() {
        var gnome = GameObject.Find("Gnome");
        var body = gnome.transform.Find("body").gameObject;
        _targetObj = body;
    }

    private bool _winFlag = false;
    
    private void Update() {
        // is already win
        if (_winFlag) return;
        
        // get positions
        Vector2 posA = gameObject.transform.position;
        Vector2 posB = _targetObj.transform.position;
        
        // distance
        float distance = Vector2.Distance(posA, posB);
        
        // hit control
        if (!(distance < 2.5f)) return;
        YouWin();
        _winFlag = true;
    }

    private void YouWin() {
        Debug.Log("Win");
        SaveResult();
        StartCoroutine( CountYouWin() );
    }

    private static void SaveResult() {
        // constants
        const string key = "LevelKey";
        const int defaultValue = -1;
        
        // get level number
        int levelInteger = PlayerPrefs.GetInt(key, defaultValue);

        // next level int
        int nextLevelInt = 1 + levelInteger;
        
        // save to store
        PlayerPrefs.SetString("Lv" + nextLevelInt, "YES");
    }
    
    private static IEnumerator CountYouWin() {
        // wait
        yield return new WaitForSeconds(0.7f);
        // move scene
        GameObject gnome = GameObject.Find("Gnome");
        gnome.GetComponent<LevelLoaderScript>().MethodLevelLoad("YouWinScene");
    }
}
