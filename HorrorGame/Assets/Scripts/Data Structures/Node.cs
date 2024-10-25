using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Node that holds data
/// </summary>
/// <typeparam name="T"></typeparam>
public class Node<T>
{
    public T data { get; set; }
    public Node<T> next{ get; set; }
    
    //constructor for the node
    public Node(T data)
    {
        this.data = data;
        this.next = null;
    }
}
