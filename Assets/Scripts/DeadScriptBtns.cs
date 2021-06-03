using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadScriptBtns : MonoBehaviour {
    private bool _canYouClick = true;

    private const string SceneGame = "SampleScene";
    private const string SceneMenu = "MenuScene";

    public void BtnRestartClick() {
        if (!_canYouClick) return;
        const string message = "Restart Click";
        Debug.Log(message);
        _canYouClick = false;
        gameObject.GetComponent<LevelLoaderScript>().MethodLevelLoad(SceneGame);
    }

    public void BtnMenuClick() {
        if (!_canYouClick) return;
        const string message = "Menu Click";
        Debug.Log(message);
        _canYouClick = false;
        gameObject.GetComponent<LevelLoaderScript>().MethodLevelLoad(SceneMenu);
    }
}
