using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed = 1;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI findMoreKeysText;
    public GameObject win;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        win.SetActive(false);

        winText = GameObject.Find("Win").GetComponent<TextMeshProUGUI>();
        findMoreKeysText = GameObject.Find("FindMoreKeys").GetComponent<TextMeshProUGUI>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        
        countText.text = "Count: " + count.ToString();

        if(count == 4)
        {
            win.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            count++;

            SetCountText();
        }

        if (count == 4)
        {
            win.SetActive(true);
        }

        if (other.tag == "Goal" && count == 4)
        {
            winText.enabled = true;
        }
        else
        {
            findMoreKeysText.enabled = true;
        }
    }

}
