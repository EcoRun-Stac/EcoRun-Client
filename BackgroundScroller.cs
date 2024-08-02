using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public float scrollSpeedF = 2f;    // ��� �̵� �ӵ�
    public float backgroundsWidth;     // ��� �̹����� ��

    private Transform[] backgrounds;  // ��� �̹����� Ʈ������
    private Vector3 startPosition;    // ���� ��ġ

    void Start()
    {
        // ��� �̹����� Ʈ�������� �ʱ�ȭ
        backgrounds = new Transform[2];
        for (int i = 0; i < 2; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }

        // ��� �̹����� ���� ��ġ�� �ʱ�ȭ
        startPosition = backgrounds[0].position;
        backgroundsWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // ��� �̹����� �������� �̵�
        for (int i = 0; i < 2; i++)
        {
            backgrounds[i].Translate(Vector3.left * scrollSpeedF * Time.deltaTime);
        }

        // ù ��° ��� �̹����� ���� ���� �����ߴ��� Ȯ��
        if (backgrounds[0].position.x <= -backgroundsWidth)
        {
            // ù ��° ����� ���������� �̵��Ͽ� �ٽ� ����
            backgrounds[0].position = new Vector3(backgrounds[1].position.x + backgroundsWidth, startPosition.y, startPosition.z);

            // �� ���� ����� ����
            Transform temp = backgrounds[0];
            backgrounds[0] = backgrounds[1];
            backgrounds[1] = temp;
        }
    }
}
