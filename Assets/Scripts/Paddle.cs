using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minPaddlePosX = 1f;
    [SerializeField] float maxPaddlePosX = 15f;

    bool isFrozen = false;

    GameSession gameSession;
    Ball ball;

    // Start is called before the first frame update
    void Start() {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update() {
        if (!isFrozen) {
            FollowObject();
        }
    }

    public void IsFrozen(bool state) {
        isFrozen = state;
    }

    private void FollowObject() {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(getXPos(), minPaddlePosX, maxPaddlePosX);
        transform.position = paddlePos;
    }

    private float getXPos() {
        if (gameSession.IsAutoplayEnabled()) {
            return ball.transform.position.x;
        } else {
            return (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        }
    }
}
