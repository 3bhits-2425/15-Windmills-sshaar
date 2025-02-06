using UnityEngine;

public class WindmillRotationConstantSpeed : MonoBehaviour
{
    [SerializeField] public float rotationSpeed = 100f; 
    private bool isRotating = false; 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRotating = !isRotating;
        }

        if (isRotating)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}
