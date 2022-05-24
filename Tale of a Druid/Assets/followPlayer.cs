using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    // --- Variables --- \\
    public Transform playerTransform, cameraTransform;


    // --- Start Function --- \\
    void Start()
    {
        
    }


    // --- Update Function --- \\
    void Update()
    {
        cameraTransform.position = playerTransform.position + new Vector3(0, 0, -10);
    }
}
