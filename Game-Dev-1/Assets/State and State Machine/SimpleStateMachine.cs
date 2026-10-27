using UnityEngine;
public class SimpleStateMachine : MonoBehaviour
{
    private PlayerController player_controller;

    //States
    enum States
    {
        Idle,
        Ground,
        Air
    }
    private States current_state = States.Idle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // State Machine
        switch (current_state)
        {
            case States.Idle:
                IdleState();
                break;
            case States.Ground:
                GroundState();
                break;
            case States.Air:
                AirState();
                break;
        }
    }

    private void IdleState()
    {
        // Change Color
        player_controller.rend.material.color = Color.pink;

        #region Change States
        // Ground State

        // If player direction is not moving
        if (player_controller.direction != Vector2.zero)
        {
            current_state = States.Ground;
            return;
        }
        #endregion
    }
    private void GroundState()
    {
        // Change Color
        player_controller.rend.material.color = Color.green;
    }
    private void AirState()
    {

    }
    

}
