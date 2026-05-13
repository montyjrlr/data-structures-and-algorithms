
using System.Text.Json;

var line = Console.ReadLine();
while ("exit" != line)
{
    var arrays = JsonSerializer.Deserialize<string[]>(line);
    Console.WriteLine(Solution.ZizagConvert(arrays[0], Int32.Parse(arrays[1])));
    line = Console.ReadLine();
}


return;


/**
 * Definition for singly-linked list.
 */
 public class ListNode {
    public int val;
      public ListNode next;
      public ListNode(int val = 0, ListNode next = null) {
         this.val = val;
          this.next = next;
      }
 }
 

public static class Solution {
    public static int[] TwoSum(int[] nums, int target) {

        var length = nums.Length;        
        for (int i = 0; i < length; i++)
        {
            for (int x = i+1; x < length; x++)
            {
                if(nums[i] + nums[x] == target)
                {
                    return [i, x];
                }
            }
        }
        return [];
    }

   public static ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var sum = l1.val + l2.val;
        var val = sum % 10;
        var carry = sum > 9 ? 1 : 0;
        var head = new ListNode(val);
        var result = head;

        while (l1.next != null || l2.next != null) {        
            l1 = l1.next ?? new ListNode();
            l2 = l2.next ?? new ListNode();
            sum = l1.val + l2.val + carry;
            val = sum % 10;
            carry = sum > 9 ? 1 : 0;
            result = result.next = new ListNode(val); 
            
        }

        if (carry == 1)
        {
            result.next = new ListNode(1); 
        }

        return head;
    }

    public static int LengthOfLongestSubstring(string s) {
        var lastSeen = new Dictionary<char, int>();
        int left = 0;
        int max = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];

            if (lastSeen.TryGetValue(c, out int prev) && prev >= left)
            {
                left = prev + 1;
            }

            lastSeen[c] = right;

            max = Math.Max(max, right - left + 1);
        }

        return max;
    }

    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int total = nums1.Length + nums2.Length;
        int target = total / 2;

        int i = 0;
        int j = 0;

        int prev = 0;
        int curr = 0;

        for (int count = 0; count <= target; count++)
        {
            prev = curr;

            if (i < nums1.Length &&
                (j >= nums2.Length || nums1[i] < nums2[j]))
            {
                curr = nums1[i++];
            }
            else
            {
                curr = nums2[j++];
            }
        }

        if (total % 2 == 0)
            return (prev + curr) / 2.0;

        return curr;
    }

    public static int[] SeparateDigits(int[] nums) {
        var result = new List<int> (5000);
        
        for (int nx = 0; nx < nums.Length; nx++)
        {
            var num = nums[nx];

            for (int i = (int)Math.Floor(Math.Log10(Math.Abs(num))) + 1 - 1; i >= 0; i--)
            {
                var pow = (int)Math.Pow(10, i);
                result.Add(num / pow);
                num = num % pow;
            } 
        }

        return result.ToArray();
    }

    public static string LongestPalindrome(string s) {
        int start     = 0;
        int maxLength = 1;
        for (int i = 0; i < s.Length; i++)
        {
            // odd
            SubPalindome(i, i, s, ref start, ref maxLength);

            // even
            SubPalindome(i, i + 1, s, ref start, ref maxLength);
        }

        return s.Substring(start, maxLength);
    }

    public static void SubPalindome(int left, int right, string s, ref int start, ref int max)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right] )
        {
            var newMax = right - left + 1;
            if(newMax > max)
            {
                start = left;
                max =  newMax;
            }
            left--;
            right++;
        }
    }

    public static string ZigzagConvert(string s, int numRows) {
        if (numRows == 1 || s.Length <= numRows)
            return s;

        var rows = new List<char>[numRows];

        for (int i = 0; i < numRows; i++)
        {
            rows[i] = new List<char>();
        }

        int currentRow = 0;
        bool goingDown = true;

        foreach (char c in s)
        {
            rows[currentRow].Add(c);

            if (currentRow == 0)
                goingDown = true;
            else if (currentRow == numRows - 1)
                goingDown = false;

            currentRow += goingDown ? 1 : -1;
        }

        var result = new StringBuilder();

        foreach (var row in rows)
        {
            result.Append(row.ToArray());
        }

        return result.ToString();
    }
}