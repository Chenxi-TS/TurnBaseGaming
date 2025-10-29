using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalCommand : ICommand
{
    Vector2 axisDirection;
    public Vector2 AxisDirection { get { return axisDirection; } }
    public DirectionalCommand(Vector2 axisDirection)
    {
        this.axisDirection = axisDirection;
    }
}
