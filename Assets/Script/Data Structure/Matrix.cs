using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Matrix<T> where T : MonoBehaviour
{

    private int count = 0;
    private Vector2 dim = new Vector2(0, 0);
    private List<List<T>> rows;

    public Matrix(int rows, int columns)
    {
        dim.x = rows;
        dim.y = columns;
        this.rows = new List<List<T>>();
        for (int i = 0; i < rows; i++)
        {
            this.rows.Add(new List<T>());
            for (int j = 0; j < columns; j++)
                this.rows[i].Add(null);
        }
    }

    public int Count()
    {
        return count;
    }

    public int Rows()
    {
        return (int)Math.Round(this.dim.x);
    }

    public int Columns()
    {
        return (int)Math.Round(this.dim.y);
    }

    public int Cells()
    {
        return Rows() * Columns();
    }

    public void Add(T item)
    {
        for (int i = 0; i < dim.x; i++)
            for(int j = 0; j < dim.y; j++)
                if (rows[i][j] == null)
                {
                    rows[i][j] = item;
                    return;
                }
        // every place is occupied
        throw new OutOfMemoryException("Matrix limit reached: cannot add new items");
    }

    public void AddIn(T item, int row)
    {
        for (int j = 0; j < dim.y; j++)
            if (rows[row][j] == null)
            {
                rows[row][j] = item;
                return;
            }
        // every place is occupied
        throw new OutOfMemoryException("Matrix limit reached: cannot add new items");
    }

    public void Clear()
    {
        foreach (List<T> row in rows)
            row.Clear();
        rows.Clear();
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < dim.x; i++)
            for (int j = 0; j < dim.y; j++)
                if (rows[i][j].Equals(item))
                    return true;
        return false;
    }

    public bool ContainsAt(int row, int column)
    {
        if (!sanityCheck(row, column)) throw new ArgumentOutOfRangeException("Row or column parameter exceeds the limit");
        return rows[row][column] != null;
    }

    public Vector2 IndexOf(T item)
    {
        for (int i = 0; i < dim.x; i++)
            for (int j = 0; j < dim.y; j++)
                if (rows[i][j].Equals(item))
                    return new Vector2(i, j);
        return new Vector2(-1, -1);
    }

    public void Insert(int row, int column, T item)
    {
        if (!sanityCheck(row, column)) throw new ArgumentOutOfRangeException("Row or column parameter exceeds the limit");
        rows[row][column] = item;
    }

    public bool Remove(T item)
    {
        if (!this.Contains(item)) return false;
        for (int i = 0; i < dim.x; i++)
            for (int j = 0; j < dim.y; j++)
                if (rows[i][j].Equals(item))
                {
                    rows[i][j] = null;
                    return true;
                }
        return false;
    }

    public void RemoveAt(int row, int column)
    {
        if (!sanityCheck(row, column)) throw new ArgumentOutOfRangeException("Row or column parameter exceeds the limit");
        rows[row][column] = null;
    }

    public T Get(int row, int column)
    {
        if (!sanityCheck(row, column)) throw new ArgumentOutOfRangeException("Row or column parameter exceeds the limit");
        return rows[row][column];
    }

    public List<T> GetRow(int row)
    {
        if (!sanityCheck(row)) throw new ArgumentOutOfRangeException("Row parameter exceeds the limit");
        List<T> toReturn = new List<T>();
        for (int j = 0; j < dim.y; j++)
            if (rows[row][j] != null)
                toReturn.Add(rows[row][j]);
        return toReturn;
    }

    public List<T> GetAll()
    {
        List<T> toReturn = new List<T>();
        for (int i = 0; i < dim.x; i++)
            for (int j = 0; j < dim.y; j++)
                if (rows[i][j] != null)
                    toReturn.Add(rows[i][j]);
        return toReturn;
    }

    public void Debug_View()
    {
        Debug.Log("Generated Matrix[" + dim.x + "," + dim.y + "]");
        for (int i = 0; i < dim.x; i++)
        {
            String rowbuffer = "";
            foreach (T t in GetRow(i))
                rowbuffer += t.ToString();
            Debug.Log("Row" + i + "=[" + rowbuffer + "]");
        }
    }

    private bool sanityCheck(int row, int column)
    {
        if (row >= Rows() || row < 0 || column >= Columns() || column < 0) return false;
        return true;
    }

    private bool sanityCheck(int row)
    {
        if (row >= Rows() || row < 0) return false;
        return true;
    }

}
