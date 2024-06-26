using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject attackHitbox;
    [SerializeField] private float attackForce;
    [SerializeField] private float attackActiveTime = 0.1f;
    [SerializeField] private float attackDelay;
    bool isAttacking = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * attackForce, ForceMode.Impulse);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && isAttacking == false)
        {
            StartCoroutine(nameof(ActiveHitbox));
        }
    }

    IEnumerator ActiveHitbox()
    {
        isAttacking = true;
        attackHitbox.SetActive(true);

        yield return new WaitForSeconds(attackActiveTime);
        attackHitbox.SetActive(false);

        yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
    }
}
