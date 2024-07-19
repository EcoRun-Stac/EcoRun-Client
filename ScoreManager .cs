using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // ������ ǥ���� UI �ؽ�Ʈ
    private int score = 0; // ���� ����

    void Start()
    {
        UpdateScoreText(); // ������ �� ���� �ؽ�Ʈ�� �ʱ�ȭ�մϴ�.
    }

    public void IncreaseScore()
    {
        score++; // ������ 1 ������ŵ�ϴ�.
        UpdateScoreText(); // ���� �ؽ�Ʈ�� ������Ʈ�մϴ�.
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // ������ UI�� ǥ���մϴ�.
    }
}
