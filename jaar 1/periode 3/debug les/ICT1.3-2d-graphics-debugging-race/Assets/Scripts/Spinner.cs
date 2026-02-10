using UnityEngine;

public class Spinner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 100f;

    void Update()
        {

            transform.Rotate(new Vector3(0, 0, 1), speed * Time.deltaTime);

        }   
}
