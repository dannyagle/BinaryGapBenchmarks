﻿namespace BinaryGap;

public class Gap : IGap
{
    public int LinqSolution(int value)
    {
        var binary = Convert.ToString(value, 2);
        binary = binary.Substring(binary.IndexOf("1"), binary.LastIndexOf("1") - binary.IndexOf("1"));

        var results = binary.Split("1", StringSplitOptions.RemoveEmptyEntries);
        return results.Length < 1
            ? 0
            : results.Select(x => x.Length).OrderByDescending(x => x).First();
    }

    public int ArraySolution(int value)
    {
        var binary = Convert.ToString(value, 2);
        var chars = binary.ToCharArray();

        var retval = 0;
        var gap = 0;
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] == '0') 
                gap++;
            else
            {
                if (gap > retval) retval = gap;
                gap = 0;
            }
        }
        return retval;
    }

    public int ShiftSolution(int value)
    {
        var maxGap = 0;
        var gap = 0;
        var mask = 1;

        // skip invalid candidates
        while ((mask & value) == 0 && mask != 0)
            mask <<= 1;

        mask <<= 1;
        for (; mask != 0; mask <<= 1)
        {
            // check if the current bit is set
            if ((mask & value) == mask)
            {
                if (gap > maxGap) maxGap = gap;
                gap = 0;
            }
            else
                ++gap;
        }

        return maxGap;
    }

}
