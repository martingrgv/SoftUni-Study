namespace GenericScale
{
    public class EqualityScale<T1, T2>
    {
        private T1 element1;
        private T2 element2;

        public EqualityScale(T1 element1, T2 element2)
        {
            this.element1 = element1;
            this.element2 = element2;
        }

        public bool AreEqual() => element1 == element2;
    }
}
