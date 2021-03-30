using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public bool selected;
    public Color startingColour;
    public Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        // Get references
        renderer = GetComponent<Renderer>();

        // Define starting variables
        startingColour = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
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
