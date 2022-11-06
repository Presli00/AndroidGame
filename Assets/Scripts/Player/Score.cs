using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public static float score = 1980;
    private float pointsPerSecond = 5f;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.active)
        {
            score += pointsPerSecond * Time.deltaTime * 0.35f;
            scoreText.text = "Score: " + Mathf.Round(score);
        }
    }
}
