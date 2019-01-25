using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class TouchManager : MonoBehaviour {
    public static TouchManager instance;

    public Rigidbody2D _characterRB;
    public GameObject _mazeField;
    [Range(0f, 10f)] public float _horseSpeed;

    private Ray _ray;

    void Awake() {
        instance = this;
    }

    void Start() { }

    public void TurnTo(Turn turn) {
        if (_horseSpininngNow) {
            return;
        }

        switch (turn) {
            case Turn.Right:
               // _characterRB.transform.rotation = _characterRB.transform.rotation * Quaternion.Euler(0, 0, -90);
                StartCoroutine(HorseTurnCoroutine(-1));
               // StartCoroutine(TurnCoroutine(1));
                break;
            case Turn.Left:
                //_characterRB.transform.rotation = _characterRB.transform.rotation * Quaternion.Euler(0, 0, 90);
                StartCoroutine(HorseTurnCoroutine(1));
                // StartCoroutine(TurnCoroutine(-1));
                break;
        }
    }

    
    private bool _horseSpininngNow;
    public IEnumerator HorseTurnCoroutine(int sign) {
        float timeCount = 0.0f;
        _horseSpininngNow = true;
        Quaternion toRot = _characterRB.transform.rotation * Quaternion.Euler(0, 0, 90 * sign);
        while (timeCount < 1) {
            _characterRB.transform.rotation = Quaternion.Slerp(_characterRB.transform.rotation, toRot, timeCount * _horseSpeed);
            timeCount = timeCount + Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        _characterRB.transform.rotation = toRot;
        _horseSpininngNow = false;
        yield return null;
    }

    #region rotate field
    private bool _spininngNow;
    public IEnumerator TurnCoroutine(int sign) {
        float timeCount = 0.0f;
        _spininngNow = true;
        Quaternion toRot = _mazeField.transform.rotation * Quaternion.Euler(0, 0, 90 * sign);
        while (timeCount < 1) {
            _mazeField.transform.rotation = Quaternion.Slerp(_mazeField.transform.rotation, toRot, timeCount * _horseSpeed);
            timeCount = timeCount + Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _spininngNow = false;
        yield return null;
    }


    #endregion


    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // RaycastHit2D hit2D = Physics2D.Raycast(transform.position, -Vector2.up);

            if (_characterRB.position.x < pos.x) {
                TurnTo(Turn.Right);
            }
            else if (_characterRB.position.x > pos.x) {
                TurnTo(Turn.Left);
            }
        }
    }
}

public enum Turn {
    Right,
    Left
}