using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace CodeWarsTests
{
    public class TreeOrder
    {
        public static List<Node> GetTop(Node node, int i)
        {
            var sortedList = new SortedList<float, Node>();
            PopulateList(node, sortedList);
            var result = sortedList.Values.Take(i).ToList();

            return result;
        }

        private static void PopulateList(Node node, SortedList<float, Node> sortedList)
        {
            var neighbours = node.Children;
            if(!neighbours.Any())
                return;

            foreach (var neighbour in neighbours)
            {
                if(sortedList.ContainsValue(neighbour))
                    continue;

                var weight = - neighbour.Weight - ((float)neighbour.Id / 100);

                sortedList.Add(weight, neighbour);

                PopulateList(neighbour, sortedList);
            }
        }
    }

    public class Node
    {
        public int Id { get; }

        public float Weight { get;}

        public List<Node> Children { get;}

        public Node(int id, float weight)
        {
            Id = id;
            Weight = weight;
            Children = new List<Node>();
        }

        public void AddChildren(Node node)
        {
            Children.Add(node);
        }
    }


    [TestFixture]
    public class TreeOrderTest
    {
        Node root;

        [SetUp]
        public void Init()
        {
            root = new Node(1, 1.2F);
            root.AddChildren(new Node(2, 2.1F));
            root.AddChildren(new Node(3, 3.2F));
            root.Children[0].AddChildren(new Node(4, 4.4F));
            root.Children[1].AddChildren(new Node(5, 5.4F));
            root.Children[0].AddChildren(new Node(6, 6.4F));
            root.Children[0].AddChildren(new Node(7, 6.4F));
        }

        [Test]
        public void GraqphSingle()
        {
            var expected = new List<Node> { root.Children[0].Children[2] };

            var actual = TreeOrder.GetTop(root, 1);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void GraqphMultiple()
        {
            var expected = new List<Node>
            {
                root.Children[0].Children[2],
                root.Children[0].Children[1],
                root.Children[1].Children[0],
                root.Children[0].Children[0]
            };

            var actual = TreeOrder.GetTop(root, 4);

            Assert.AreEqual(actual, expected);
        }

    }
}
