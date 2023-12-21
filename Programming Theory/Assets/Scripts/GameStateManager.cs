using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    private float incomePerSecond;
    public static float incomeCalculations { get;  set; }
    private TextMeshProUGUI incomePerSecondText = null;
    private TextMeshProUGUI moneyBankedText = null;

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

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (incomePerSecondText == null)
            {
                incomePerSecondText = GameObject.Find("Income Text").GetComponent<TextMeshProUGUI>();
            }
            if (moneyBankedText == null)
            {
                moneyBankedText = GameObject.Find("Money Text").GetComponent<TextMeshProUGUI>();
            }
        }

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
        if (incomePerSecondText != null)
        {
            incomePerSecondText.text = ("Income: $" + incomePerSecond + "/sec");
        }
        if (moneyBankedText != null)
        {
            moneyBankedText.text = ("Money: $" + MoneyBanked);
        }
    }
}
