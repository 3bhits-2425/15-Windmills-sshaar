using UnityEngine;
using UnityEngine.UI;

public class WindmillManager : MonoBehaviour
{
    [SerializeField] private GameObject[] windmills;
    [SerializeField] private Slider[] sliders;
    [SerializeField] private GameObject colorSquare;
    private Renderer squareRenderer;
    private int currentWindmill = 0;
    private float[] speeds = new float[3];
    private bool[] isLocked = new bool[3];
    private float maxSpeed = 255f;

    private void Start()
    {
        squareRenderer = colorSquare.GetComponent<Renderer>();
    }

    private void Update()
    {
        if (currentWindmill < windmills.Length && !isLocked[currentWindmill])
        {
            if (Input.GetKey(KeyCode.Space))
            {
                IncreaseSpeed(Time.deltaTime);
            }
            else
            {
                DecreaseSpeed(Time.deltaTime);
            }
        }

        Rotate();
    }

    private void IncreaseSpeed(float deltaTime)
    {
        float newSpeed = Mathf.Clamp(speeds[currentWindmill] + (deltaTime * 100f), 0, maxSpeed);
        speeds[currentWindmill] = newSpeed;
        sliders[currentWindmill].value = newSpeed;
    }

    private void DecreaseSpeed(float deltaTime)
    {
        if (!isLocked[currentWindmill])
        {
            float newSpeed = Mathf.Clamp(speeds[currentWindmill] - (deltaTime * 100), 0, maxSpeed);
            speeds[currentWindmill] = newSpeed;
            sliders[currentWindmill].value = newSpeed;
        }
    }

    private void Rotate()
    {
        for (int i = 0; i < windmills.Length; i++)
        {
            if (speeds[i] > 0)
            {
                windmills[i].transform.Rotate(Vector3.forward * speeds[i] * Time.deltaTime);
            }
        }
    }

    public void LockWindmill(int index)
    {
        if (!isLocked[index])
        {
            isLocked[index] = true;
            currentWindmill++;
        }
    }

    public void UpdateColorSquare()
    {
        float redValue = speeds[0] ;
        float greenValue = speeds[1];
        float blueValue = speeds[2];
        Color newColor = new Color(redValue, greenValue, blueValue);
        squareRenderer.material.color = newColor;
    }
}


