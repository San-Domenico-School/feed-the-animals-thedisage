
using UnityEngine;
public class AnimalController : MonoBehaviour
{
    [SerializeField] GameObject foodItEats;
    [SerializeField] int animalSpeed;
    private float lowerBound = -22.0f;
    private bool notHungry;


    private void Start()
    {

    }

    private void Update()
    {
        DeleteOutOfScene();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * animalSpeed * Time.deltaTime);
    }

    private void DeleteOutOfScene()
    {
        if (transform.position.z > lowerBound)
        {
            MoveForward();
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private bool IsFoodItEats(string foodTriggered)
    {
        if (foodItEats == null)
        {
            Debug.LogWarning($"{name} has no food assigned!");
            return false;
        }

        string foodItEatsName = foodItEats.name;

        // Remove "(Clone)" if it exists
        int cloneIndex = foodTriggered.IndexOf("(Clone)");
        if (cloneIndex != -1)
        {
            Debug.Log("Tag Trimmed");
            foodTriggered = foodTriggered.Substring(0, cloneIndex).Trim();
        }

        bool isMatch = foodTriggered.Equals(foodItEatsName);
        Debug.Log("Trim compared");

        return isMatch;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food") && !notHungry)
        {
            // Check if this is the food it eats
            if (IsFoodItEats(other.gameObject.name))
            {
                // Correct food eaten → add positive score
                Scoreboard.Instance.UpdateScore(10 * animalSpeed);
            }
            else
            {
                // Wrong food → subtract points (or zero)
                Scoreboard.Instance.UpdateScore(-5);  // Change -5 as needed
            }

            // After eating or touching any food
            notHungry = true;
            Destroy(other.gameObject);
        }
    }
}
