using UnityEngine;

public class IncreaseSlide : MonoBehaviour
{
    public float speedMultiplier;

    void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // X, Z 축의 속도를 증가시켜서 더 미끄럽게 만듭니다.
            Vector3 velocity = rb.velocity;
            rb.velocity = new Vector3(velocity.x * speedMultiplier, velocity.y, velocity.z * speedMultiplier);
        }
    }
}
