using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
	[Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
	[SerializeField] AudioClip gameOverSound;
	[SerializeField] int pointsToAdd = 10;
	[SerializeField] TextMeshProUGUI scoreText;

	[SerializeField] int currentScore = 0;
	[SerializeField] int currentLevel = 1;
	[SerializeField] int ballCloningValue = 50;
	[SerializeField] bool isAutoPlayEnabled;

	Ball ball;

	private void Awake() {
		int gameStatusCount = FindObjectsOfType<GameSession>().Length;

		if (gameStatusCount > 1) {
			gameObject.SetActive(false);
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
		}
	}

	// Start is called before the first frame update
	void Start() {
		displayScore();
	}

	// Update is called once per frame
	void Update() {
		Time.timeScale = gameSpeed;
		displayScore();
	}

	public void increaseCurrentLevel() {
		currentLevel++;
	}

	public int getCurrentLevel() {
		return currentLevel;
	}

	public bool IsAutoplayEnabled() {
		return isAutoPlayEnabled;
	}

	public void playGameOverSound() {
		AudioSource.PlayClipAtPoint(gameOverSound, Camera.main.transform.position, 1f);
	}

	public void addBallsToScene(Vector3 spawnPosition) {
		if (currentScore % ballCloningValue == 0) {
			ball = FindObjectOfType<Ball>();
			Vector2 ballVelocity = ball.GetComponent<Rigidbody2D>().velocity;

			Ball ballInstance = Instantiate(ball, spawnPosition, Quaternion.identity);
			ballInstance.LaunchBall(ballVelocity.x, ballVelocity.y);
		}
	}

	public int getScore() {
		return currentScore;
	}

	public int getballCloningValue() {
		return ballCloningValue;
	}

	public void setScore(int score) {
		currentScore = score;
	}

	public void resetGame() {
		Destroy(gameObject);
	}

	public void addScore() {
		currentScore += pointsToAdd;
	}

	public void displayScore() {
		if (scoreText != null) {
			scoreText.text = currentScore.ToString();
		}
	}
}
