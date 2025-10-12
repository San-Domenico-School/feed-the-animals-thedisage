using UnityEngine;
public class AnimalControler : MonoBehaviour
{
    [SerializeField] GameObject foodItEats;
    [SerializeField] float animalSpeed;
    private float lowerBound;
    private bool isOutOfScene;
    private bool notHungry;

     // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void MoveForward()
    {

    }

    private void DeleteOutOfScene()
    {

    }

    private bool IsFoodItEats()
    {
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }


}
