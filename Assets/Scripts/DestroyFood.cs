using UnityEngine;

public class DestroyFood : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FeedAnimal(string name)
    {
        Vector3 position = transform.position + new Vector3(0, 2, 0); //Sets position 2 meters above center of Player
        GameObject foodInstance = Instantiate(food, position, Quaternion.identity);  //Adds food prefab to world
        Rigidbody foodRB = foodInstance.GetComponent<Rigidbody>();    //Set rigidbody of food
        foodRB.AddForce(Vector3.forward * maxForce, ForceMode.Impulse);  //Adds a forward impulse force to the                      
                                                                         //food's rigidbody
    }
    public void OnFeedInput(InputAction.CallbackContext ctx)
    {
        //Only feeds animals on start press.  Ignores ctx.proceed and ctx.cancel.
        if (ctx.start)
        {
            //Send name of button pressed to FeedAnimal
            FeedAnimal(ctx.control.name);
        }
    }


}
