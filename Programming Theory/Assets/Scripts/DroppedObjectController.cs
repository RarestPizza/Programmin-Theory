using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedObjectController : MonoBehaviour
{
    private GameStateManager stateManager;
    [SerializeField] private float itemValue;
    private Rigidbody body;

    void Start()
    {
        stateManager = GameObject.FindGameObjectWithTag("Game State Manager").GetComponent<GameStateManager>();
        body = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            stateManager.moneyBanked += (itemValue / 4);
            stateManager.incomeCalculations += (itemValue / 4);
            Destroy(gameObject);
        }
        else if (collision.collider.CompareTag("Drop Point"))
        {
            stateManager.moneyBanked += itemValue;
            stateManager.incomeCalculations += itemValue;
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.collider.CompareTag("Belt"))
        {
            body.constraints = body.constraints | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            body.constraints = body.constraints | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            
            transform.Translate(-0.1f, 0, 0);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Belt"))
        {
            body.constraints &= ~body.constraints | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            body.constraints &= ~body.constraints | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Upgrader"))
        {
            UpgraderController upgraderController = other.GetComponent<UpgraderController>();
            itemValue *= upgraderController.multiplier;
        }
    }
}
