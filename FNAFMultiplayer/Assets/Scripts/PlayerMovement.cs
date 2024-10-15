using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!transform.parent.GetComponent<NetworkObject>().IsLocalPlayer) this.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = -Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime);
        transform.Translate(-Vector3.right * horizontalInput * Time.deltaTime);
    }
}
