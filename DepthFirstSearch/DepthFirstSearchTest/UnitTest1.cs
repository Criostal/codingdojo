﻿using System;
using NUnit.Framework;
using DepthFirstSearch;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace DepthFirstSearchTest
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void WhereAreWeFirstNode()
        {
            var node = new Node("A");
            var result = KataSearch.WhereAreWe(node);
            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void WhereAreTheExitsFirstNode()
        {
            var node = new Node("A");
            node.AddChildren("B", "C");
            var result = KataSearch.WhereAreTheExists(node);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void TraverseNodeShouldReturnPath()
        {
            var node = new Node("A");
            node.AddChildren("B", "C");
            var result = KataSearch.Traverse(node);
            Assert.That(result.ToArray(), Is.EqualTo(new string[] { "A", "B", "A", "C", "A" }));
        }


        [Test]
        public void TraverseNodeShouldReturnHugePath()
        {
            var node = new Node("1");
            var children = node.AddChildren("2", "7", "8");
            var c2 = children[0].AddChildren("3", "6");
            c2[0].AddChildren("4", "5");

            var c3 = children[2].AddChildren("9", "12");            
            c3[0].AddChildren("10", "11");

            var empty = new List<Node>();
            var result = KataSearch.Traverse(node);
            Assert.That(result.ToArray(), Is.EqualTo(new string[] { "1", "2", "3", "4" , "3", "5", "3", "2", "6", "2", "1", "7", "1", "8", "9", "10", "9", "11", "9", "8", "12", "8", "1"}));
        }

        [Test]
        public void TestMaze()
        {
            var node = new Node("1");
            var children = node.AddChildren("2");
            var child1 = children[0].AddChildren("3");
            var child2 = child1[0].AddChildren("4", "6");
            var child3 = child2[0].AddChildren("5");
            var child4 = child2[1].AddChildren("7");
            var child5 = child4[0].AddChildren("8");

            var empty = new List<Node>();
            var result = KataSearch.Traverse(node);
            Assert.That(result.ToArray(), Is.EqualTo(new string[] { "1", "2", "3", "4", "5", "4", "3", "6","7","8","7","6","3","2","1"}));
        }

    }


}
