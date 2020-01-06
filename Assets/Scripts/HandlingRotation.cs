using System.Collections;
using UnityEngine;

public class HandlingRotation : MonoBehaviour
{
    public float RotationSpeed;
    private IEnumerator _RotationCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        RotationSpeed = 60f;
        _RotationCoroutine = Rotate(RotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Rotate(float speed)
    {
        Debug.Log("Entered Rotate");
        while (true)
        {
            //transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 700f), timeCount);
            transform.Rotate(Vector3.forward*Time.deltaTime*speed, Space.Self);
            //timeCount += Time.deltaTime;
            yield return null;
        }
    }
    public void StartRotating()
    {
        StartCoroutine(_RotationCoroutine);
    }
    public void StopRotating()
    {
        StopCoroutine(_RotationCoroutine);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
