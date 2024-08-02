using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public static GameObject[] heartObjects; // �ټ��� ��Ʈ ������Ʈ�� �迭�� ����

    void Start()
    {
        // ��Ʈ ������Ʈ���� �迭�� �Ҵ�
        heartObjects = GameObject.FindGameObjectsWithTag("Heart");
    }

    public static void RemoveHeart(int count)
    {
        if (count >= 0 && count < heartObjects.Length && heartObjects[count] != null)
        {
            Destroy(heartObjects[count]);
            heartObjects[count] = null; // Destroy�� ������Ʈ�� �迭���� ����
        }
    }
}
