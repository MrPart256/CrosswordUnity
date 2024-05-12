using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CrosswordSpawnHandler : MonoBehaviour
{
  [SerializeField] private GridLayoutGroup m_content;
  [SerializeField] private GameObject m_emptyCell;
  [SerializeField] private CrosswordItemView m_crosswordItemPrefab;

  public CrosswordItemView[,] GenerateGrid(char[,] grid, int gridSize = 30)
  {
    int cellsInColum = grid.GetLength(0);
    int cellsInRow = grid.GetLength(1);

    CrosswordItemView[,] items = new CrosswordItemView[cellsInColum, cellsInRow];

    float cellSize = m_content.GetComponent<RectTransform>().rect.size.x / cellsInColum;

    if (cellsInColum > cellsInRow)
    {
      cellSize = m_content.GetComponent<RectTransform>().rect.size.y / cellsInRow;
    }

    m_content.cellSize = Vector2.one * cellSize;

    m_content.constraintCount = cellsInRow;

    for (int x = 0; x < grid.GetLength(0); x++)
    {
      for (int y = 0; y < grid.GetLength(1); y++)
      {
        if (grid[x, y] == '\0')
        {
          Instantiate(m_emptyCell, m_content.transform);
        }
        else
        {
          var itm = Instantiate(m_crosswordItemPrefab, m_content.transform);

          items[x, y] = itm;
        }
      }
    }

    return items;
  }
}
