namespace TSim.Collections
{
    /// <summary>Dizi tabanlı yığın (LIFO): son giren ilk çıkar.</summary>   
public sealed class ArrayStack<T>
{
    private T[] _items;
    private int _Count;

    public int Count => _Count;

    public ArrayStack(int capacity = 8)
    {
        if (capacity < 1) capacity = 1;
        _items = new T[capacity];

    }
        /// <summary>En üste ekler. O(1) amortized: dolunca Grow O(n), ama nadiren.</summary> 
        public void Push(T item)
        {
            if (_Count == _items.Length)
                Grow();
            _items[_Count] = item;
            _Count++;
        }
        /// <summary>En üsttekini alır. Boşsa false döner. O(1).</summary> 
        public bool TryPop(out T item)
        {
            if (_Count == 0)
            {
                item = default;
                return false;
            }
            _Count--;
            item = _items[_Count];
            _items[_Count] = default;
            return true;

        }

        /// <summary>Diziyi 2 katına çıkarır, elemanları kopyalar. O(n).</summary>
        private void Grow()
        {
            T[] bigger = new T[_items.Length * 2];
            for (int i = 0; i < _Count; i++)
                bigger[i] = _items[i];
            _items = bigger;
        }

} 
}
