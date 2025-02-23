using TMPro;
using UnityEngine;

public class Gyro : MonoBehaviour
{
    private const int CENTER = 165;
    private const int TOP = 335;
    private const int BOTTOM = 20;

    public float clamp;
    public TMP_Text text;

    private void Awake()
    {
        text.text = " ";
        if(SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
        else
            enabled = false;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        Vector3 rotation = new Vector3();

        rotation.x = Input.gyro.attitude.eulerAngles.x;

        if (rotation.x > CENTER && rotation.x < TOP)
            rotation.x = TOP;
        else if (rotation.x > BOTTOM && rotation.x < CENTER)
            rotation.x = BOTTOM;

        rotation.y = Input.gyro.attitude.eulerAngles.y; 

        if (rotation.y > BOTTOM && rotation.y < CENTER)
            rotation.y = BOTTOM;
        else if (rotation.y > CENTER && rotation.y < TOP)
            rotation.y = TOP;

        rotation.z = 0;

        text.text = rotation.ToString();
        transform.rotation = Quaternion.Euler(rotation);
    }

    private void FirstTest()
    {      
        Quaternion rotation = new Quaternion
        {
            x = Input.gyro.attitude.x ,
            y = Input.gyro.attitude.y ,
            z = Input.gyro.attitude.z ,
        };

        transform.rotation = rotation;
    }
}

