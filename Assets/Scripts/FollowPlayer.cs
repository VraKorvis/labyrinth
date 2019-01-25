using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    private Transform _transform;
    
    public Transform _playerT;
    public float speedFallow=10f;

    private void Awake() {
        _transform = GetComponent<Transform>();
        Fallow();
    }

    private void Fallow() {
        StartCoroutine(FallowToPlayer());
    }

    private IEnumerator FallowToPlayer() {
        while (true) {
            float z = _transform.position.z;
            _transform.position = Vector3.Lerp(_transform.position, _playerT.position, Time.deltaTime * speedFallow);
            Vector3 zPos = _transform.position;
            zPos.z = z;
            _transform.position = zPos;
           yield return new WaitForFixedUpdate();
        }
    }

    private void StopFallow(Transform playerT) {
        StopCoroutine(FallowToPlayer());
    }
}
