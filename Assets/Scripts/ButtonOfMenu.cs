using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOfMenu : MonoBehaviour {
    public int levelNumber = -1;

    private bool _allowFlag = false;

    private void OnMouseDown() {
        // block
        if (false == _canClick) return;
        
        // only one clk
        if (_allowFlag) return;
        _allowFlag = true;

        // not active
        BlockAllButtons();
        
        // store level number
        const string key = "LevelKey";
        PlayerPrefs.SetInt(key, levelNumber);
        Debug.Log("Level: " + levelNumber);
        
        // scene name
        bool condition = (levelNumber > 0);
        string sceneNameString = condition ? "SampleScene" : "MenuScene";
        
        // call loading
        GameObject obj = GameObject.Find("Main Camera");
        LevelLoaderScript script = obj.GetComponent<LevelLoaderScript>();
        script.MethodLevelLoad(sceneNameString);
    }

    private static void BlockAllButtons() {
        if (!(FindObjectsOfType(typeof(ButtonOfMenu)) is ButtonOfMenu[] arr)) return;
        foreach (var element in arr) element.gameObject.SetActive(false);
    }
    
    private bool _canClick = true;
    
    private void Start() {
        // menu and first level
        if (levelNumber == -1) return;
        if (levelNumber == 1) return;
        // get level info
        string key = "Lv" + levelNumber;
        string value = PlayerPrefs.GetString(key, "NO");
        // control button
        if (value != "NO") return;
        _canClick = false;
        Color colorValue = Color.gray;
        gameObject.GetComponent<SpriteRenderer>().color = colorValue;
    }
}
