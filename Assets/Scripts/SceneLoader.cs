using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void loadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex >= 1) {
            FindObjectOfType<GameSession>().increaseCurrentLevel();
        }
        SceneManager.LoadScene(++currentSceneIndex);
    }

    public void loadPreviousScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(--currentSceneIndex);
    }

    public void replayCurrentLevel() {
        GameSession gameSession = FindObjectOfType<GameSession>();
        gameSession.setScore(0);
        SceneManager.LoadScene(gameSession.getCurrentLevel());
    }

    public void loadStartScene() {
        FindObjectOfType<GameSession>().resetGame();
        SceneManager.LoadScene(0);
    }

    public void loadLevelsScene() {
        SceneManager.LoadScene(3);
    }

    public void loadDonationScene() {
        SceneManager.LoadScene(4);
    }

    public void quitGame() {
        Application.Quit();
    }
}
