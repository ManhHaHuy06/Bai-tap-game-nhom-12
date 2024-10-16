using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;       // Đối tượng nhân vật
    public float offsetX = 2f;     // Khoảng cách theo trục X giữa camera và nhân vật
    public float offsetZ = -10f;    // Khoảng cách theo trục Z giữa camera và nhân vật
    public float smoothSpeed = 0.125f;  // Tốc độ di chuyển mượt mà của camera theo trục X

    void LateUpdate()
    {
        if (player != null)
        {
            // Chỉ cập nhật vị trí X của camera theo vị trí X của nhân vật
            Vector3 desiredPosition = new Vector3(player.position.x + offsetX, transform.position.y, offsetZ);

            // Tạo chuyển động mượt mà cho camera
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Gán lại vị trí cho camera
            transform.position = smoothedPosition;
        }
    }
}