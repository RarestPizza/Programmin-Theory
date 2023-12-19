using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public float incomePerSecond;
    public float incomeCalculations;
    [SerializeField] private TextMeshProUGUI incomePerSecondText;

    public float moneyBanked;
    [SerializeField] private TextMeshProUGUI moneyBankedText;

    // Start is called before the first frame update
    void Start()
    {
        incomePerSecond = 0.0f;
        incomeCalculations = 0.0f;
        moneyBanked = 0.0f;
        StartCoroutine(IncomeCalculations());
    }

    // Update is called once per frame
    void Update()
    {
        incomePerSecondText.text = ("Income: $" + incomePerSecond + "/sec");
        moneyBankedText.text = ("Money: $" + moneyBanked);
    }

    IEnumerator IncomeCalculations()
    {
        while(true)
        {
            float previousIncome = incomeCalculations;
            yield return new WaitForSeconds(1);
            incomePerSecond = Mathf.Abs(previousIncome - incomeCalculations);
        }
    }
}
