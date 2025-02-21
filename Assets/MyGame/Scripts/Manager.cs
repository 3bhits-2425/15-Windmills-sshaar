using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    [SerializeField] private GameObject[] windmills;
    [SerializeField] private GameObject colorSquare;
    private GameObject[] rotorHubs;
    private Light[] lights;
    private Slider[] sliders;
    private Renderer squareRenderer;
    private int windmill = 0;
    private float[] speeds;
    private bool[] isLocked;
    private float maxSpeed = 255f;

    private void Start()
    {
        squareRenderer = colorSquare.GetComponent<Renderer>();
        int windmillCount = windmills.Length;
        rotorHubs = new GameObject[windmillCount];
        lights = new Light[windmillCount];
        sliders = new Slider[windmillCount];
        speeds = new float[windmillCount];
        isLocked = new bool[windmillCount];

        for (int i = 0; i < windmillCount; i++)
        {
            lights[i] = windmills[i].GetComponentInChildren<Light>();
            sliders[i] = windmills[i].GetComponentInChildren<Slider>();
            rotorHubs[i] = windmills[i].transform.Find("RotorHub").gameObject;

            lights[i].intensity = 0;
            sliders[i].value = 0;

            speeds[i] = 0;
            isLocked[i] = false;
        }
    }

    private void Update()
    {
        if (windmill < windmills.Length && !isLocked[windmill])
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Increase(Time.deltaTime);
            }
            else
            {
                Decrease(Time.deltaTime);
            }
        }
        Rotate();
        ColorSquare();
    }

    private void Increase(float dT)
    {
        float newSpeed = Mathf.Clamp(speeds[windmill] + (dT * 100f), 0, maxSpeed);
        speeds[windmill] = newSpeed;

        if (sliders[windmill] != null)
            sliders[windmill].value = newSpeed;

        if (lights[windmill] != null)
            lights[windmill].intensity = Mathf.Clamp(newSpeed / 255, 0, 1.12f);
    }

    private void Decrease(float dT)
    {
        if (!isLocked[windmill])
        {
            float newSpeed = Mathf.Clamp(speeds[windmill] - (dT * 100), 0, maxSpeed);
            speeds[windmill] = newSpeed;

            if (sliders[windmill] != null)
                sliders[windmill].value = newSpeed;

            if (lights[windmill] != null)
                lights[windmill].intensity = Mathf.Clamp(newSpeed / 255, 0, 1.12f);
        }
    }

    private void Rotate()
    {
        for (int i = 0; i < windmills.Length; i++)
        {
            if (speeds[i] > 0)
            {
                rotorHubs[i].transform.Rotate(Vector3.forward * speeds[i] * Time.deltaTime);
            }
        }
    }

    public void Lock(int i)
    {
        if (!isLocked[i])
        {
            isLocked[i] = true;
            windmill++;
        }
    }

    public void ColorSquare()
    {
        float red = speeds[0] / 255;
        float green = speeds[1] / 255;
        float blue = speeds[2] / 255;
        Color newColor = new Color(red, green, blue);
        squareRenderer.material.color = newColor;
    }
}



