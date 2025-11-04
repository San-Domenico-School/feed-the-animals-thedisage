using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] animalPrefab;
    public int animalsFeed;
    private float zStart = 38f;
    private float xSpawnRange = 25f;
    private float startDelay = 2f;
    private float repeatRate = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnAnimal", startDelay, repeatRate);
    }

    // Update is called once per frame
    private void SpawnAnimal()
    {
        int choice = Random.Range(0, animalPrefab.Length);
        float xPosition = Random.Range(-xSpawnRange, xSpawnRange);
        Instantiate(animalPrefab[choice], new Vector3(xPosition, 0, zStart), Quaternion.Euler(0, 180, 0));
        animalsFeed--;
        if (animalsFeed == 0)
        {
            GameOver();
        }




    }
    private void GameOver()
    {
        CancelInvoke;
    }
}
