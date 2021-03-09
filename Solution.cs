public int FindMax(int[] space, int x)
{
    var chunkNum = 1;
    var s = new Stack<int>();
    s.Push(0);

    for (int i = 1; i < space.Length; i++)
    {
        // first chunk
        if (i < x)
        {
            if (space[i] < space[s.Peek()])
            {
                s.Pop();
                s.Push(i);
            }
        }
        // other chunks
        else
        {
            // if found minimum is member of current chunk we just need to compare current number with it
            var peek = s.Peek();
            if (peek >= chunkNum)
            {
                s.Push(space[i] < space[peek] ? i: peek);
            }
            // we have to loop through current chunk to find minimum number
            else
            {                
                s.Push(i);
                
                var j = chunkNum;
                var count = 0;
                while (count++ < x)
                {
                    if (space[j] < space[s.Peek()])
                    {
                        s.Pop();
                        s.Push(j);
                    }
                    j++;
                }
            }
            // we are ready to go to next chunk
            chunkNum++;
        }
    }
    
    return s.Select(c => space[c]).Max();
}
