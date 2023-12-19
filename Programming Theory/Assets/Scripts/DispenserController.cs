using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispenserController : MonoBehaviour
{
    [SerializeField] private GameObject dispenserPrefab;
    [SerializeField] private float dispenserSpeed;
    [SerializeField] private GameObject dispenserTypePrefab;
    [SerializeField] private Vector3 dispenserOffset;
    private Vector3 dropLocation;

    // Start is called before the first frame update
    void Start()
    {
        dropLocation = dispenserPrefab.transform.position + dispenserOffset;
        StartCoroutine(DropperCountdown());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DropperCountdown()
    {
        while (dispenserPrefab.activeInHierarchy)
        {
            yield return new WaitForSeconds(dispenserSpeed);

            Instantiate(dispenserTypePrefab, dropLocation, dispenserTypePrefab.transform.rotation);
        }
    }
}
