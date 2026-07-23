using UnityEngine;

public class EntityAnimation : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer sr;

    [SerializeField] Sprite moveSprite;
    [SerializeField] Sprite jumpStartSprite;
    [SerializeField] Sprite jumpEndSprite;

    bool wasMoving = false;
    bool wasJumping = false;

    [SerializeField] float moveThreshold = 0.1f;
    [SerializeField] float jumpThreshold = 1f;
    [SerializeField] float jumpEndSpriteDuration = 1f;   // jumpEndSprite를 보여주는 시간

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float xSpeed = rigid.linearVelocity.x;
        float ySpeed = rigid.linearVelocity.y;

        // 좌우 반전
        if (Mathf.Abs(xSpeed) > 0.01f)
        {
            float dir = xSpeed > 0 ? 1 : -1;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * dir, transform.localScale.y, transform.localScale.z);
        }

        bool isJumping = Mathf.Abs(ySpeed) > jumpThreshold;
        bool isMoving = Mathf.Abs(xSpeed) > moveThreshold;

        // 점프 우선 처리
        if (isJumping && !wasJumping)
        {
            SetSprite(jumpStartSprite);
        }
        else if (!isJumping && wasJumping)
        {
            SetSprite(jumpEndSprite);
            Invoke(nameof(ReturnToIdle), jumpEndSpriteDuration);
        }
        else if (!isJumping)
        {
            // 점프 중이 아닐 때만 이동 스프라이트 처리
            if (isMoving && !wasMoving)
            {
                CancelInvoke(nameof(ReturnToIdle));
                SetSprite(moveSprite);
            }
            else if (!isMoving && wasMoving)
            {
                ReturnToIdle();
            }
        }

        wasJumping = isJumping;
        wasMoving = isMoving;
    }

    void SetSprite(Sprite sprite)
    {
        animator.enabled = false;
        sr.sprite = sprite;
    }

    void ReturnToIdle()
    {
        animator.enabled = true;
        animator.Play("Idle");
    }
}