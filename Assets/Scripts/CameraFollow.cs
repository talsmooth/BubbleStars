using System.Collections;

using TMPro;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public float min = -10f; // Minimum Y value
    public float max = 10f; // Maximum Y value
    private Vector3 velocity = Vector3.zero;


    public Vector3 defaultPos;
    public Vector3 selectStarPos;
    public Vector3 gamePos;


    bool isActivated;
    bool isSelectStarPos;
    bool isDefaultPos;
    bool isGamePos;

    public void Start()
    {
    }
    private void LateUpdate()
    {



        if (Input.GetKeyDown(KeyCode.Space))
        {
            isActivated = true;
            //StartCoroutine(Shake());


        }

        if (isActivated && target != null)
        {

            Vector3 targetPosition = target.position + gamePos;

            // Clamp the target position on the Y axis
            targetPosition.y = Mathf.Clamp(targetPosition.y, min, max);
            // Clamp the target position on the X axis
            targetPosition.x = Mathf.Clamp(targetPosition.x, min, max);

            // Smoothly move the camera to the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        }

       if (isGamePos)
        {


            transform.position = Vector3.Lerp(transform.position, gamePos, 5 * Time.deltaTime);


        }

        if (target == null)
        {
        
            transform.position = Vector3.SmoothDamp(transform.position, gamePos, ref velocity, smoothTime);

        }

        if (isSelectStarPos)
        {

            transform.position = Vector3.Lerp(transform.position, selectStarPos, 5 * Time.deltaTime);

        }

        if (isDefaultPos)
        {

            transform.position = Vector3.Lerp(transform.position, defaultPos, 5 * Time.deltaTime);

        }

        if (isGamePos)
        {
            transform.position = Vector3.Lerp(transform.position, gamePos, 5 * Time.deltaTime);

        }
    }


    public void CameraSelectStarPos()
    {
        isSelectStarPos = true;
        isDefaultPos = false;
        isGamePos = false;

    }

    public void CameraDefaultPos()
    {
        isSelectStarPos = false;
        isDefaultPos = true;
        isGamePos = false;

    }

    public void CameraGamePos()
    {
        isSelectStarPos = false;
        isDefaultPos = false;
        isGamePos = true;

    }




    IEnumerator Shake()
    {

        Debug.Log("Shake");


        float randPos = Random.Range(0, 1f);
        Vector3 newPosition = new Vector3(randPos, randPos, transform.position.z);
        Vector3 randomPos = transform.position + newPosition;
        Vector3.Lerp(transform.position, randomPos, 3 * Time.deltaTime);

        yield return new WaitForSeconds(0.1f);

        randPos = Random.Range(0,1f);
        newPosition = new Vector3(randPos, randPos, transform.position.z);
        randomPos = transform.position + newPosition;
        Vector3.Lerp(transform.position, randomPos, 3 * Time.deltaTime);

        yield return new WaitForSeconds(0.1f);

        randPos = Random.Range(0, 1f);
        newPosition = new Vector3(randPos, randPos, transform.position.z);
        randomPos = transform.position + newPosition;
        Vector3.Lerp(transform.position, randomPos, 3 * Time.deltaTime);

        yield return new WaitForSeconds(0.1f);

        randPos = Random.Range(0, 1f);
        newPosition = new Vector3(randPos, randPos, transform.position.z);
        randomPos = transform.position + newPosition;
        Vector3.Lerp(transform.position, randomPos, 3 * Time.deltaTime);

    }
   
}
