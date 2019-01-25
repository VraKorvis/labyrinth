using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class InputController : MonoBehaviour {
    private Rigidbody2D _characterRB;
    private Transform _transform;
    private Vector2 _dest;

    [SerializeField] [Range(0, 1)] private float lerpConst;
    [SerializeField] [Range(0, 10)] private float speed = 5f;

    void Awake() {
        _characterRB = GetComponent<Rigidbody2D>();
        _transform = transform;
        _dest = _transform.position;
    }

    private void Move() {
        Vector2 p = Vector2.MoveTowards(transform.position, _dest, Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.RightArrow)) {
            _dest = (Vector2) _transform.position + Vector2.right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            _dest = (Vector2) _transform.position + Vector2.left;
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            _dest = (Vector2) _transform.position + Vector2.down;
        }
        else if (Input.GetKey(KeyCode.UpArrow)) {
            _dest = (Vector2) _transform.position + Vector2.up;
        }
        else {
            return;
        }

        _characterRB.MovePosition(p);
    }

    public void MoveAndroid() {
        Vector2 p = Vector2.MoveTowards(transform.position, _dest, Time.deltaTime * speed);
        _characterRB.MovePosition(p);
        _dest = (Vector2) _transform.position + (Vector2) _transform.up;
    }

    void FixedUpdate() {
        float xAxisRaw = Input.GetAxisRaw("Horizontal");
        float yAxisRaw = Input.GetAxisRaw("Vertical");
        //Vector2 movement = new Vector2(xAxisRaw, yAxisRaw);
        ////characterRB.velocity = movement;
        //characterRB.velocity = Vector2.Lerp(characterRB.velocity, movement*speed, lerpConst);
//#if UNITY_EDITOR
//        Move();
//#elif UNITY_ANDROID
//              MoveAndroid();
//#endif
        MoveAndroid();
    }
}

public enum MoveDirection {
    LEFT,
    RIGHT,
    UP,
    DOWN
}