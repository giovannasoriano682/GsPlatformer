using NUnit.Framework.Constraints;
using UnityEngine;
using TMPro;
public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 9;
    public int coinsCollected = 0;
    public TMP_Text coinText;
    public TMP_Text healthText;
    public int currentHealth = 3;
    public float jumpForce = 250;

    public bool Grounded = true;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && Grounded)

        {
            rb.AddForce(Vector2.up * jumpForce);
            Grounded = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("I pressed S look at me go");
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = (Vector2.right * 9);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = (Vector2.left * 9);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Grounded = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<collectable>())
        {
            coinsCollected++;
            coinText.text = coinsCollected.ToString();
        }
        else if (other.GetComponent<Hazard>())
        {
            currentHealth--;
            healthText.text = currentHealth.ToString();
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
       /*else if (other.GetComponent<Goall>())
        {
            SceneManager.LoadScene(other.GetComponent<Goall>().NextLevel);
        }*/
    }
    
}
