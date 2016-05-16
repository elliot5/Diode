using DiodeDesktop.src.logic.gate;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiodeDesktop.src.logic.node
{
    class LogicNode
    {
        //Style
        public Color color;

        //Parent Gate
        public LogicGate parentGate;

        //Connected Node
        public List<LogicNode> connectedNodes;

        //Index
        public int index;

        //Powered
        public bool powered;        

        //LogicNode properties
        public NodeProperties.nodeCompatibility nodeCompatibility;
        public NodeProperties.nodeType nodeType;

        //Initialize the LogicNode with provided color
        public LogicNode(NodeProperties.nodeCompatibility nodeCompatibility, NodeProperties.nodeType nodeType, int index, Color color)
        {
            Initialize(nodeCompatibility, nodeType, index, color);
        }

        //Initialize the LogicNode
        public LogicNode(NodeProperties.nodeCompatibility nodeCompatibility, NodeProperties.nodeType nodeType, int index) {
            Initialize(nodeCompatibility, nodeType, index, Color.White);
        }

        //Initialize from the chosen constructor
        private void Initialize(NodeProperties.nodeCompatibility nodeCompatibility, NodeProperties.nodeType nodeType, int index, Color color)
        {
            connectedNodes = new List<LogicNode>();
            this.nodeCompatibility = nodeCompatibility;
            this.nodeType = nodeType;
            this.index = index;
            this.color = color;
        }

        //Returns the calculated bounds of this node
        public Rectangle GetBounds()
        {
            return DiodeCore.logicManager.nodeManager.CalculateBounds(this, index, 10, 10);
        }

        public void OnClick()
        {
            //Check this is the starting or ending node
            if (DiodeCore.logicManager.wireManager.CurrentlyDrawing() == false) { 
                DiodeCore.logicManager.wireManager.EnableDrawing(this);
            } else
            {
                //Error 001 nodes cannot connect to themselves.
                if (this != DiodeCore.logicManager.wireManager.GetStartingNode())
                {
                    if(nodeType == NodeProperties.nodeType.Output)
                    {
                        //Error 002 output to input second time.
                        foreach(LogicNode node in connectedNodes)
                        {
                            if(node == DiodeCore.logicManager.wireManager.GetStartingNode())
                            {
                                return;
                            }
                        }

                        //Error 003 outputs cannot connect to other outputs
                        if (DiodeCore.logicManager.wireManager.GetStartingNode().nodeType == NodeProperties.nodeType.Output)
                        {
                            return;
                        }
                    }
                    if(nodeType == NodeProperties.nodeType.Input)
                    {
                        //Error 004 one wire for each input.
                        if (connectedNodes.Count > 0)
                        {
                            return;
                        }
                        //Error 005 inputs cannot connect to other inputs
                        if (DiodeCore.logicManager.wireManager.GetStartingNode().nodeType == NodeProperties.nodeType.Input)
                        {
                            return;
                        }
                    }
                    //Connect the nodes
                    Console.WriteLine("Connection made");
                    connectedNodes.Add(DiodeCore.logicManager.wireManager.GetStartingNode());
                    DiodeCore.logicManager.wireManager.GetStartingNode().connectedNodes.Add(this);
                    DiodeCore.logicManager.wireManager.DisableDrawing();
                }
            }

        }
    }
}
