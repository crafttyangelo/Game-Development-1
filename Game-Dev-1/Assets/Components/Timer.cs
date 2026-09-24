using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] [Range(0,600)] private float time; // In seconds
    private bool is_paused = false;
    private bool has_finished = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start the timer if user set time in inspector
        if (time > 0)
        {
            StartTimer(time);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Stop logic since the timer is paused or finished
        if (is_paused || has_finished)
        {
            return;
        }
        // Countdown until we stop
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            StopTimer();
        }
    }
    public float GetTime()
    {
        return time;
    }    
    public bool IsFinished()
    {
        return has_finished;
    }    
    public void SetPause (bool pause)
    {
        is_paused = pause;
    }    
    public bool GetPause()
    {
        return is_paused;
    }

    // Starts the timer by setting it to time t. Acts as a setter for time
    public void StartTimer(float t)
    {
        time = t;
        is_paused = false;
        has_finished = false;
    }

    // Stops timer, setting it to 0
    public void StopTimer()
    {
        time = 0;
        has_finished = true;
    }

}
