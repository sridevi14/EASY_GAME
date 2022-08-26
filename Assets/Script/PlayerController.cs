using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private int count;
    public GameObject winTextObject;
    public TextMeshProUGUI countText;
    public float speed = 0;
    private Rigidbody rb;
    private float movementx;
    private float movementy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementx = movementVector.x;
        movementy = movementVector.y;
            }

    private void FixedUpdate()
    {

        Vector3 movement = new Vector3(movementx, 0.0f, movementy);
        rb.AddForce(movement*speed);
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
        }
        SetCountText();
        
    }
}
