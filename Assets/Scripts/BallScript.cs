using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    // Use this for initialization
    public Rigidbody2D BallRigidbody2D;
    public float speed;
    public Button replay;
    public static bool isDead, alreadyStopped;
    private bool needToStop;
    private bool gamestarted;
   


    // Update is called once per frame
    private void Start()
    {
        isDead = false;
        alreadyStopped = false;

        BallRigidbody2D.isKinematic = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BallRigidbody2D.isKinematic = false;
            gamestarted = true;
            if (isDead == false)
            {
                Debug.Log("button clicked");
                BallRigidbody2D.velocity = new Vector2(BallRigidbody2D.velocity.x, speed);
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead == false && gamestarted)
        {
            BallRigidbody2D.velocity = new Vector2(3f, BallRigidbody2D.velocity.y);
        }
        else
        {
            BallRigidbody2D.velocity = new Vector2(0f, BallRigidbody2D.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            isDead = true;
            replay.gameObject.SetActive(true);
        }

        if (other.gameObject.CompareTag("ground"))
        {
            isDead = true;
            replay.gameObject.SetActive(true);
            needToStop = true;
        }
        
    }

  

    public void ReplayGame()
    {
        SceneManager.LoadScene("g");
    }
}