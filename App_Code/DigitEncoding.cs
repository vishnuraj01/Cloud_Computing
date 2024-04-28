using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DigitEncoding
/// </summary>
public class DigitEncoding
{
    private string alphanums = "0123456789abcdefghijklmnopqrstuvwxyz";
    private const int codeLen = 6; //Length of coded string. Must be at least 4

    public string EncodeNumber(int num)
    {
        if (num < 1 || num > 999999) //or throw an exception
            return "";
        int[] nums = new int[codeLen];
        int pos = 0;

        while (!(num == 0))
        {
            nums[pos] = num % alphanums.Length;
            num /= alphanums.Length;
            pos += 1;
        }

        string result = "";
        foreach (int numIndex in nums)
            result = alphanums[numIndex].ToString() + result;

        return result;
    }

    public int DecodeNumber(string str)
    {
        //Check for invalid string
        if (str.Length != codeLen) //Or throw an exception
            return -1;
        long num = 0;

        foreach (char ch in str)
        {
            num *= alphanums.Length;
            num += alphanums.IndexOf(ch);
        }

        //Check for invalid number
        if (num < 1 || num > 999999) //or throw exception
            return -1;
        return System.Convert.ToInt32(num);
    }
}