using UnityEngine;

public class JumpingImage : MonoBehaviour
{
    public float jumpForce = 300f; // ������ ��
    public float gravityScale = 1f; // �߷��� ����
    public float groundLevel = 0f; // �ٴ� ��ġ
    public float maxJumpHeight = 200f; // �ִ� ���� ����

    private RectTransform rectTransform;
    private float velocityY = 0f;
    private bool isJumping = false;
    private bool isFalling = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("RectTransform component not found!");
        }
    }

    private void Update()
    {
        // �����̽��ٸ� ������ �� ���� ����
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isFalling)
        {
            isJumping = true;
            velocityY = jumpForce; // ������ �ʱ� �ӵ� ����
        }

        // ���� ����
        if (isJumping || isFalling)
        {
            // �߷� ����
            velocityY -= gravityScale * Time.deltaTime;
            Vector2 pos = rectTransform.anchoredPosition;
            pos.y += velocityY * Time.deltaTime;
            rectTransform.anchoredPosition = pos;

            // ������ �ٴڿ� ��Ҵ��� Ȯ��
            if (rectTransform.anchoredPosition.y <= groundLevel)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, groundLevel);
                isJumping = false;
                isFalling = false;
                velocityY = 0;
            }

            // ������ �ʹ� ���� �ö��� �ʵ��� ����
            if (rectTransform.anchoredPosition.y > groundLevel + maxJumpHeight)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, groundLevel + maxJumpHeight);
                isFalling = true;
                velocityY = 0;
            }
        }
    }
}
    