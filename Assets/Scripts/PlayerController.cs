using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    private int pickupCount;
    private int numPickups = 4;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;

    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("PickUp")) {
            pickupCount++;
            collision.gameObject.SetActive(false);
            SetCountText();
        }
    }

    void Start()
    {
        pickupCount = 0;
        winText.text = " ";
        SetCountText();
    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + pickupCount.ToString();
        if (pickupCount >= numPickups)
        {
            winText.text = "You win!";
        }
    }
}