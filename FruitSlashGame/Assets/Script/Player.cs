using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Camera cam;
    public LayerMask fruitLayer;// Chỉ nhận diện trái cây
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Khi người chơi nhấn chuột hoặc chạm màn hình
        {
            SlashFruit();
        }
    }

    void SlashFruit()
    {
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition),Vector2.zero,Mathf.Infinity,fruitLayer);
        if(hit.collider != null)
        {
            hit.collider.GetComponent<Fruit>().Slash();
            GameManager.Instance.IncreaseScore(); // Tăng điểm khi cắt trái cây
        }
    }
}
