using UnityEngine;

public class Cube : MonoBehaviour
{
    // Components
    private MeshRenderer mesh_renderer;
    private Timer timer;
    
    // Timer Variables
    private float color_time = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get Components
        mesh_renderer = GetComponent<MeshRenderer>();
        timer = GetComponent<Timer>();

        // Start Timer
        timer.StartTimer(color_time);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            timer.SetPause(true);
        if (Input.GetKeyDown(KeyCode.X))
            timer.SetPause(false);

        if (timer.IsFinished())
        {
            ChangeColor();
            timer.StartTimer(color_time);
        }
    }

    private void ChangeColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        mesh_renderer.material.color = new Color(r, g, b);

    }
}
