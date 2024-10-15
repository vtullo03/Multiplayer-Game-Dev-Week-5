using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15.0f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!transform.parent.GetComponent<NetworkObject>().IsLocalPlayer) this.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + movement * Time.deltaTime * speed);
    }
}
