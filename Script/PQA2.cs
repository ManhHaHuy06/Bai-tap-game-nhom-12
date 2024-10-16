using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;    // Tốc độ di chuyển trái phải
    public float jumpForce = 10f;   // Lực nhảy
    private bool isGrounded;         // Kiểm tra xem nhân vật có đang ở trên mặt đất không
    private Rigidbody2D rb;          // Rigidbody của nhân vật để điều khiển vật lý
    private Vector3 initialPosition; // Vị trí ban đầu của nhân vật

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Lấy Rigidbody2D của nhân vật
        initialPosition = transform.position; // Lưu vị trí ban đầu của nhân vật
    }

    void Update()
    {
        // Nhận đầu vào từ phím trái và phải (A/D hoặc mũi tên)
        float moveInput = Input.GetAxis("Horizontal"); // Di chuyển trái/phải (-1: trái, 1: phải)
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y); // Di chuyển nhân vật theo trục X

        // Nhảy khi nhấn phím Space và nhân vật đang đứng trên mặt đất
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Tạo lực nhảy theo trục Y
            isGrounded = false; // Đặt lại isGrounded khi nhân vật đã nhảy lên
        }
    }

    // Kiểm tra khi nhân vật chạm đất (Ground)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Khi va chạm với mặt đất, cho phép nhân vật nhảy lại
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Quay lại vị trí ban đầu khi chạm vào chướng ngại vật
            transform.position = initialPosition;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NextLevel")) // Kiểm tra xem chạm vào trigger nào
        {
            // Chuyển sang cảnh khác
            SceneManager.LoadScene("Winning"); // Thay "TênCảnhMới" bằng tên của cảnh bạn muốn chuyển
        }
    }
}
