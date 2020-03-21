using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Arrow arrow;
    [SerializeField] float xPush;
    [SerializeField] float yPush;
    [SerializeField] float randomCollisionFactor = 0.4f;
    [SerializeField] AudioClip[] ballSounds;

    Vector2 paddleToBallVec;
    bool isLaunched = false;
    [SerializeField] float speed; // SF for debbuging

    Paddle paddle1;
    AudioSource audioSource;
    Rigidbody2D rb;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        paddle1 = FindObjectOfType<Paddle>();
    }

    // Start is called before the first frame update
    void Start() {
        paddleToBallVec = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (!isLaunched) {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (isLaunched) {
            int randIndex = Random.Range(0, ballSounds.Length);
            AudioClip clip = ballSounds[randIndex];
            audioSource.PlayOneShot(clip);
        }

        Vector2 velocityTweak = new Vector2(
            Random.Range(0, randomCollisionFactor), 0);

        rb.velocity += velocityTweak; // add randomness to velocity change
        rb.velocity = speed * (rb.velocity.normalized);
    }

    private void LockBallToPaddle() {
        Vector2 paddlePosVec = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosVec + paddleToBallVec;
    }

    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            LaunchBall(xPush, yPush);
        }
    }

    public void LaunchBall(float xPush, float yPush) {
        isLaunched = true;
        rb.velocity = new Vector2(xPush, yPush);
        speed = rb.velocity.magnitude;
    }
}
