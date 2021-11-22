using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallingPlatforms : MonoBehaviour
{
    public AnimationCurve curve;

    Rigidbody rb;

    Vector3 startingPosition;
    Quaternion startingRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.isKinematic = true;  // not affected by gravity
        startingPosition = this.transform.position;
        startingRotation = this.transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ResetPlatform());
        }
    }

    IEnumerator ResetPlatform()
    {
        yield return new WaitForSeconds(1);             // platform does nothing for 1 second
        rb.isKinematic = false;                         // let the platform fall
        yield return new WaitForSeconds(3);             // wait 3 seconds
        rb.isKinematic = true;                          // make the platform not move
        StartCoroutine(LerpPosition());                 // reset the platform's position
    }

    IEnumerator LerpPosition()
    {
        Vector3 endPosition = this.transform.position;  // point A in our lerping
        Quaternion endRotation = this.transform.rotation;
        float elaspedTime = 0f;                         // the time component of our lerping
        float returnInterval = 1f;                      // the total time of our lerping
        while(elaspedTime < returnInterval)
        {
            this.transform.position = Vector3.Lerp(endPosition, startingPosition, curve.Evaluate(elaspedTime / returnInterval));
            elaspedTime += Time.deltaTime;

            this.transform.rotation = Quaternion.Lerp(endRotation, startingRotation, curve.Evaluate(elaspedTime / returnInterval));
            elaspedTime += Time.deltaTime;

            yield return null;
        }
        
    }
}
