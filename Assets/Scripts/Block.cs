using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destructSound;
    [SerializeField] GameObject destroySparklesVFX;
    [SerializeField] Sprite[] damageSprites;

    [SerializeField] int test;

    Level level;
    GameSession gameSession;

    [SerializeField] int currentHitPoints = 0; // serialized for debbuging
    [SerializeField] int maxHits; // serialized for debbuging

    private void Start() {
        gameSession = FindObjectOfType<GameSession>();
        countBreakableBlocks();
        maxHits = damageSprites.Length + 1;
    }

    private void countBreakableBlocks() {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable") {
            level.countBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "Breakable") {
            HandleCollision();
        }
    }

    private void HandleCollision() {
        currentHitPoints++;
        int damageIndex = currentHitPoints - 1;

        if (currentHitPoints >= maxHits) {
            DestroyBlock();
        } else if (damageSprites[damageIndex] != null) {
            GetComponent<SpriteRenderer>().sprite = damageSprites[damageIndex];
        }
    }

    private void DestroyBlock() {
        AudioSource.PlayClipAtPoint(destructSound, Camera.main.transform.position, 0.5f);
        Destroy(gameObject);
        triggerParticlesVFX();
        level.destroyBlock();
        gameSession.addScore();
        gameSession.addBallsToScene(transform.position);
    }

    private void triggerParticlesVFX() {
        GameObject sparkles = Instantiate(destroySparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
