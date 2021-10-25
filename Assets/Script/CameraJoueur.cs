
using UnityEngine;

public class CameraJoueur : MonoBehaviour
{
    public float _cameraSpeed = 2.0f;

    private float cameraSpeed { get { return _cameraSpeed; } }

    private Transform cameraTransform { get; set; } = null;

    public float _borderSize = 10.0f;
    public float borderSize { get { return _borderSize; } }

    private const float deadZone = 0.9f;



    private void Start()


    {
        cameraTransform = GetComponent<Transform>();


    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 direction = Vector3.zero;

        if (mousePos.x <= borderSize || Input.GetAxis("Horizontal") < -deadZone)
        {
            direction -= Vector3.right * Time.deltaTime * cameraSpeed;
        }
        else if (mousePos.x >= Screen.width - borderSize || Input.GetAxis("Horizontal") > deadZone)
        {
            direction += Vector3.right * Time.deltaTime * cameraSpeed;
        }
        if (mousePos.y <= borderSize || Input.GetAxis("Vertical") < -deadZone)
        {
            direction += Vector3.back * Time.deltaTime * cameraSpeed;
        }
        else if (mousePos.y >= Screen.height - borderSize || Input.GetAxis("Vertical") > deadZone)
        {
            direction += Vector3.forward * Time.deltaTime * cameraSpeed;
        }

        direction.Normalize();
        cameraTransform.position += direction * Time.deltaTime * cameraSpeed;
    }
}
