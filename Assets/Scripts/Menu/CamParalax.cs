using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamParalax : MonoBehaviour
{
    public float damping = 1.5f;
    public Transform _target;
    public Vector2 acc = new Vector2(1f, 1f);

    private bool gyroEnabled;

    private bool faceLeft;
    private int lastX;
    private float dynamicSpeed;
    private Camera _cam;

    void Start()
    {
        FindPlayer();
        _cam = gameObject.GetComponent<Camera>();
        _cam.transform.position = transform.position; /**/
        transform.SetParent(_cam.transform); /**/
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            return true;
        }
        return false;
    }

    public void FindPlayer()
    {
        lastX = Mathf.RoundToInt(_target.position.x);
        transform.position = new Vector3(_target.position.x + acc.x, _target.position.y + acc.y, transform.position.z);
    }

    void FixedUpdate()
    {
        if (_target)
        {
            acc = new Vector2(Mathf.Abs(acc.x), acc.y);
            acc.x = -Input.acceleration.x;
            acc.y = Input.acceleration.y;

            int currentX = Mathf.RoundToInt(_target.position.x);
            if (currentX > lastX) faceLeft = false; else if (currentX < lastX) faceLeft = true;
            lastX = Mathf.RoundToInt(_target.position.x);

            Vector3 target;
            target = new Vector3(_target.position.x + acc.x * 20, _target.position.y - acc.y * 5 + dynamicSpeed, transform.position.z);
            if (gyroEnabled)
            {
                transform.rotation = new Quaternion(_target.rotation.x - (Input.gyro.gravity.z / 7), _target.rotation.y, _target.rotation.z + (Input.gyro.gravity.x / 20), _target.rotation.w);
            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}
