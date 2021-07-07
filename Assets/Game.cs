using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    // clicker
    [Header("clicker")]
    public Text scoreText;
    public float currentScore;
    public float hitPower;
    public float scoreIncreasedPerSecond;
    public float x;

    // shop
    [Header("shop")]
    public int shop1Price;
    public Text shop1Text;
    public int shop2Price;
    public Text shop2Text;

    // amount
    [Header("amount")]
    public Text amount1Text;
    public int amount1;
    public float amount1Profit;
    public Text amount2Text;
    public int amount2;
    public float amount2Profit;

    // upgrade
    [Header("upgrade")]
    public float upgradePrice;
    public Text upgradeText;

    // Start is called before the first frame update
    void Start()
    {
        // clicker
        currentScore = 0;
        hitPower = 1;
        scoreIncreasedPerSecond = 1;
        x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // clicker
        scoreIncreasedPerSecond = x * Time.deltaTime;
        currentScore += scoreIncreasedPerSecond;
        scoreText.text = $"{(int)currentScore} $";

        // shop
        shop1Text.text = $"Tier 1: {shop1Price} $";
        shop2Text.text = $"Tier 2: {shop2Price} $";

        // amount
        amount1Text.text = $"Tier 1: {amount1} arts $: {amount1Profit}/s";
        amount2Text.text = $"Tier 2: {amount2} arts $: {amount2Profit}/s";

        // upgrade
        upgradeText.text = $"Cost: {upgradePrice}$";

    }

    public void Hit()
    {
        currentScore += hitPower;
    }

    public void Shop1()
    {
        if (currentScore >= shop1Price)
        {
            currentScore -= shop1Price;
            amount1 += 1;
            amount1Profit += 1;
            x += 1;
            shop1Price += 25;
        }
    }
    public void Shop2()
    {
        if (currentScore >= shop2Price)
        {
            currentScore -= shop2Price;
            amount2 += 1;
            amount2Profit += 5;
            x += 5;
            shop2Price += 125;
        }
    }

    public void Upgrade()
    {
        if (currentScore >= upgradePrice)
        {
            currentScore -= upgradePrice;
            hitPower *= 2;
            upgradePrice *= 3;
        }
    }
}
