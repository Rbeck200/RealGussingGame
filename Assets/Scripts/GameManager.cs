using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button Yes;
    public Button No;
    public Text Question;
    public TreeFactory Tree;

    void Awake()
    {
        Tree = new TreeFactory();
        Tree.treeSetup();
        Question.text = Guess();
    }

    public string Guess()
    {
        string temp; //update question with temporary string
        temp = Tree.getQuestion();
        return temp;
    }

    public void Start()
    {
        Yes.onClick.AddListener(delegate
        {
            Tree.left();
            Question.text = Guess();
        });
        No.onClick.AddListener(delegate
        {
            Tree.right();
            Question.text = Guess();
        });
    }
}

