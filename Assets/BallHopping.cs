using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHopping : MonoBehaviour
{
    [SerializeField] private float fallSpeed;
    [SerializeField] private float riseSpeed;
    private Rigidbody ball;
    private bool isColliding;
    [SerializeField] float duration = 10f;
    float elapsedTime;
    float percentage;
    Vector3 startPos;
    Vector3 endPos;
    private void Awake()
    {
        ball = GetComponent<Rigidbody>();
    }

    private void Update()
    {
                                                         //if (ball.velocity.y <= 0)
                                                         //{
                                                         //    // ball.velocity -= Vector3.down * Physics.gravity.y * (fallSpeed - 1) * Time.deltaTime;
                                                         //    ball.velocity += Vector3.down * 2 * (fallSpeed - 1) * Time.deltaTime;

                                                         //}

        elapsedTime += Time.deltaTime;
        percentage = elapsedTime / duration;


        ball.velocity += Vector3.down * 5f * (fallSpeed - 1) * Time.deltaTime;



        if (isColliding)
        {
            Debug.Log("Hello");
            Debug.Log(percentage);           
          //  transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0, 1, percentage));// * Time.deltaTime);
            transform.position = Vector3.Lerp(startPos, endPos, percentage);// * Time.deltaTime);

            if (transform.position == endPos) isColliding = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            startPos = transform.position;
            endPos = startPos + new Vector3(0f, 2f, 0f);
            percentage = 0f;                                                                //  ball.AddForce(new Vector3(0f, riseSpeed, 0f), ForceMode.Impulse);
            elapsedTime = 0f;                                                                  //  transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up * 10f, 10f * Time.deltaTime);
            isColliding = true;
        }
    }

}
