using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.Rendering.DebugUI.Table;

public class SpawnBubbles : MonoBehaviour
{
    public List<GameObject> bubbles = new List<GameObject>();
    public int rowSize;
    public int colSize;
    public float space;

    private Vector3 location;


    public void Start()
    {

        Vector3 location = transform.position;

        for (int x = 0; x < rowSize; x++)
        {  

            for (int y = 0; y < colSize; y++)
            {

                int randy = Random.Range(0, bubbles.Count);
                Vector3 position = location + new Vector3(x * space, y * space, 0f);
                GameObject tempBubbley = Instantiate(bubbles[randy], position, Quaternion.identity);
                tempBubbley.transform.parent = transform;
             

            }
        }
    }
}
