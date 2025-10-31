using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem;

public class DestroyFood : MonoBehaviour
{
    private float secondsInScene;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        secondsInScene = 1.5f;
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new
WaitForSeconds(secondsInScene);
        Destroy(
            gameObject);
    }

}
 