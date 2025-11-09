
using UnityEngine;
public class AnimalController : MonoBehaviour
{
    [SerializeField] GameObject foodItEats;
    [SerializeField] float animalSpeed;
    private float lowerBound = -22.0f;
    private bool isOutofScene;
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
        string foodItEatsName = foodItEats.name;

        // Remove "(Clone)" if it exists
        int cloneIndex = foodTriggered.IndexOf("(Clone)");
        if (cloneIndex != -1)
        {
            foodTriggered = foodTriggered.Substring(0, cloneIndex).Trim();
        }

        // Compare the cleaned names
        return foodTriggered.Equals(foodItEatsName);
    }

    // --- Step 6: Implement OnTriggerEnter ---
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food") && !notHungry)
        {
            // Check if this is the food it eats
            if (IsFoodItEats(other.gameObject.name))
            {
                Debug.Log("Food It Eats");
            }
            else
            {
                Debug.Log("Food It Doesn't Eat");
            }

            // After eating or touching any food
            notHungry = true;
            Destroy(other.gameObject);
        }
    }
}
