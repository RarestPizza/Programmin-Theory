using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedObjectController : MonoBehaviour
{
    [SerializeField] protected float itemValue;
    protected Rigidbody body;

    protected void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            GameStateManager.MoneyBanked += (itemValue / 4);
            GameStateManager.incomeCalculations += (itemValue / 4);
            Destroy(gameObject);
        }
        else if (collision.collider.CompareTag("Drop Point"))
        {
            GameStateManager.MoneyBanked += itemValue;
            GameStateManager.incomeCalculations += itemValue;
            Destroy(gameObject);
        }
    }

    protected void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Belt"))
        {
            body.constraints = body.constraints | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            body.constraints = body.constraints | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            
            transform.Translate(-0.1f, 0, 0);
        }
    }

    protected void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Belt"))
        {
            body.constraints &= ~body.constraints | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            body.constraints &= ~body.constraints | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
    }
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Upgrader"))
        {
            UpgraderController upgraderController = other.GetComponent<UpgraderController>();
            itemValue *= upgraderController.multiplier;
        }
    }
}
