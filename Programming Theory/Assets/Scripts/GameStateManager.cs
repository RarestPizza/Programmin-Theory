using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    private float incomePerSecond;
    public static float incomeCalculations { get;  set; }
    [SerializeField] private TextMeshProUGUI incomePerSecondText;

    private static float m_moneyBanked = 0.0f;
    public static float MoneyBanked
    { 
        get { return m_moneyBanked; } 
        
        set
        {
            if (m_moneyBanked + value < 0.0f)
            {
                Debug.Log(value);
            }
            else if (m_moneyBanked + value < float.MaxValue)
            {
                m_moneyBanked = value;
                Debug.Log(value);
            }
            else if (m_moneyBanked + value > float.MaxValue)
            {
                m_moneyBanked = float.MaxValue;
                Debug.Log(value);
            }
        }
    }
    [SerializeField] private TextMeshProUGUI moneyBankedText;

    // Start is called before the first frame update
    void Start()
    {
        incomePerSecond = 0.0f;
        incomeCalculations = 0.0f;
        MoneyBanked = 0.0f;
        StartCoroutine(IncomeCalculations());
    }

    // Update is called once per frame
    void Update()
    {
        ChangeUIText();
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

    void ChangeUIText()
    {
        incomePerSecondText.text = ("Income: $" + incomePerSecond + "/sec");
        moneyBankedText.text = ("Money: $" + MoneyBanked);
    }
}
