using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                    // プレイヤー
    public Vector3 offset = new Vector3(0, 5, -6); // 固定されたカメラの相対位置
    public float followSpeed = 5f;              // 追従スピード

    private Vector3 desiredPosition;

    void LateUpdate()
    {
        if (target == null) return;

        // 目標位置を即座に追従（遅延なし）
        transform.position = target.position + offset;

        // 固定角度でプレイヤーを見下ろす
        transform.rotation = Quaternion.Euler(20f, 0f, 0f); // 任意の角度
    }
}
