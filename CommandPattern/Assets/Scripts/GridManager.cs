using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gridPrefab;
    private GameObject[,] _gridElements;
    public void Init()
    {
        _gridElements = new GameObject[Const.MAX_ROW ,Const.MAX_COL];
        Vector2 size = gridPrefab.GetComponent<SpriteRenderer>().bounds.size;
        for(int i = 0;i < Const.MAX_ROW;i++)
        {
            for (int j = 0;j < Const.MAX_COL;j++)
            {
                Vector2 position = new Vector2(-5, -4.4f) + new Vector2(size.x * i , size.y * j);
                GameObject element = Instantiate(gridPrefab, position, gridPrefab.transform.rotation);
                _gridElements[i, j] = element;
                element.transform.SetParent(this.transform);
            }
        }   
    }
}
