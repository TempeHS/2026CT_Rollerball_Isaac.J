using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Isaac, I'm putting comments to help you understand the code

    //You drag and drop your player game object into this field in the inspector
    public GameObject player;
    //This is how fast the camera will rotate when you move the mouse
    public float mouseSensitivity = 3f;
    //This is how far the camera will be from the player
    public float distance = 5f;
    //These are the limits for how far up and down the camera can look
    public float minPitch = -30f;
    public float maxPitch = 60f;

    //These variables will keep track of the camera's current rotation angles
    private float _yaw;
    private float _pitch;

    void Start()
    {
        // Initialise yaw/pitch from the camera's starting orientation.
        _yaw   = transform.eulerAngles.y;
        _pitch = transform.eulerAngles.x;
        //Lock the cursor to the center of the screen and hide it, so it doesn't interfere with the game.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible   = false;
    }

    void LateUpdate()
    {
        // Move the camera left/right based on horizontal mouse movement.
        _yaw   += Input.GetAxis("Mouse X") * mouseSensitivity;
        // Move the camera up/down based on vertical mouse movement.
        // Minus is used so moving the mouse up makes the camera look up.
        _pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        // Keep the up/down angle in a safe range so the camera cannot flip over.
        _pitch  = Mathf.Clamp(_pitch, minPitch, maxPitch);

        // Build a rotation from the current up/down (pitch) and left/right (yaw) angles.
        Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0f);
        // Put the camera behind the player at the chosen distance, using that rotation.
        transform.position  = player.transform.position + rotation * new Vector3(0f, 0f, -distance);
        // Make the camera face in the same direction as the calculated rotation.
        transform.rotation  = rotation;
    }
}