using UnityEngine;

public class DoorControls : MonoBehaviour
{
    [SerializeField] private GameObject door;

    void CheckDoorButton()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name == name)
            {
                door.GetComponent<DoorMovement>().MoveDoor();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckDoorButton();
        }
    }
}
