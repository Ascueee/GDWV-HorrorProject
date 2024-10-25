using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedList<T>
{
    //tracks the head of the list
    private Node<T> head;

    public LinkedList()
    {
        head = null;
    }
    
    
    //Add Data to the end of the list
    public void AddDataEndOfList(T data)
    {
        //creates a new node
        Node<T> newNode = new Node<T>(data);
        
        //updates head node to new node
        if(head == null)
            head = newNode;
        else
        {
            //gets the current node
            Node<T> current = head;
            
            //itterates throught the list until it gets to the end
            while(current.next != null)
                current = current.next;
            
            current.next = newNode;
        }
        
    }
    
    public void AddDataToStartOfList(T data)
    {
        Node<T> newNode = new Node<T>(data);
        newNode.next = head;
        head = newNode;
    }
    
    public bool Remove(T data)
    {
        if (head == null) return false;

        if (head.data.Equals(data))
        {
            head = head.next;
            return true;
        }

        Node<T> current = head;
        while (current.next != null && !current.next.data.Equals(data))
        {
            current = current.next;
        }

        if (current.next != null)
        {
            current.next = current.next.next;
            return true;
        }
        return false;
    }
    
    // Print all nodes in the list
    public void PrintList()
    {
        Node<T> current = head;
        while (current != null)
        {
            Debug.Log(current.data + " -> ");
            current = current.next;
        }
        Debug.Log("Null");
    }

    // Check if list contains a value
    public bool Contains(T data)
    {
        Node<T> current = head;
        while (current != null)
        {
            if (current.data.Equals(data))
            {
                return true;
            }
            current = current.next;
        }
        return false;
    }
}
