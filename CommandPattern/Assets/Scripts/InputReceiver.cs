using System;
using UnityEngine;
using UnityEngine.EventSystems;
public enum MoveDirection
{
    Up,Left,Down,Right
}
public class InputReceiver : MonoBehaviour 
{
    public Vector3 DragDelta
    {
        get; private set;
    }
    public bool IsDraging
    {
        get; private set;
    }
    public bool IsTouching
    {
        get; private set;
    }

    public Action<Vector2> TouchDownAction, TouchUpAction, TouchAction;
    public Action<MoveDirection> DirectionAction;
    
    public bool allowInput = false;
    private Vector3 _savePos;
    private void Update() 
    {
        if(allowInput)
        {
            ProcessTouchInput();
            ProcessFourDirectionInput();
        }
    }
    private void ProcessFourDirectionInput()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            DirectionAction?.Invoke(MoveDirection.Up);
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            DirectionAction?.Invoke(MoveDirection.Left);
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            DirectionAction?.Invoke(MoveDirection.Down);
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            DirectionAction?.Invoke(MoveDirection.Right);
    }
    private void ProcessTouchInput()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("[InputReceiver] Point to UI Element");
            return;
        }
        if (!IsTouching && Input.GetMouseButtonDown(0))
        {
            IsTouching = true;
            TouchDownAction?.Invoke(Input.mousePosition);
        }

        if(!IsTouching)
        {
            TouchAction?.Invoke(Input.mousePosition);
        }

        if (IsTouching && Input.GetMouseButtonUp(0))
        {
            IsTouching = false;
            TouchUpAction?.Invoke(Input.mousePosition);
        }
    }   
}
