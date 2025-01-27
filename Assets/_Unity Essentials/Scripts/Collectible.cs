using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Store the initial position of the collectible
    public float initialPositionY;
    public float rotationSpeed = 0.5f;

    public GameObject onCollectEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get the position at which the collectible is placed in the scene
        initialPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0); // Rotate the collectible around the Y-axis
        
        //make the collectible float up and down
        transform.position = new Vector3(transform.position.x, initialPositionY +Mathf.Abs(Mathf.Sin(Time.time))*0.06f, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collectible has collided with the player
        if (other.CompareTag("Player"))
        {
            // Destroy the collectible and play the onCollectEffect
            Instantiate(onCollectEffect, transform.position,transform.rotation);
            // Destroy the collectible
            Destroy(gameObject);
        }
    }
}
