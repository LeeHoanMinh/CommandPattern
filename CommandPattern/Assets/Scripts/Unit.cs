using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitDirection
{
    Up, Left, Down, Right
}
public abstract class Unit : MonoBehaviour
{
    [field: SerializeField]
    public Vector2 CurrentPosition{get; set;}
    public abstract void Init();
    private bool CheckInRange(Vector2 position)
    {
        return(0 <= position.x && position.x <= Const.MAX_ROW)
        && (0 <= position.y && position.y <= Const.MAX_COL);
    }
    private Vector2 MoveByDirection(Vector2 position, UnitDirection direction)
    {
        Vector2 newPosition = Vector2.zero; 
        switch (direction)
        {
            case UnitDirection.Up:
            newPosition = position + Vector2.up;
            break;
            case UnitDirection.Down:
            newPosition = position + Vector2.down;
            break;
            case UnitDirection.Left:
            newPosition = position + Vector2.left;
            break;
            case UnitDirection.Right:
            newPosition = position + Vector2.right;
            break;
        }
        return newPosition;
    }
    public bool CheckMoveInRange(UnitDirection direction)
    {
        Vector2 newPosition = MoveByDirection(CurrentPosition, direction);
        if(CheckInRange(newPosition)) return true;
        return false;
    }
    public void Move(UnitDirection direction)
    {
        CurrentPosition = MoveByDirection(CurrentPosition, direction);
    }
}
