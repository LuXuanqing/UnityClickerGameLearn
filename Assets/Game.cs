using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    // clicker
    public Text scoreText;
    public float currentScore;
    public float hitPower;
    public float scoreIncreasedPerSecond;
    public float x;

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
        scoreText.text = $"{currentScore} $";
    }

    public void Hit()
    {
        currentScore += hitPower;
    }
}
