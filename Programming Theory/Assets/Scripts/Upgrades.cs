using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private GameObject buttonObject;
    private Button self;
    [SerializeField] private GameObject buttonReference;
    private GameStateManager stateManager;
    [SerializeField] private float upgradeCost;
    [SerializeField] private Button[] buttonsToUnlock;

    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Button>();
        stateManager = GameObject.FindGameObjectWithTag("Game State Manager").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ButtonColorChecker();
    }

    public void OnButtonClicked()
    {
        if (stateManager.moneyBanked >= upgradeCost)
        {
            stateManager.moneyBanked -= upgradeCost;
            buttonObject.SetActive(false);
            buttonReference.SetActive(true);
            foreach (var button in buttonsToUnlock)
            {
                button.gameObject.SetActive(true);
            }
        }
    }

    public void ButtonColorChecker()
    {
        if (stateManager.moneyBanked < upgradeCost)
        {
            self.image.color = Color.gray;
        }
        else
        {
            self.image.color = Color.white;
        }
    }
}
