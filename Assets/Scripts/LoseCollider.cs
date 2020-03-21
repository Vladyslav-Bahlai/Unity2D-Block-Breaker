using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        int amountOfBalls = FindObjectsOfType<Ball>().Length;
        if (amountOfBalls == 1) {
            SceneManager.LoadScene("GameOver");
        } else {
            Destroy(collision.gameObject);
        }
    }
}
