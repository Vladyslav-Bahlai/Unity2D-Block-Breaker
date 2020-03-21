using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;

	GameSession gameSession;

	private void Awake() {
		gameSession = FindObjectOfType<GameSession>();
		gameSession.playGameOverSound();
	}

	private void Start() {
		textMeshPro.text = "Your score: " + gameSession.getScore().ToString();
	}

}
