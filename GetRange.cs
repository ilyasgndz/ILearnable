  private IEnumerable<int> GetNumbers(int first, int last)
        {
            for (int i = first; i <= last; i++)
            {
                yield return i;
            }
        }
