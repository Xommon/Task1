using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public bool selected;
    public Color startingColour;
    public Renderer renderer; 
    public Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        // Get references
        renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();

        // Define starting variables
        startingColour = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            // Move the selected player
            rb.position += new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        }
    }

    private void OnMouseDown()
    {
        foreach (PlayerMovement player in FindObjectsOfType<PlayerMovement>())
        {
            // Unselect other players
            player.selected = false;
            player.renderer.material.color = player.startingColour;
        }

        selected = true;
        renderer.material.color = Color.red;
    }
}
