namespace BoxesProject
{
    public class Storage
    {
        private int totalBoxesCount = 0; // Count starts from 0
        public AVLTree avlTree;
        private int allowedDifference;

        public Storage(int allowedDifference)
        {
            avlTree = new AVLTree();
            this.allowedDifference = allowedDifference;
        }

        public void AddBox(Box box)
        {
            avlTree.Insert(box);
            totalBoxesCount++;
        }

        public override string ToString()
        {
            return totalBoxesCount.ToString();
        }


        public Box? FindBestBoxMatch(double xTarget, double yTarget)
        {
            Box? bestBox = null;

            Node? xNode = FindBestXMatches(xTarget);

            if (xNode == null)
            {
                //In Case there is no X that is in the range or exact match
                //Kept it like that so with this version
                //I can Show dialog box when reached here Telling the user
                // There is no X that fits his required box
                return null;
            }
            else
            {
                //Same here for Y check if its null and then tell him we found a matching X
                
                bestBox = FindBestYMatches(xNode, yTarget);
            }

            return bestBox;
        }

        private Node? FindBestXMatches(double xTarget)
        {
            Node currentNode = avlTree.root;
            double worstMatch = xTarget + (xTarget / allowedDifference);
            Node? currentBestMatchFound = null;

            while (currentNode != null)
            {
                if (currentNode.MyX == xTarget)
                {
                    return currentNode;
                }
                else if
                    (currentNode.MyX > xTarget)
                {
                    if (currentNode.MyX <= worstMatch)
                    {
                        currentBestMatchFound = currentNode;
                    }
                    currentNode = currentNode.Left;
                }
                else if    //             //16-xTarget / Worstmath 17.6
                    (currentNode.MyX < xTarget)
                {
                    currentNode = currentNode.Right;

                }
            }
            return currentBestMatchFound;
        }



        private Box? FindBestYMatches(Node node, double Ytarget)
        {
            //double worstMatch = Ytarget + (Ytarget / allowedDifference);
            Box? currentBestMatchFound = null;

            double diff = double.MaxValue;

            //Case the Node box is already exact Y we searching
            if (node.Box.Y == Ytarget)
            {
                return node.Box;
            }
            else if (node.Box.Y > Ytarget)
            {

                diff = node.Box.Y - Ytarget;
                currentBestMatchFound = node.Box;
            }

            if (node.SameXList != null)
            {
                int left = 0;
                int right = node.SameXList.Count - 1;

                // Binary search to find the best match for Y
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    Box box = node.SameXList[mid];


                    double currentDiff = box.Y - Ytarget;

                    if (currentDiff >= 0 && currentDiff < diff)
                    {
                        currentBestMatchFound = box;
                        diff = currentDiff;
                    }

                    if (box.Y == Ytarget)
                    {
                        return box;
                    }

                    else if (box.Y < Ytarget)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return currentBestMatchFound;


        }


        //
    }

}
