using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb; // Rigidbody2D�� ����Ͽ� 2D ���� ������ �����

    [SerializeField][Range(100f, 800f)] float jumpForce = 600f; // ���� ��

    int playerLayer, groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ�� ������

        playerLayer = LayerMask.NameToLayer("Player"); // Player ���̾� ��������
        groundLayer = LayerMask.NameToLayer("Ground"); // Ground ���̾� ��������
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")) // ���� ��ư�� ������ ��
        {
            if (Mathf.Abs(rb.velocity.y) < 0.01f) // y�� �ӵ��� ���� 0�� �� (��, ���� ���� ��)
                rb.AddForce(Vector2.up * jumpForce); // �������� ���� ���� �߰���
        }

        // �÷��̾ ���� ���� �� �÷��̾�� ���� �浹�� �������� ����
        // �÷��̾ ���߿� ���� �� �÷��̾�� ���� �浹�� ������
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
            Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, false);
        else
            Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, true);
    }
}