using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnMoveScene : MonoBehaviour {
    public string sceneNameString = "";
    
    private void OnMouseDown() {
        if ("EXIT_GAME" == sceneNameString) {
            const string msg = "Close Application";
            Debug.Log(msg);
            Application.Quit();
        } else {
            GameObject cameraObj = GameObject.Find("Main Camera");
            LevelLoaderScript script = cameraObj.GetComponent<LevelLoaderScript>();
            if (script) {
                script.MethodLevelLoad(sceneNameString);
            } else {
                const string notFoundMessage = "Script not found";
                Debug.Log(notFoundMessage);
            }
        }
    }
}
