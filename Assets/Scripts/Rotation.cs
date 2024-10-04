using UnityEngine;

public class Rotation : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0,0, 100 * Time.deltaTime);
    }
}
