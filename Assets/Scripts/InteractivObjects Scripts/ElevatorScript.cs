using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    [SerializeField] float LimitMin;
    [SerializeField] float LimitMax;

    private SliderJoint2D sliderJoint;
    private JointMotor2D motor;

    private void Awake()
    {
        sliderJoint = GetComponent<SliderJoint2D>();
        motor = sliderJoint.motor;
        motor.motorSpeed = -1;
        sliderJoint.motor = motor;
    }

    private void FixedUpdate()
    {
        if (transform.position.y > LimitMax)
        {
            motor.motorSpeed = 1;
            sliderJoint.motor = motor;
        }

        if (transform.position.y < LimitMin)
        {
            motor.motorSpeed = -1;
            sliderJoint.motor = motor;
        }
    }
}
