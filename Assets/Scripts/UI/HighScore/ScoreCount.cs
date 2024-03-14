using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    private PlayerProperties _player;
    private TextMeshProUGUI _scoreText;
    private TextMeshProUGUI _highScoreText;

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerProperties>();
        _scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        _highScoreText = GameObject.Find("Highscore").GetComponent<TextMeshProUGUI>();
        _highScoreText.text = "Highscore: " + _player.GetHighScore();
    }

    private void FixedUpdate()
    {
        _scoreText.text = "Score: " + _player.GetScore();
        _highScoreText.text = "Highscore: " + _player.GetHighScore();
    }
}