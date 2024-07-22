using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 5f; // ����� ��ũ�ѵǴ� �ӵ�
    public float stopDistance = 10f; // ��ũ���� ���� �Ÿ�

    private float initialPositionX; // ���� ��ġ�� X��ǥ

    void Start()
    {
        // ���� ��ġ�� X��ǥ ����
        initialPositionX = transform.position.x;
    }

    void Update()
    {
        // ���� X��ǥ�� ���� X��ǥ ���� �Ÿ��� ���
        float distanceTravelled = initialPositionX - transform.position.x;

        // ������ �Ÿ� ������ ���� ��ũ��
        if (distanceTravelled < stopDistance)
        {
            // ����� �������� �����̱�
            transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }
    }
}
