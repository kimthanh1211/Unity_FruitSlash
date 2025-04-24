using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fruit : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;

    public GameObject splashEffect; // Prefab hiệu ứng nước
    public AudioClip sliceSound;    // Âm thanh khi cắt
    public AudioSource audioSource; // Nơi phát âm thanh
    private bool isSlashed = false;
    void Start()
    {
        direction = Vector2.up; // Trái cây di chuyển lên từ dưới màn hình
        if (audioSource == null)
        {
            audioSource = Camera.main.GetComponent<AudioSource>();
        }
    }

   
    void Update()
    {
        transform.Translate(direction * speed *Time.deltaTime);  // Di chuyển trái cây
        //Debug.Log("Fruit Position: " + transform.position);
        //Nếu trái cây ra ngoài màn hình, tự hủy
        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }
    // Phương thức khi trái cây bị cắt
    public void Slash()
    {
        if (isSlashed) return;
        isSlashed = true;

        Debug.Log("Slash called!");
        // 1. Tạo hiệu ứng nước bắn tại vị trí trái cây
        if (splashEffect != null)
        {
            GameObject splash = Instantiate(splashEffect, transform.position, Quaternion.identity);
            Destroy(splash, 1.5f);
        }
        // 2. Phát âm thanh cắt
        if (sliceSound != null && audioSource != null)
        {
            Debug.Log("PLAYING SOUND!");
            //audioSource.PlayOneShot(sliceSound);
            AudioSource.PlayClipAtPoint(sliceSound, transform.position);
        }

        // Tạo hiệu ứng hoặc âm thanh khi cắt trái cây
        Destroy(gameObject);// Xóa trái cây khỏi scene

    }
}
