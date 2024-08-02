using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float jumpHeight = 2f; // ���� ����
    public float jumpDuration = 0.5f; // ���� �ð�
    public float slideDuration = 1f; // �����̵� �ð�

    public Sprite jumpSprite; // ������ �� ����� ��������Ʈ
    public Sprite slideSprite; // �����̵��� �� ����� ��������Ʈ
    public Sprite defaultSprite; // �⺻ ��������Ʈ

    private Vector3 startPosition;
    private bool isJumping = false;
    private bool isSliding = false;
    private float jumpTimer;
    private SpriteRenderer spriteRenderer;

    // ScoreManager�� Ư�� ���ӽ����̽��� ���
    public ScoreScript scoreScript; // ������ �����ϴ� ��ũ��Ʈ (�����Ϳ��� �Ҵ�)

    private Coroutine resetSpriteCoroutine;

    void Start()
    {
        startPosition = transform.position; // ���� ��ġ ����
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer ������Ʈ�� ������
        defaultSprite = spriteRenderer.sprite; // �⺻ ��������Ʈ ����

        // �����Ϳ��� scoreManager�� �Ҵ�Ǿ����� Ȯ��
        if (scoreScript == null)
        {
            Debug.LogError("ScoreManager�� �Ҵ���� �ʾҽ��ϴ�. �����Ϳ��� ScoreManager�� PlayerManager�� �Ҵ��ϼ���.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isSliding)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !isSliding && !isJumping)
        {
            Slide();
        }

        if (isJumping)
        {
            // ���� �ð� ����� ���� ĳ���� ��ġ ������Ʈ
            jumpTimer += Time.deltaTime;
            float t = jumpTimer / jumpDuration;

            if (t < 0.5f)
            {
                // ���� �̵�
                transform.position = Vector3.Lerp(startPosition, startPosition + Vector3.up * jumpHeight, t * 2);
            }
            else
            {
                // �Ʒ��� �̵�
                transform.position = Vector3.Lerp(startPosition + Vector3.up * jumpHeight, startPosition, (t - 0.5f) * 2);
            }

            if (jumpTimer >= jumpDuration)
            {
                // ���� ����
                transform.position = startPosition;
                isJumping = false;
                jumpTimer = 0f; // Ÿ�̸� �ʱ�ȭ
                spriteRenderer.sprite = defaultSprite; // �⺻ ��������Ʈ�� �ǵ�����
            }
        }
    }

    IEnumerator ResetSpriteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        spriteRenderer.sprite = defaultSprite;
        isSliding = false; // �����̵� ���� ����
    }

    void Jump()
    {
        isJumping = true;
        jumpTimer = 0f; // ���� ���� �� Ÿ�̸� �ʱ�ȭ
        spriteRenderer.sprite = jumpSprite; // ���� ��������Ʈ�� ����
    }

    void Slide()
    {
        isSliding = true;
        spriteRenderer.sprite = slideSprite; // �����̵� ��������Ʈ�� ����

        // �����̵尡 ������ �⺻ ��������Ʈ�� �ǵ����� Coroutine ����
        if (resetSpriteCoroutine != null)
        {
            StopCoroutine(resetSpriteCoroutine);
        }
        resetSpriteCoroutine = StartCoroutine(ResetSpriteAfterDelay(slideDuration));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered with: " + other.gameObject.name);

        if (other.CompareTag("Coin"))
        {
            if (scoreScript != null)
            {
                scoreScript.IncreaseScore(); // ���� ����
            }
            else
            {
                Debug.LogError("ScoreManager is null when trying to increase score.");
            }
            Destroy(other.gameObject); // ���� ����
        }
        else if (other.CompareTag("Enemy"))
        {
            if (scoreScript != null)
            {
                scoreScript.DecreaseScore();
            }
            else
            {
                Debug.LogError("ScoreManager is null when trying to decrease score.");
            }
            Destroy(other.gameObject);
        }
    }
}
