using UnityEngine;
using TMPro;

public class PlayerCollectibleManager : MonoBehaviour
{
    public int coinCount = 0;
    public TextMeshProUGUI coinCounterText;

    void UpdateCoinCounter()
    {
        coinCounterText.text = "Pts: " + coinCount.ToString();
    }

    public void CollectCoin()
    {
        coinCount++;
        UpdateCoinCounter();
    }
}
