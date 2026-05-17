using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2;
    public float horizontalSpeed = 3;
    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;

    [SerializeField] bool isRunning;

    void Update()
    {
        if (isRunning == false)
        {
            isRunning = true;
            StartCoroutine(AddDistance());
        }

        // движение вперед
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        // влево
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed, Space.World);
            }
        }

        // вправо
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed, Space.World);
            }
        }
    }

    IEnumerator AddDistance()
    {
        yield return new WaitForSeconds(0.25f);

        MasterInfo.distanceRun += 1;

        isRunning = false;
    }
}