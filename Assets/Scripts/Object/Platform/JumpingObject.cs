using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingObject : MonoBehaviour
{
    // Inspector에서 설정 가능한 힘의 크기
    public float power;

    // Inspector에서 설정 가능한 방향
    public Vector3 direction = Vector3.up;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody _rigidbody = collision.collider.GetComponentInChildren<Rigidbody>();

        if (_rigidbody != null)
        {
            // Inspector에서 설정된 방향으로 힘을 가합니다.
            Vector3 force = direction.normalized * power;
            _rigidbody.AddForce(force, ForceMode.Impulse);
        }
    }
}
