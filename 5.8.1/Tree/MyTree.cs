﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SpaceTree
{
    public class Node                 // узел
    {
        public object data;
        public Node left;
        public Node right;
        public int x;
        public int y;
        public bool visit;
        public int count;

        public Node(Node left, Node right, object data, int x, int y) // конструктор
        {
            this.left = left;
            this.right = right;
            this.data = data;
            this.x = x;
            this.y = y;
            this.visit = false;
            this.count = 1;
        }

        public void DrawNode(Graphics g)                          // рисование дерева
        {
            Pen myPen = Pens.Black;
            SolidBrush myBrush = (SolidBrush)Brushes.White;
            Font myFont = new Font("Courier New", 10, FontStyle.Bold); 
            
            int R = 17;
            if (left != null)
                g.DrawLine(myPen, x, y, left.x, left.y);
            if (right != null)
                g.DrawLine(myPen, x, y, right.x, right.y);

            if (visit)
                myBrush = (SolidBrush)Brushes.Yellow;
            else
                myBrush = (SolidBrush)Brushes.LightYellow;

            g.FillEllipse(myBrush, x - R, y - R, 2 * R, 2 * R);
            g.DrawEllipse(myPen, x - R, y - R, 2 * R, 2 * R);
            string s = Convert.ToString(data) + ":" + Convert.ToString(count);
            SizeF size = g.MeasureString(s, myFont);
            g.DrawString(s, myFont, Brushes.Black,
                x - size.Width / 2,
                y - size.Height / 2);

            if (left != null)
                left.DrawNode(g);
            if (right != null)
                right.DrawNode(g);
        }
    }

    class MyTree
    {
        public Node top;             // вершина дерева
        public Node selectNode;      // выделенный узел
        public static Bitmap bitmap; // канва для рисования
        const int step = 50;
        const int dh = 1;
        
        Graphics g;
        Pen myPen  = Pens.Black;
        SolidBrush myBrush = (SolidBrush)Brushes.White;
        Font myFont = new Font("Courier New", 10, FontStyle.Bold);

        public MyTree()              // конструктор
        {
            top = null;
        }

        public void Insert(ref Node node, int data, int left, int right, int x, int y)  // вставка
        {
            if ((data == 0) && (top == null))
            {
                node = new Node(null, null, data, x, y);
            }
            if (data == Convert.ToInt32(node.data))
            {
                if (left != -1)
                    node.left = new Node(null, null, left, node.x - step, node.y + dh * step);
                if (right != -1)
                    node.right = new Node(null, null, right, node.x + step, node.y + dh * step);
            }
            else
            {
                if (node.left!=null)
                    Insert(ref node.left, data, left, right, node.x - step, node.y + dh * step);
                if (node.right != null)
                    Insert(ref node.right, data, left, right, node.x + step, node.y + dh * step);
            }
        }

        Node FindNodeVal(Node node, int val)              // поиск по значению
        {
            Node result = null;
            if (Convert.ToInt32(node.data) == val)
            {
                node.visit = true;
                result = node;
            }
            else
            {
                if (node.left != null)
                    result = FindNodeVal(node.left, val);
                if ((result == null) & (node.right != null))
                    result = FindNodeVal(node.right, val);
            }
            return result;
        }

        public Node FindNodeValStart(int val)          // поиск по значению
        {
            if (top != null)
                return FindNodeVal(top, val);
            else
                return null;
        }

        public void DeSelect(Node node)                   // снятие признака посещения
        {
            if (node != null)
            {
                node.visit = false;
                DeSelect(node.left);
                DeSelect(node.right);
            }
        }

        public void Delta(Node node, int dx, int dy)      // смещение поддерева
        {
            node.x -= dx; node.y -= dy;
            if (node.left != null)
                Delta(node.left, dx, dy);
            if (node.right != null)
                Delta(node.right, dx, dy);
        }

        public Node FindNode(Node node, int x, int y)     // поиск по координатам 
        {
            Node result = null;
            if (node == null)
                return result;

            if (((node.x - x) * (node.x - x) + (node.y - y) * (node.y - y)) < 100)
                result = node;
            else
            {
                result = FindNode(node.left, x, y);
                if (result == null)
                    result = FindNode(node.right, x, y);
            }
            return result;
        }



        public void Draw()                             // рисование дерева
        {
            using (g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                if (top != null)
                    top.DrawNode(g);
            }
        }

        public string SetStrSort(Node node)               // упорядоченная строка
        {
            string s = "";
            if (node == null)
                return s;

            if (node.right != null)
                s += SetStrSort(node.right);

            s += Convert.ToString(node.data) + "\r\n";

            if (node.left != null)
                s += SetStrSort(node.left);

            return s;
        }
        public int FindMinLeaf(Node node)
        {
            int a1 = -1;
            int a2 = -1;
            bool key1 = (node.left != null);
            bool key2 = (node.right != null);
            int t;
            int g = Convert.ToInt32(node.data);
                if (!key1 && !key2)
                {
                t = g;
                }
            else
            {
                if (key1 != key2)
                {
                    if (key1)
                        t = FindMinLeaf(node.left);
                    else
                        t = FindMinLeaf(node.right);
                }
                else
                {
                    a1 = FindMinLeaf(node.left);
                    a2 = FindMinLeaf(node.right);
                    t = Math.Min(a1, a2);
                }
            }
            return t;
            
        }
    }
}
            