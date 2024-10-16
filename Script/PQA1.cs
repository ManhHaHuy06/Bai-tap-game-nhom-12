using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Thư viện cần thiết để chuyển cảnh

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;    // Tốc độ di chuyển
    private bool isGrounded;         // Kiểm tra xem nhân vật có đang ở trên mặt đất không
    private Rigidbody2D rb;          // Rigidbody của nhân vật để điều khiển vật lý
    private Vector2 movement;        // Biến lưu trữ đầu vào di chuyển
    private Vector3 initialPosition; // Vị trí ban đầu của nhân vật

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Lấy Rigidbody2D của nhân vật
        initialPosition = transform.position; // Lưu vị trí ban đầu của nhân vật
    }

    void Update()
    {
        // Nhận đầu vào từ phím trái và phải (A/D hoặc mũi tên)
        movement.x = Input.GetAxisRaw("Horizontal"); // Di chuyển trái/phải (-1: trái, 1: phải)
        movement.y = Input.GetAxisRaw("Vertical");   // Di chuyển lên/xuống (-1: xuống, 1: lên)

    }

    void FixedUpdate()
    {
        // Di chuyển nhân vật
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    // Kiểm tra khi nhân vật chạm vào trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NextLevel")) // Kiểm tra xem chạm vào trigger nào
        {
            // Chuyển sang cảnh khác
            SceneManager.LoadScene("S1.3"); // Thay "TênCảnhMới" bằng tên của cảnh bạn muốn chuyển
        }
    }
}
