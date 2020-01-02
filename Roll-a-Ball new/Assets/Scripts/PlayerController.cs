using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Text winText;
    public float speed;
    public Text countText;

    private Rigidbody rb;
    private int count;

	// Intialisation
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // FixedUpdate is called before physics calucations
    private void FixedUpdate ()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count = " + count.ToString();
        if (count >= 15)
        {
            winText.text = "Congratulations!!!\nYou Win";
        }
    }
}
