using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingObject : MonoBehaviour
{
    // Inspector���� ���� ������ ���� ũ��
    public float power;

    // Inspector���� ���� ������ ����
    public Vector3 direction = Vector3.up;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody _rigidbody = collision.collider.GetComponentInChildren<Rigidbody>();

        if (_rigidbody != null)
        {
            // Inspector���� ������ �������� ���� ���մϴ�.
            Vector3 force = direction.normalized * power;
            _rigidbody.AddForce(force, ForceMode.Impulse);
        }
    }
}
