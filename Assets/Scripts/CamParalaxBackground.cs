using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamParalaxBackground : MonoBehaviour
{
    public float damping = 1.5f;
    public GameObject _target;
    public Vector2 acc = new Vector2(1f, 1f);

    private bool gyroEnabled;

    private bool faceLeft;
    private int lastX;
    private float dynamicSpeed;
    public Camera _cam;

    void Start()
    {
        FindPlayer();
        transform.SetParent(_target.transform);
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
        lastX = Mathf.RoundToInt(_target.transform.position.x);
        transform.position = new Vector3(_cam.transform.position.x + acc.x, _cam.transform.position.y + acc.y + 2, transform.position.z);
    }

    void FixedUpdate()
    {
        if (_target)
        {
            acc = new Vector2(Mathf.Abs(acc.x), acc.y);
            acc.x = -Input.acceleration.x;
            acc.y = Input.acceleration.y;

            int currentX = Mathf.RoundToInt(_cam.transform.position.x);
            if (currentX > lastX) faceLeft = false; else if (currentX < lastX) faceLeft = true;
            lastX = Mathf.RoundToInt(_cam.transform.position.x);

            Vector3 target;
            target = new Vector3(_cam.transform.position.x + acc.x * 4, _cam.transform.position.y - acc.y * 1.3f + dynamicSpeed + 2, transform.position.z);
            if (gyroEnabled)
            {
                transform.rotation = new Quaternion(_cam.transform.rotation.x - (Input.gyro.gravity.z / 4), _cam.transform.rotation.y, _cam.transform.rotation.z + (Input.gyro.gravity.x / 50), _cam.transform.rotation.w);
            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}
