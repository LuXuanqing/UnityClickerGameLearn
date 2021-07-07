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

        // set default value befor loading
        // 读取的时候已经设置了默认值，这一步好像是多余的？
        // shop1Price = 1;
        // shop2Price = 2;
        // amount1 = 0;
        // amount1Profit = 1;
        // amount2 = 0;
        // amount2Profit = 5;

        // reset line
        // PlayerPrefs.DeleteAll();

        // load
        currentScore = PlayerPrefs.GetInt("currentScore", 0);
        hitPower = PlayerPrefs.GetInt("hitPower", 1);
        x = PlayerPrefs.GetInt("x", 0);
        upgradePrice = PlayerPrefs.GetInt("upgradePrice", 1);

        shop1Price = PlayerPrefs.GetInt("shop1Price", 1);
        amount1 = PlayerPrefs.GetInt("amount1", 0);
        amount1Profit = PlayerPrefs.GetInt("amount1Profit", 1);
        shop2Price = PlayerPrefs.GetInt("shop2Price", 2);
        amount2 = PlayerPrefs.GetInt("amount2", 0);
        amount2Profit = PlayerPrefs.GetInt("amount2Profit", 5);
 


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

        // save
        PlayerPrefs.SetInt("currentScore", (int)currentScore);
        PlayerPrefs.SetInt("hitPower", (int)hitPower);
        PlayerPrefs.SetInt("x", (int)x);
        PlayerPrefs.SetInt("upgradePrice", (int)upgradePrice);

        PlayerPrefs.SetInt("shop1Price", (int)shop1Price);
        PlayerPrefs.SetInt("amount1", (int)amount1);
        PlayerPrefs.SetInt("amount1Profit", (int)amount1Profit);
        PlayerPrefs.SetInt("shop2Price", (int)shop2Price);
        PlayerPrefs.SetInt("amount2", (int)amount2);
        PlayerPrefs.SetInt("amount2Profit", (int)amount2Profit);

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
