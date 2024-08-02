using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // ������ ǥ���� UI �ؽ�Ʈ
    public int score = 0; // ���� ����
    public static int enemy = 0;
    private float length = 0f;

    void Start()
    {
        UpdateScoreText(); // ������ �� ���� �ؽ�Ʈ�� �ʱ�ȭ�մϴ�.
    }

    void Update()
    {
        length += Time.deltaTime + 0.5f;
        UpdateScoreText();
    }

    public void IncreaseScore()
    {
        score++; // ������ 1 ������ŵ�ϴ�.

        if (score == 50)
        {
            Application.Quit();
        }
    }   

    public void DecreaseScore()
    {
        enemy++;

        HeartScript.RemoveHeart(enemy);

        if (enemy == 4)
        {
            Application.Quit();
            Debug.Log("quit");
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = ((int)length).ToString() + "m"; // ������ UI�� ǥ���մϴ�.
    }
}
