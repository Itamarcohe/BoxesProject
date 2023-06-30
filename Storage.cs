namespace BoxesProject
{
    public class Storage
    {


        private int totalBoxesCount;
        public AVLTree avlTree;

        public Storage()
        {
            avlTree = new AVLTree();
        }

        public void AddBox(Box box)
        {
            avlTree.Insert(box);
            totalBoxesCount++;
        }

        public Box GetBestBaseMatch(double requestedSize, double percentageDifference)
        {
            Box bestMatch = avlTree.FindClosestBaseSize(requestedSize, percentageDifference);

            return bestMatch;
        }

        public override string ToString()
        {
            return totalBoxesCount.ToString();
        }
    }

}
