using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    SceneLoader sceneLoader;

    private void Awake() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void Start() {

    }

    public void countBlocks() {
        breakableBlocks++;
    }

    public void destroyBlock() {
        breakableBlocks--;

        if (breakableBlocks <= 0) {
            sceneLoader.loadNextScene();
        }
    }
}
