using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour {
    private bool _flag = false;
    
    public void MethodLevelLoad(string sceneNameParam) {
        if (_flag) return;
        //////
        _sceneNameString = sceneNameParam;
        Debug.Log("Scene: " + _sceneNameString);
        _flag = true;
        StartCoroutine( LoadSceneAsync() );
    }

    private string _sceneNameString = "";
    
    private IEnumerator LoadSceneAsync() {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneNameString);
        while(!operation.isDone) yield return new WaitForSeconds(1);
    }
}
