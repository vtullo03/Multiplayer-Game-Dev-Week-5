using UnityEngine;

public class TemporaryWinLogic : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") gameObject.active = false;
    }
}
