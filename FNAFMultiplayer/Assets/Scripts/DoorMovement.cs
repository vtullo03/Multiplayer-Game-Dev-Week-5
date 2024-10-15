using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    private bool isUp = false;

    public void MoveDoor()
    {
        if (!isUp) transform.position += new Vector3(0f, 3f, 0f);
        else transform.position += new Vector3(0f, -3f, 0f);
        isUp = !isUp;
    }
}
