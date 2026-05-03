using System;
using TMPro;
using UnityEngine;

public class UI_CoinDisplay : MonoBehaviour
{
    public CoinComponent coinComp;
    public TextMeshProUGUI textComponent;
   
    void Awake()
    {
        coinComp.OnCoinChanged += CoinComp_OnCoinChanged;
        coinComp.OnCoinInit += CoinComp_OnCoinInit;
    }

    private void CoinComp_OnCoinInit(int amount, int changedAmount)
    {
        textComponent.text = amount.ToString();
    }

    private void CoinComp_OnCoinChanged(int amount, int changedAmount)
    {
        textComponent.text = amount.ToString();
    }
}
