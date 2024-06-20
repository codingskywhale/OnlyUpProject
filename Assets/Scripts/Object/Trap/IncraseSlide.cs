using UnityEngine;

public class IncreaseSlide : MonoBehaviour
{
    public float speedMultiplier;

    void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // X, Z ���� �ӵ��� �������Ѽ� �� �̲����� ����ϴ�.
            Vector3 velocity = rb.velocity;
            rb.velocity = new Vector3(velocity.x * speedMultiplier, velocity.y, velocity.z * speedMultiplier);
        }
    }
}
