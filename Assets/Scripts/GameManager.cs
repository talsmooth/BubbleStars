using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject game;

    public GameObject starSelectUI;
    public GameObject lobbyUI;
    public GameObject infoUI;


    public Material materialToChange; // Reference to the material you want to change
    public List<Texture2D> textures = new List<Texture2D>(); // List to hold textures
    private int currentTextureIndex = 0; // Index of the current texture


    void Start()
    {
        mainMenu.SetActive(true);
        game.SetActive(false);

        lobbyUI.SetActive(true);
        starSelectUI.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {

            SceneManager.LoadScene(0);
        
        }


        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera through the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object clicked has the "Major" tag
                if (hit.collider.CompareTag("Major"))
                {
                    InfoUI();
                }
            }

        }

        }


    public void StartGame()
    {   
        mainMenu.SetActive(false);
        game.SetActive(true);

        starSelectUI.SetActive(false);
    }

    public void StarSelectUI()
    {

        lobbyUI.SetActive(false);
        starSelectUI.SetActive(true);
       
    }

    public void StarConfirmUI()
    {

        starSelectUI.SetActive(false);
        lobbyUI.SetActive(true);

    }


    public void InfoUI()
    {

        infoUI.SetActive(true);

    }

    public void NextChangeBaseMap()
    {
        if (textures.Count == 0)
        {
            Debug.LogError("No textures loaded.");
            return;
        }

        // Set the base map of the material to the current texture
        materialToChange.mainTexture = textures[currentTextureIndex];

        // Move to the next texture
        currentTextureIndex = (currentTextureIndex + 1) % textures.Count;
    }

    // This method is called when the button for previous texture is clicked
    public void BackChangeBaseMap()
    {
        if (textures.Count == 0)
        {
            Debug.LogError("No textures loaded.");
            return;
        }

        // Move to the previous texture
        currentTextureIndex = (currentTextureIndex - 1 + textures.Count) % textures.Count;

        // Set the base map of the material to the current texture
        materialToChange.mainTexture = textures[currentTextureIndex];
    }






}
