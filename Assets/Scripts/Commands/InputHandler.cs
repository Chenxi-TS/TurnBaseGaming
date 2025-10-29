using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
    Queue<ICommand> commandQueue = new Queue<ICommand>();
    public InputHandler()
    {
        Debug.LogWarning("Input Handler Initialized");
    }
    public ICommand GetInput()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            DirectionalCommand newDirectionCommand = new DirectionalCommand(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
            commandQueue.Enqueue(newDirectionCommand);
            return newDirectionCommand;
        }

        if(Input.GetButtonDown("Submit") == true)
        {
            ConfirmCommand newConfirmCommand = new ConfirmCommand();
            commandQueue.Enqueue(newConfirmCommand);
            Debug.Log("InputHandler_GetInput_ConfirmCommand");
            return newConfirmCommand;
        }

        if(commandQueue.Count > 20)
            commandQueue.Dequeue();
        return null;
    }
}
