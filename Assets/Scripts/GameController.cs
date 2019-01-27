using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance;

    public GameObject player;
    public Transform startPoint;

    public Camera _fogCamera;

    void Awake() {
        instance = this;
        //DontDestroyOnLoad(this);
    }

    public void StartGame() {
        GenerateMaze(new SimpleGenerate());
        UpdateFogMask();
        player.transform.position = startPoint.position;
    }

    private void UpdateFogMask() {
        _fogCamera.clearFlags = CameraClearFlags.Color;
    }

    public void EndGame() {
        SceneManager.LoadScene(0);
    }

    private void GenerateMaze(IGenerateMazeStrategy strategy) { }

}