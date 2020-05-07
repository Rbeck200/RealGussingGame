using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;


public class Node
{
    //getters and setters for the tree
    public string question { get; set; }
    public Node yes { get; set; }
    public Node no { get; set; }
    public bool leaf
    {
        get; set;
    }
}
public class TreeFactory
{
        Node root;
        Node current;
        List<Node> animalQuestion;

        public List<Node> makeList()
        {
            List<Node> lines = new List<Node>();


        using (StreamReader reader = new StreamReader("Assets/TreeText.txt"))
        {
            while (!reader.EndOfStream)
            {
                Node node = new Node
                {
                    question = reader.ReadLine()
                };

                if (node.question[0] == '*')
                {
                    node.question = node.question.Substring(1);
                    node.leaf = true;
                }
                lines.Add(node);
            }
        }
        return lines;
    }

        public Node makeTree(List<Node> questions)
        {
            root = questions[0];
            questions.RemoveAt(0);

            root.yes = makeTreeHelper(questions);
            root.no = makeTreeHelper(questions);

            return root;
        }

        public Node makeTreeHelper(List<Node> questions)
        {
            if (questions.Count == 0)
            {
                return current;
            }
            current = questions[0];
            questions.RemoveAt(0);

           
            if (current.leaf)
            {
                current.yes = new Node
                {
                    question = "I win!"
                };

                current.no = new Node
                {
                    question = "I lost!"
                };
            }
            else
            {
                current.yes = makeTreeHelper(questions);
                current.no = makeTreeHelper(questions);
            }

            return current;
        }

        public void left()
        {
            current = current.yes;
        }

        public void right()
        {
            current = current.no;
        }

    public void treeSetup()
        {
            animalQuestion = new List<Node>();
            animalQuestion = makeList();

            makeTree(animalQuestion);
            current = root;
        }

        public string getQuestion()
        {
            return current.question;
        }

    }

