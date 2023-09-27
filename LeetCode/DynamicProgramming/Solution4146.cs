/// <summary>
/// https://leetcode.com/explore/learn/card/dynamic-programming/631/strategy-for-solving-dp-problems/4146/
/// </summary>
public class Solution4146
{
  public int MaximumScore(int[] nums, int[] multipliers)
  {
    var array = new int[multipliers.Length, multipliers.Length + 1];

    array[0, 0] = multipliers[0] * nums[nums.Length - 1];

    for (var i = 1; i < multipliers.Length; i++)
      array[i, 0] = multipliers[i] * nums[nums.Length - i - 1] + array[i - 1, 0];

    array[0, 1] = multipliers[0] * nums[0];

    for (var i = 1; i < multipliers.Length; i++)
      array[i, i + 1] = multipliers[i] * nums[i] + array[i - 1, i];


    for (var i = 1; i < multipliers.Length; i++)
    {
      for (int j = 1; j <= i; j++)
      {
        array[i, j] = Math.Max(
          array[i - 1, j] + multipliers[i] * nums[nums.Length - 1 - (i - j)],
          array[i - 1, j - 1] + multipliers[i] * nums[j - 1]);
      }
    }

    var max = int.MinValue;

    for (int j = 0; j < multipliers.Length + 1; j++)
    {
      var t = array[multipliers.Length - 1, j];

      if (t > max) max = t;
    }

    return max;
  }
}

