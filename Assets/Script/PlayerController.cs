using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector3 movement;
    public Animator animator;
    public Rigidbody rb;

    void Start()
    {
        if (animator == null) animator = GetComponent<Animator>();
        if (rb == null) rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float dx = Input.GetAxisRaw("Horizontal");
        float dz = Input.GetAxisRaw("Vertical");
        movement = new Vector3(dx, 0, dz).normalized;

        // アニメーション更新
        bool isWalking = movement.magnitude > 0f;
        animator.SetBool("Walk", isWalking);
    }

    void FixedUpdate()
    {
        if (movement != Vector3.zero)
        {
            // 移動
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            // 向きを変更（オプション）
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, toRotation, 720 * Time.fixedDeltaTime);
        }
    }
}
