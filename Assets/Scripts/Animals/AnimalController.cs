using System;
using UnityEngine;
public class AnimalController : MonoBehaviour
{
    [SerializeField] GameObject foodItEats;
    [SerializeField] int animalSpeed;
    private float lowerBound = -22.0f;
    private bool notHungry;
    private bool hasBeenDeleted = false;


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
            if (!hasBeenDeleted)
            {

                Scoreboard.Instance.UpdateRemaining(0);
                hasBeenDeleted = true;
            }
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
                // Convert animalSpeed to float so Mathf.Sqrt works
             int penalty = Mathf.RoundToInt(-5f * Mathf.Sqrt(animalSpeed));
             Scoreboard.Instance.UpdateScore(penalty);

            }

            // After eating or touching any food
            notHungry = true;
            Destroy(other.gameObject);
        }
    }
}
