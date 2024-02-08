using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] int Score;
    public int[] CostInt;
    private int ClickScore = 1;
    public int[] CostBonus;


    public GameObject UpgradePanel;
    public GameObject ShopPanel;

    public TextMeshProUGUI[] CostText;
    public TextMeshProUGUI ScoreText;

    private void Start()
    {
        StartCoroutine(BonusShop());
    }

    public void OnClickButton()
    {
        Score += ClickScore;
    }

    private void Update()
    {
        ScoreText.text = Score + "";
    }

    public void OnClickBuyLevel()
    {
        if (Score >= CostInt[0])
        {
            Score -= CostInt[0];
            CostInt[0] *= 2;
            ClickScore *= 2;
            CostText[0].text = CostInt[0] + "$";
        }
    }

    public void OnClickBuyBonusShop()
    {
        if (Score >= CostInt[1])
        {
            Score -= CostInt[1];
            CostInt[1] *= 2;
            CostBonus[0] += 2;
            CostText[1].text = CostInt[1] + "$";
        }
    }

    IEnumerator BonusShop()
    {
        while(true)
        {
            Score += CostBonus[0];
            yield return new WaitForSeconds(1);
        }
    }
}
