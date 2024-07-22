using UnityEngine;

public class JumpingImage : MonoBehaviour
{
    public float jumpForce = 300f; // 점프의 힘
    public float gravityScale = 1f; // 중력의 세기
    public float groundLevel = 0f; // 바닥 위치
    public float maxJumpHeight = 200f; // 최대 점프 높이

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
        // 스페이스바를 눌렀을 때 점프 시작
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isFalling)
        {
            isJumping = true;
            velocityY = jumpForce; // 점프의 초기 속도 설정
        }

        // 점프 동작
        if (isJumping || isFalling)
        {
            // 중력 적용
            velocityY -= gravityScale * Time.deltaTime;
            Vector2 pos = rectTransform.anchoredPosition;
            pos.y += velocityY * Time.deltaTime;
            rectTransform.anchoredPosition = pos;

            // 점프가 바닥에 닿았는지 확인
            if (rectTransform.anchoredPosition.y <= groundLevel)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, groundLevel);
                isJumping = false;
                isFalling = false;
                velocityY = 0;
            }

            // 점프가 너무 높이 올라가지 않도록 제한
            if (rectTransform.anchoredPosition.y > groundLevel + maxJumpHeight)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, groundLevel + maxJumpHeight);
                isFalling = true;
                velocityY = 0;
            }
        }
    }
}
    