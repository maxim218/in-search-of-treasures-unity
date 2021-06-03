using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGame {
    public int[] Arr = null;
}

public class MapGenerate : MonoBehaviour {
    public GameObject groundPrefabElement = null;
    public GameObject groundMiddlePrefabElement = null;
    public GameObject floorPrefab = null;
    public GameObject moneyPrefab = null;

    private static string ModifyString(string jsonString) {
        // brackets
        const string leftBracket = "{";
        const string rightBracket = "}";
        // quote
        const char doubleQuote = '"';
        // build string
        string resultJsonString = leftBracket + doubleQuote + "Arr" + doubleQuote + ":" + jsonString + rightBracket;
        return resultJsonString;
    }
    
    private static string GetLevelContentJson() {
        // constants
        const string key = "LevelKey";
        const int defaultValue = -1;
        
        // get level number
        int levelInteger = PlayerPrefs.GetInt(key, defaultValue);
        Debug.Log("Level: " + levelInteger);

        try {
            // read json from file
            string fileName = "level_" + levelInteger + "_json";
            TextAsset asset = Resources.Load<TextAsset>(fileName);
            string jsonString = asset.text;
            return jsonString;
        } catch {
            return "[]";
        }
    }

    private void CreateWinMoney() {
        // position
        const float x = 0f;
        const float y = -24.5f;
        const float z = 21.9f;
        Vector3 position = new Vector3(x, y, z);
        // create
        GameObject moneyYouWin = Instantiate(moneyPrefab) as GameObject;
        moneyYouWin.transform.position = position;
    }

    private static void MakeMeWall(GameObject currentObject) {
        const string globalNameString = "WallsOfLevel";
        var globalWallsObj = GameObject.Find(globalNameString);
        currentObject.transform.SetParent(globalWallsObj.transform);
    }
    
    private void FloorElementCreate(Vector3 positionVector) {
        var floorObj = Instantiate(floorPrefab) as GameObject;
        floorObj.transform.position = positionVector;
        MakeMeWall(floorObj);
    }
    
    private void CreateMiddleGround(Vector3 positionVector, Vector3 rotationVector) {
        var middleGround = Instantiate(groundMiddlePrefabElement) as GameObject;
        middleGround.transform.position = positionVector;
        middleGround.transform.Rotate(rotationVector);
        MakeMeWall(middleGround);
    }
    
    private void CreateElement(Vector3 positionVector, Vector3 rotationVector) {
        var groundElement = Instantiate(groundPrefabElement) as GameObject;
        groundElement.transform.position = positionVector;
        groundElement.transform.Rotate(rotationVector);
        MakeMeWall(groundElement);
    }

    public GameObject theEnemyFlower = null;
    public GameObject theEnemySpider = null;
    public GameObject theEnemyBall = null;
    public GameObject theEnemyPistol = null;

    public bool prohibitEnemiesFlag = false;
    
    private void EnemyCreate(int enemyType, float posY) {
        // can I create
        if (prohibitEnemiesFlag) return;
        
        // z pos
        const float posZ = 21.9f;

        // x pos
        const float left = -3;
        const float right = 3;
        const float zero = 0;
        
        // flowers left
        if (enemyType == 111) {
            GameObject flowerA = Instantiate(theEnemyFlower) as GameObject;
            GameObject flowerB = Instantiate(theEnemyFlower) as GameObject;
            GameObject flowerC = Instantiate(theEnemyFlower) as GameObject;
            flowerA.transform.position = new Vector3(-3, posY, posZ);
            flowerB.transform.position = new Vector3(-1, posY, posZ);
            flowerC.transform.position = new Vector3(1, posY, posZ);
            return;
        }

        // flowers right
        if (enemyType == 222) {
            GameObject flowerA = Instantiate(theEnemyFlower) as GameObject;
            GameObject flowerB = Instantiate(theEnemyFlower) as GameObject;
            GameObject flowerC = Instantiate(theEnemyFlower) as GameObject;
            flowerA.transform.position = new Vector3(-1, posY, posZ);
            flowerB.transform.position = new Vector3(1, posY, posZ);
            flowerC.transform.position = new Vector3(3, posY, posZ);
            return;
        }

        // spider
        if (enemyType == 333) {
            GameObject spider = Instantiate(theEnemySpider) as GameObject;
            spider.transform.position = new Vector3(zero, posY, posZ);
            return;
        }

        // ball
        if (enemyType == 444) {
            GameObject ball = Instantiate(theEnemyBall) as GameObject;
            ball.transform.position = new Vector3(zero, posY, posZ);
            return;
        }

        // pistol left
        if (enemyType == 555) {
            GameObject pistol = Instantiate(theEnemyPistol) as GameObject;
            pistol.transform.position = new Vector3(left, posY, posZ);
            return;
        }

        // pistol right
        if (enemyType == 777) {
            GameObject pistol = Instantiate(theEnemyPistol) as GameObject;
            pistol.transform.position = new Vector3(right, posY, posZ);
            return;
        }
    }
    
    private void Start() {
        // you win object
        CreateWinMoney();
        
        // json of level
        string jsonString = GetLevelContentJson();
        jsonString = ModifyString(jsonString);
        Debug.Log("Json: " + jsonString);
        
        // make enemies of level
        LevelGame levelGame = JsonUtility.FromJson<LevelGame>(jsonString);
        int [] arr = levelGame.Arr;

        // pos Y for enemies
        float posY = -2.5f;
        const float enemyDeltaY = 5;
        
        // create all enemies
        foreach (int value in arr) {
            int enemyType = value;
            EnemyCreate(enemyType, posY);
            posY -= enemyDeltaY;
        }

        // pos Z
        const float zLeftRight = 150f;
        const float zMiddle = 193f;
        const float zFloor = 121f;
        
        // pos X
        const float middleX = 0f;
        const float leftX = -11.2f;
        const float rightX = 11.1f;
        
        // property Y
        const float deltaY = 1.74f;
        var y = 6f;
        
        // rotate vectors
        var rotateA = Vector3.zero;
        var rotateB = new Vector3(0, 0, 180);
        
        // create ground elements
        for (var i = 0; i < 20; i++) {
            // middle element
            var posMiddle = new Vector3(middleX, y, zMiddle);
            var condition = (i % 2 == 0);
            CreateMiddleGround(posMiddle, condition ? rotateA : rotateB);
            
            // left element
            var posLeft = new Vector3(leftX, y, zLeftRight);
            CreateElement(posLeft, rotateA);
            
            // right element
            var posRight = new Vector3(rightX, y, zLeftRight);
            CreateElement(posRight, rotateB);
            
            // change Y position
            y -= deltaY;
        }
        
        // create floor elements
        for (var i = -10; i <= 10; i++) {
            var x = i * 2.28f;
            var positionVector = new Vector3(x, y, zFloor);
            FloorElementCreate(positionVector);
        }
    }
}
