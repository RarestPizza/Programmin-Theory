using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResouceController : DroppedObjectController
{
    [SerializeField] private GameObject displayTextPrefab;
    private GameObject instantiatedDisplayTextPrefab;
    private TextMeshPro displayText;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        instantiatedDisplayTextPrefab = Instantiate(displayTextPrefab);
        displayText = instantiatedDisplayTextPrefab.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (instantiatedDisplayTextPrefab != null)
        {
            displayText.text = ("$" + itemValue);
            instantiatedDisplayTextPrefab.transform.position = transform.position + new Vector3(0, 0, 1f);
        }
        if (transform.position.y <= -10f)
        {
            Destroy(gameObject);
        }
    }
}
