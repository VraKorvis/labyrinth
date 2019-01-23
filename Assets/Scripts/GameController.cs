using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;

    public GameObject menu;
    public GameObject gameField;

    public GameObject player;
    public Transform startPoint;

    public Camera _fogCamera;

    void Awake() {
        instance = this;
    }

    public void StartGame() {
        menu.SetActive(false);
        gameField.SetActive(true);
        GenerateMaze(new SimpleGenerate());
        UpdateFogMask();
        player.transform.position = startPoint.position;
    }

    private void UpdateFogMask() {
        _fogCamera.clearFlags = CameraClearFlags.Color;
    }

    public void EndGame() {
        menu.SetActive(true);
        gameField.SetActive(false);
    }

    private void GenerateMaze(IGenerateMazeStrategy strategy) { }

}