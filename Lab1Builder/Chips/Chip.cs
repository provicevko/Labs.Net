namespace Lab1Builder.Chips
{
    /// <summary>
    /// This class represents a chip
    /// </summary>
    public abstract class Chip
    {
        public int Id { get; } = ++_idCounter;
        public string Name { get; }

        public int XCoord { get; protected set; }
        public int YCoord { get; protected set; }

        private static int _idCounter;

        protected Chip(string name)
        {
            Name = name;
        }
        /// <summary>
        /// This method moves a chip on the realization specifics
        /// </summary>
        internal abstract void Move(int x, int y);
    }
}
