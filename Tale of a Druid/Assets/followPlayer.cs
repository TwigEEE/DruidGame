using UnityEngine;

public class followPlayer : MonoBehaviour
{

    public Transform playerTransform, cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform.position = playerTransform.position + new Vector3(0, 0, -10);
    }
}
