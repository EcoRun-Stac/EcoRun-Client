using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 5f; // 배경이 스크롤되는 속도
    public float stopDistance = 10f; // 스크롤을 멈출 거리

    private float initialPositionX; // 시작 위치의 X좌표

    void Start()
    {
        // 시작 위치의 X좌표 저장
        initialPositionX = transform.position.x;
    }

    void Update()
    {
        // 현재 X좌표와 시작 X좌표 간의 거리를 계산
        float distanceTravelled = initialPositionX - transform.position.x;

        // 지정된 거리 이하일 때만 스크롤
        if (distanceTravelled < stopDistance)
        {
            // 배경을 왼쪽으로 움직이기
            transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }
    }
}
